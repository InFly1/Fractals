using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Solution;

namespace _6_25_fractals
{
    public partial class Form1 : Form
    {
        Graphics g;
        Bitmap bmp;
        Color back_ground;
        Color front;
        Fractals fractals;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            fractals = new Fractals(g, Color.Black);
            back_ground = Color.White;
            front = Color.Black;
        }

        private void Dragon_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(Dragon_N.Text);
            if (n <= 15)
            {
                g.Clear(back_ground);
                int x1 = pictureBox1.Width / 3,
                y1 = pictureBox1.Height / 3,
                x2 = pictureBox1.Width /2 + 100,
                y2 = pictureBox1.Height/2 + 100;
                fractals.Dragon(x1, y1, x2, y2, 20);
                pictureBox1.Image = bmp;
            }
            else
            {
                MessageBox.Show("Введите меньшее значение шагов");
            }
        }

        private void FrontColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                front = colorDialog1.Color;
            fractals.ChangeColor(front);
        }

        private void BColor_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
                back_ground = colorDialog2.Color;
        }

        private void Triangle_Click(object sender, EventArgs e)
        {
            g.Clear(back_ground);
            Point[] a = new Point[3];
            a[0] = new Point(0, pictureBox1.Height/2);
            a[1] = new Point(pictureBox1.Width/2, 0);
            a[2] = new Point(pictureBox1.Width, pictureBox1.Height / 2);
            Point b = new Point(100, 125);

            fractals.Triangle(a, b, 6000);
            pictureBox1.Image = bmp;
        }

        private void Lumbda_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(Lumbda_N.Text);
            g.Clear(back_ground);
            fractals.Lumbda(pictureBox1.Width, pictureBox1.Height, n);
            pictureBox1.Image = bmp;
            fractals.ChangeColor(front);
        }

        private void Paporotnik_Click(object sender, EventArgs e)
        {
            g.Clear(back_ground);
            fractals.Fern(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
        }

        private void Levy_Click(object sender, EventArgs e)
        {
            g.Clear(back_ground);
            
            int i = Convert.ToInt32(Levy_N.Text);
            if (i <= 20)
            {
                fractals.Levy(250, 400, 160, 160, i);
                fractals.Levy(400, 400, 160, 310, i);
                fractals.Levy(400, 250, 310, 310, i);
                fractals.Levy(250, 250, 310, 160, i);
                pictureBox1.Image = bmp;
            }
            else
            {
                MessageBox.Show("Введите меньшее значение шагов");
            }
            
        }
    }
}
