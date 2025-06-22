using System;
using System.Drawing;
using System.Windows.Forms;

namespace BezierAndKochApp
{
    public partial class Form1 : Form
    {
        bool drawBezier = false;
        bool drawKoch = false;
        int kochLevel = 3;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            // Події кнопок
            buttonBezier.Click += (s, e) =>
            {
                drawBezier = true;
                drawKoch = false;
                Invalidate(); // перемалювати форму
            };

            buttonKoch.Click += (s, e) =>
            {
                drawKoch = true;
                drawBezier = false;
                Invalidate();
            };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            if (drawBezier)
                DrawBezier(g);
            else if (drawKoch)
                DrawKochSnowflake(g, kochLevel);
        }

        // ---------- Крива Без’є ----------
        void DrawBezier(Graphics g)
        {
            PointF P1 = new PointF(100, 300);
            PointF P2 = new PointF(150, 100);
            PointF P3 = new PointF(250, 100);
            PointF P4 = new PointF(300, 300);

            Pen bezierPen = new Pen(Color.Blue, 2);
            PointF prev = P1;

            for (float t = 0; t <= 1; t += 0.01f)
            {
                PointF pt = GetBezierPoint(t, P1, P2, P3, P4);
                g.DrawLine(bezierPen, prev, pt);
                prev = pt;
            }

            // Допоміжні лінії
            Pen controlPen = new Pen(Color.Gray, 1);
            g.DrawLines(controlPen, new PointF[] { P1, P2, P3, P4 });

            // Точки
            Brush pointBrush = Brushes.Red;
            foreach (var pt in new[] { P1, P2, P3, P4 })
                g.FillEllipse(pointBrush, pt.X - 3, pt.Y - 3, 6, 6);
        }

        PointF GetBezierPoint(float t, PointF p0, PointF p1, PointF p2, PointF p3)
        {
            float x = (float)(Math.Pow(1 - t, 3) * p0.X +
                              3 * Math.Pow(1 - t, 2) * t * p1.X +
                              3 * (1 - t) * t * t * p2.X +
                              t * t * t * p3.X);
            float y = (float)(Math.Pow(1 - t, 3) * p0.Y +
                              3 * Math.Pow(1 - t, 2) * t * p1.Y +
                              3 * (1 - t) * t * t * p2.Y +
                              t * t * t * p3.Y);
            return new PointF(x, y);
        }

        // ---------- Фрактал Коха ----------
        void DrawKochSnowflake(Graphics g, int level)
        {
            PointF A = new PointF(100, 300);
            PointF B = new PointF(300, 300);
            PointF C = new PointF(200, 100);

            Pen pen = new Pen(Color.Green, 1);
            DrawKoch(g, A, B, level, pen);
            DrawKoch(g, B, C, level, pen);
            DrawKoch(g, C, A, level, pen);
        }

        void DrawKoch(Graphics g, PointF A, PointF B, int level, Pen pen)
        {
            if (level == 0)
            {
                g.DrawLine(pen, A, B);
                return;
            }

            PointF C = new PointF(
                A.X + (B.X - A.X) / 3,
                A.Y + (B.Y - A.Y) / 3);
            PointF D = new PointF(
                A.X + 2 * (B.X - A.X) / 3,
                A.Y + 2 * (B.Y - A.Y) / 3);

            float dx = D.X - C.X;
            float dy = D.Y - C.Y;
            PointF E = new PointF(
                (float)(C.X + dx * Math.Cos(-Math.PI / 3) - dy * Math.Sin(-Math.PI / 3)),
                (float)(C.Y + dx * Math.Sin(-Math.PI / 3) + dy * Math.Cos(-Math.PI / 3)));

            DrawKoch(g, A, C, level - 1, pen);
            DrawKoch(g, C, E, level - 1, pen);
            DrawKoch(g, E, D, level - 1, pen);
            DrawKoch(g, D, B, level - 1, pen);
        }

        private void buttonKoch_Click(object sender, EventArgs e)
        {

        }
    }
}
