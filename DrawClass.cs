using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;


namespace zadanie2vb {
    class DrawClass : formCalka {
        
        public Pen pen1 = new Pen(Color.Black, 0.05F);
        public Pen pen = new Pen(Color.Red, 1F);
        public Stopwatch sw = new Stopwatch();

        public long integralFunction(double[] fi, double[] xi, PictureBox p,double x1,double x2) {
            Graphics g = p.CreateGraphics();
            PointF[] point = new PointF[n];
            // PointF[] pointN = new PointF[n];
            var ymin = fi.Min();
            var ymax = fi.Max();

            Parallel.Invoke(() => {
                sw.Start();
                Parallel.For(0, n, i => {
                    point[i].X = (float)((xi[i] - xi[0]) * ((p.Width - 1) / (x2 - x1)));
                    point[i].Y = (float)((p.Height - 1) - (fi[i] - ymin) * ((p.Height - 1) / (ymax - ymin)));
                });
                g.DrawLines(pen, point);
                sw.Stop();
            }, () => {
                int rozpietoscX = 10;
                int rozpietoscY = 10;

                for (int y = 0; y < p.Height; y += rozpietoscY) {
                    g.DrawLine(pen1, 0, y, p.Width, y);
                }
                for (int x = 0; x < p.Width; x += rozpietoscX) {
                    g.DrawLine(pen1, x, 0, x, p.Height);
                }
            });
            return sw.ElapsedMilliseconds;
        }
        public long drawIntegralFunctionNoParallel(double[] fi, double[] xi, PictureBox p, double x1, double x2) {
            Graphics g = p.CreateGraphics();
            PointF[] pointN = new PointF[n];
            var ymin = fi.Min();
            var ymax = fi.Max();
            int rozpietoscX = 10;
            int rozpietoscY = 10;
            sw.Start();
                for (int y = 0; y < p.Height; y += rozpietoscY) {
                    g.DrawLine(pen1, 0, y, p.Width, y);
                }
                for (int x = 0; x < p.Width; x += rozpietoscX) {
                    g.DrawLine(pen1, x, 0, x, p.Height);
                }
                for (int i = 0; i < n; ++i) {
                    pointN[i].X = (float)((xi[i] - xi[0]) * ((p.Width - 1) / (x2 - x1)));
                    pointN[i].Y = (float)((p.Height - 1) - (fi[i] - ymin) * ((p.Height - 1) / (ymax - ymin)));
                }
                g.DrawLines(pen1, pointN);
                sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }
}
