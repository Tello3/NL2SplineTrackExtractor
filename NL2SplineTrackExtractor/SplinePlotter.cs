using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NL2SplineTrackExtractor
{
    public partial class SplinePlotter : UserControl
    {

        public List<float>[] splinePoints;
        public List<int> splitPoints;

        public bool isMouseDown;
        public Point lastMouseDragPosition = Point.Empty;
        public PointF offset = Point.Empty;
        public float scale = 1;
        public const float scaleSensitivity = 0.001f;

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
            if (splinePoints == null) return;

            Pen p = new Pen(Color.LightGreen, 2);
            List<PointF> pointsTop = new List<PointF>();
            for(int i = 0; i < splinePoints[0].Count; i++)
            {
                float x = splinePoints[((int)Form1.Axis.x)][i] * (float)Math.Exp(scale) + offset.X;
                float y = splinePoints[((int)Form1.Axis.z)][i] * (float)Math.Exp(scale) + offset.Y;

                pointsTop.Add(new PointF(x, y));
            }
            e.Graphics.DrawLines(p, pointsTop.ToArray());
        }

        private void OnZoom(object sender, MouseEventArgs e)
        {
            adjustZoom(e.Delta, e.Location);
        }

        private void adjustZoom(int delta, Point mousePosition)
        {
            if (Math.Exp(scale + scaleSensitivity * delta) > 0)
            {
                float oldScale = scale;
                scale += scaleSensitivity * delta;

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

        private void initializeSplitPoints()
        {
            splitPoints = new List<int>() { 0, splinePoints.Length};
        }
        public void setSplitPoints(List<int> splitPoints)
        {
            this.splitPoints = splitPoints;
        }

        private void renderSpline()
        {
            Invalidate();
        }
    }
}
