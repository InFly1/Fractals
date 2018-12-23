using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Solution
{
    public class Fractals
    {
        Graphics g;
        Pen p = new Pen(Color.Black);
        Random rnd = new Random();
        Color c;
        public Fractals(Graphics gg, Color color)
        {
            g = gg;
            c = color;
        }

        public void ChangeColor(Color color)
        {
            p.Color = color;
            c = color;
        }
        public void Dragon(int x1, int y1, int x2, int y2, int k)
        {
            int tx, ty;

            if (k == 0)
            {
                g.DrawLine(p, x1, y1, x2, y2);
                return;
            }

            tx = (x1 + x2) / 2 + (y2 - y1) / 2;
            ty = (y1 + y2) / 2 - (x2 - x1) / 2;

            Dragon(x2, y2, tx, ty, k - 1);
            Dragon(x1, y1, tx, ty, k - 1);
        }

        public void Triangle(Point[] a, Point b, int i)
        {
            int k = rnd.Next(0, 3);
            Point b1 = new Point(((a[k].X + b.X) / 2), ((a[k].Y + b.Y) / 2));
            g.FillRectangle(new SolidBrush(c), b1.X, b1.Y, 3, 3);
            i--;
            if (i != 0)
            {
                Triangle(a, b1, i);
            }
        }

        struct Complex
        {

            public double x;
            public double y;

        };
        public void Lumbda(int Width, int Height, int iterations)
        {
            int max = 3;
            int xc, yc;
            int x, y, n;
            double l, q;
            Complex z, c;
            xc = (Width - 10) / 2;
            yc = (Height - 10) / 2;

            for (y = -yc; y < yc; y++)
            {
                for (x = -xc; x < xc; x++)
                {
                    n = 0;
                    c.x = x * 0.01 + 1;
                    c.y = y * 0.01;

                    z.x = 0.5;
                    z.y = 0;

                    while ((z.x * z.x + z.y * z.y < max) && (n < iterations))
                    {
                        l = z.x - z.x * z.x + z.y * z.y;
                        q = z.y - 2 * z.x * z.y;
                        z.x = c.x * l - c.y * q;
                        z.y = c.x * q + c.y * l;
                        n++;
                    }
                    if (n < iterations)
                    {
                        p.Color = Color.FromArgb(255, 0, (n * 15) % 255, (n * 20) % 255);
                        g.DrawRectangle(p, xc + x, yc + y, 1, 1);
                    }

                }
            }
        }
        private float[,] func_coef = new float[4, 6]
        {
            {0,      0,      0,     0.16f, 0, 0   },
            {-0.15f, 0.28f,  0.26f, 0.24f, 0, 0.44f},
            {0.2f,  -0.26f,  0.23f, 0.22f, 0, 1.6f},
            {0.85f,  0.04f, -0.04f, 0.85f, 0, 1.6f}
        };
        private float[] probability = new float[4]
        {
            0.01f,
            0.06f,
            0.08f,
            0.85f
        };
        private const float MinX = -6;
        private const float MaxX = 6;
        private const float MinY = 0.1f;
        private const float MaxY = 10;
        public void Fern(int width, int height, int PointNumber = 200000)
        {
            int width1 = (int)(width / (MaxX - MinX));
            int height1 = (int)(height / (MaxY - MinY));
            Random rnd = new Random();

            float xtemp = 0, ytemp = 0;
            int numF = 0;

            for (int i = 1; i <= PointNumber; i++)
            {

                var num = rnd.NextDouble();
                for (int j = 0; j <= 3; j++)
                {
                    num = num - probability[j];
                    if (num <= 0)
                    {
                        numF = j;
                        break;
                    }
                }

                var x = func_coef[numF, 0] * xtemp + func_coef[numF, 1] * ytemp + func_coef[numF, 4];
                var y = func_coef[numF, 2] * xtemp + func_coef[numF, 3] * ytemp + func_coef[numF, 5];

                xtemp = x;
                ytemp = y;
                x = (int)(xtemp * width1 + width1*5);
                y = (int)(ytemp * height1 - height / 30);

                g.FillRectangle(new SolidBrush(c), x, y, 1, 1);
            }
        }

        public void Levy(int x1, int x2, int y1, int y2, int i)
        {
            if (i == 0)
            {
                g.DrawLine(p, x1, y1, x2, y2);
            }
            else
            {
                int x3 = (x1 + x2) / 2 + (y2 - y1) / 2;
                int y3 = (y1 + y2) / 2 - (x2 - x1) / 2;

                Levy( x1, x3, y1, y3, i - 1);
                Levy( x3, x2, y3, y2, i - 1);
            }
        }
    }
}
