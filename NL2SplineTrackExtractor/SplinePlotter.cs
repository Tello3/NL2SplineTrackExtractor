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

        private bool isMouseDown = false;
        private Point lastMouseDragPosition = Point.Empty;
        private PointF offset = Point.Empty;
        private float scale = 1;
        private const float zoomSensitivity = 0.001f;

        private bool roundTrip;

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

        private void DoPaint(object sender, PaintEventArgs e)
        {
            if (splinePoints == null || splitPoints == null) return;

            Pen p1 = new Pen(Color.LightGreen, 2);
            Pen p2 = new Pen(Color.Red, 2);
            Pen nodePen = new Pen(Color.White, 2);

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
                else
                {
                    float x = splinePoints[((int)Form1.Axis.x)][to] * (float)Math.Exp(scale) + offset.X;
                    float y = splinePoints[((int)Form1.Axis.z)][to] * (float)Math.Exp(scale) + offset.Y;

                }

                e.Graphics.DrawLines(currentPen, pointsTop.ToArray());

                if (roundTrip)
                {
                    float startX = splinePoints[((int)Form1.Axis.x)][0] * (float)Math.Exp(scale) + offset.X;
                    float startY = splinePoints[((int)Form1.Axis.z)][0] * (float)Math.Exp(scale) + offset.Y;
                    e.Graphics.DrawEllipse(nodePen, startX - 2, startY - 2, 4, 4);
                }

                if (currentPen == p1)
                    currentPen = p2;
                else currentPen = p1;
            }
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

        private void OnMouseMoved(object sender, MouseEventArgs e)
        {
            if (!isMouseDown) return;

            movePlot(lastMouseDragPosition, e.Location);

            lastMouseDragPosition = e.Location;
        }

        private void movePlot(Point oldPoint, Point newPoint)
        {
            offset.X += newPoint.X - oldPoint.X;
            offset.Y += newPoint.Y - oldPoint.Y;

            renderSpline();
        }

        private void OnMousePressed(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            isMouseDown = true;
            lastMouseDragPosition = e.Location;
        }

        private void OnMouseReleased(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isMouseDown = false;
        }

        public void setSplinePoints(List<float>[] splinePoints)
        {
            this.splinePoints = splinePoints;
            initializeSplitPoints();
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
            this.splitPoints = splitPoints;
            renderSpline();
        }

        private void renderSpline()
        {
            Invalidate();
        }
    }
}
