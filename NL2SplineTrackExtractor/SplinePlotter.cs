using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace NL2SplineTrackExtractor
{
    public partial class SplinePlotter : UserControl
    {

        private List<float>[] splinePoints;
        private List<int> splitPoints;
        private bool roundTrip;

        //used to distinguish between long and short mouseclicks
        Stopwatch leftButtonStopwatch = new Stopwatch();
        Stopwatch rightButtonStopwatch = new Stopwatch();

        private bool isLeftMouseDown = false;
        private Point lastMouseDragPosition = Point.Empty;

        private Point mousePosHover = Point.Empty;
        
        private PointF offset = Point.Empty;
        private float scale = 1;
        private const float zoomSensitivity = 0.001f;

        public delegate void CutChangedEventHandler(object sender, int pieces);
        public event CutChangedEventHandler CutChanged;

        public SplinePlotter()
        {
            DoubleBuffered = true;
            InitializeComponent();
            this.MouseDown += OnMousePressed;
            this.MouseUp += OnMouseReleased;
            this.MouseMove += OnMouseMoved;
            this.MouseWheel += OnZoom;
            this.Paint += DoPaint;
        }

        #region Cutting
        private void AddPointAt(Point location)
        {
            int node = mousePositionToNode(location);
            if (node < 0) return;

            if (!splitPoints.Contains(node))
            {
                splitPoints.Add(node);

                splitPoints.Sort();
                CutChanged?.Invoke(this, splitPoints.Count-1);
            }
        }

        private void RemovePointAt(Point location)
        {
            int node = mousePositionToNode(location);
            if (node < 0) return;

            if (node != 0 && node != splinePoints[0].Count && splitPoints.Contains(node))
            {
                splitPoints.Remove(node);
                CutChanged?.Invoke(this,splitPoints.Count - 1);
            }
            else
            {
                float minDistance = float.MaxValue;
                int minIndex = -1;
                for(int i = 1; i < splitPoints.Count-1; i++)
                {
                    float distance = getDistanceToMouse(splitPoints[i], location);
                    if (distance < minDistance)
                    {
                        minDistance = distance; 
                        minIndex = i;
                    }
                }
                if (minIndex < 0) return;
                if (minDistance < 20 && splitPoints[minIndex] != 0 && splitPoints[minIndex] != splinePoints[0].Count-1)
                {
                    splitPoints.Remove(splitPoints[minIndex]);
                    CutChanged?.Invoke(this, splitPoints.Count - 1);
                }
            }
        }

        #endregion

        #region MouseInteraction
        private int mousePositionToNode(PointF mousePos)
        {
            if (splinePoints == null) return -1;
            float minDistance = float.MaxValue;
            int nearestNodeIndex = -1;
            for(int i = 0; i < splinePoints[0].Count; i++)
            {
                float distance = getDistanceToMouse(i, mousePos);
                if(distance < minDistance)
                {
                    nearestNodeIndex = i;
                    minDistance = distance;
                }
            }
            if (minDistance > 30) return -1;
            return nearestNodeIndex;
        }

        public float getDistanceToMouse(int node, PointF mousePos)
        {
            if (node > splinePoints[0].Count) return float.MaxValue;
            float xDist = (splinePoints[((int)Form1.Axis.x)][node] * (float)Math.Exp(scale) + offset.X) - mousePos.X;
            float yDist = (splinePoints[((int)Form1.Axis.z)][node] * (float)Math.Exp(scale) + offset.Y) - mousePos.Y;
            return (float)Math.Sqrt(yDist * yDist + xDist * xDist);
        }

        private void OnMouseMoved(object sender, MouseEventArgs e)
        {
            mousePosHover = e.Location;
            if (isLeftMouseDown)
            {

                movePlot(lastMouseDragPosition, e.Location);

                lastMouseDragPosition = e.Location;
            }
            renderSpline();
        }
        private void OnMousePressed(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isLeftMouseDown = true;
                lastMouseDragPosition = e.Location;
                leftButtonStopwatch.Restart();
            }
            if(e.Button == MouseButtons.Right)
            {
                leftButtonStopwatch.Restart();
            }
            if (e.Button == MouseButtons.Middle)
                AutoScale();
        }
        private void OnMouseReleased(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isLeftMouseDown = false;
                if (leftButtonStopwatch.ElapsedMilliseconds < 200)
                {
                    AddPointAt(e.Location);
                    leftButtonStopwatch.Reset();
                }
            }
            if (e.Button == MouseButtons.Right && rightButtonStopwatch.ElapsedMilliseconds < 200)
            {
                RemovePointAt(e.Location);
                rightButtonStopwatch.Reset();
            }
        }
        #endregion

        #region Data
        public void setSplinePoints(List<float>[] splinePoints)
        {
            this.splinePoints = splinePoints;
            initializeSplitPoints();
            AutoScale();
            renderSpline();
        }
        public void setRoundTrip(bool flag)
        {
            roundTrip = flag;
            renderSpline();
        }
        private void initializeSplitPoints()
        {
            splitPoints = new List<int>() { 0, splinePoints.Length};
        }
        public void setSplitPoints(List<int> splitPoints)
        {
            this.splitPoints = new List<int>(splitPoints);
            renderSpline();
        }
        public List<int> getSplitPoints()
        {
            int[] copy = new int[splitPoints.Count];
            splitPoints.CopyTo(copy);
            return copy.ToList();
        }
        #endregion

        #region Viewport
        private void AutoScale()
        {
            if (splinePoints == null) return;
            findDelta(splinePoints[((int)Form1.Axis.x)], out float xDelta, out float xOffset);
            float xScale = (float)Math.Log((Width)/ (xDelta));
            findDelta(splinePoints[((int)Form1.Axis.z)], out float yDelta, out float yOffset);
            float yScale = (float)Math.Log((Height)/(yDelta));

            scale = Math.Min(yScale, xScale);

            offset.X = -xOffset *(float)Math.Exp(scale) + Width/2;
            offset.Y = -yOffset *(float)Math.Exp(scale) + Height/2;
            renderSpline();
        }
        private void findDelta(List<float> values, out float delta, out float offset)
        {
            float max = float.MinValue;
            foreach(float value in values)
            {
                if (value > max)
                {
                    max = value;
                }
            }
            float min = float.MaxValue;
            foreach (float value in values)
            {
                if (value < min)
                {
                    min = value;
                }
            }
            delta = Math.Abs(max - min);
            offset = (max + min)/2;
        }
        private void DoPaint(object sender, PaintEventArgs e)
        {
            if (splinePoints == null || splitPoints == null) return;

            Pen p1 = new Pen(Color.LightGreen, 2);
            Pen p2 = new Pen(Color.Red, 2);
            Pen nodePen = new Pen(Color.White, 2);
            Pen ghostPen = new Pen(Color.LightBlue, 2);

            Pen currentPen = p1;
           
            for (int i = 0; i < splitPoints.Count - 1; i++)
            {
                int from = splitPoints[i];
                int to = splitPoints[i + 1];
                bool last = (i + 1 >= splitPoints.Count - 1) && roundTrip;

                List<PointF> pointsTop = new List<PointF>();
                for (int j = from; j <= to; j++)
                {
                    float x = splinePoints[((int)Form1.Axis.x)][j] * (float)Math.Exp(scale) + offset.X;
                    float y = splinePoints[((int)Form1.Axis.z)][j] * (float)Math.Exp(scale) + offset.Y;

                    pointsTop.Add(new PointF(x, y));
                }
                if(last)
                {
                    float x = splinePoints[((int)Form1.Axis.x)][0] * (float)Math.Exp(scale) + offset.X;
                    float y = splinePoints[((int)Form1.Axis.z)][0] * (float)Math.Exp(scale) + offset.Y;

                    pointsTop.Add(new PointF(x, y));
                }

                e.Graphics.DrawLines(currentPen, pointsTop.ToArray());

                if (roundTrip)
                {
                    float startX = splinePoints[((int)Form1.Axis.x)][0] * (float)Math.Exp(scale) + offset.X;
                    float startY = splinePoints[((int)Form1.Axis.z)][0] * (float)Math.Exp(scale) + offset.Y;
                    e.Graphics.DrawEllipse(nodePen, startX - 2, startY - 2, 4, 4);
                }

                //Ghost
                int node = mousePositionToNode(mousePosHover);
                if (node >= 0)
                {
                    float nodeX = splinePoints[((int)Form1.Axis.x)][node] * (float)Math.Exp(scale) + offset.X;
                    float nodeY = splinePoints[((int)Form1.Axis.z)][node] * (float)Math.Exp(scale) + offset.Y;
                    e.Graphics.DrawEllipse(ghostPen, nodeX - 2, nodeY - 2, 4, 4);
                }

                if (currentPen == p1)
                    currentPen = p2;
                else currentPen = p1;
            }
        }
        private void movePlot(Point oldPoint, Point newPoint)
        {
            offset.X += newPoint.X - oldPoint.X;
            offset.Y += newPoint.Y - oldPoint.Y;
            renderSpline();
        }
        private void renderSpline()
        {
            Invalidate();
        }
        private void OnZoom(object sender, MouseEventArgs e)
        {
            adjustZoom(e.Delta, e.Location);
        }
        private void adjustZoom(int delta, Point mousePosition)
        {
            if (Math.Exp(scale + zoomSensitivity * delta) > 0) //Exp makes a more linear zoom
            {
                float oldScale = scale;
                scale += zoomSensitivity * delta;

                offset.X = mousePosition.X - (mousePosition.X - offset.X) * (float)Math.Exp(scale) / (float)Math.Exp(oldScale);
                offset.Y = mousePosition.Y - (mousePosition.Y - offset.Y) * (float)Math.Exp(scale) / (float)Math.Exp(oldScale);

                renderSpline();
            }
        }
        #endregion

    }
}
