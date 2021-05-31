using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image13
{
    public partial class Form1 : Form
    {
        Bitmap objek;
        Bitmap objbitmap;
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                objbitmap = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = objbitmap;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = hScrollBar1.Value;
            objek = new Bitmap(objbitmap);

            for (int x = 0; x < objek.Width; x++)
            {
                for (int y = 0; y < objek.Height; y++)
                {
                    Color c = objbitmap.GetPixel(x, y);
                    int r = c.R + a;
                    int g = c.G + a;
                    int b = c.B + a;

                    if (r < 0) r = 0;
                    if (r > 255) r = 255;
                    if (g < 0) g = 0;
                    if (g > 255) g = 255;
                    if (b < 0) b = 0;
                    if (b > 255) b = 255;

                    Color cn = Color.FromArgb(r, g, b);
                    objek.SetPixel(x, y, cn);
                }
            }
            pictureBox2.Image = objek;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            float a = (float)(hScrollBar2.Value / 100.0);
            button2.Text = a.ToString();
            objek = new Bitmap(objbitmap);
            for (int x = 0; x < objek.Width; x++)
            {
                for (int y = 0; y < objek.Height; y++)
                {
                    Color c = objbitmap.GetPixel(x, y);

                    int r = (int)(a * (float)c.R);
                    int g = (int)(a * (float)c.G);
                    int b = (int)(a * (float)c.B);

                    if (r < 0) r = 0;
                    if (r > 255) r = 255;
                    if (g < 0) g = 0;
                    if (g > 255) g = 255;
                    if (b < 0) b = 0;
                    if (b > 255) b = 255;

                    Color cn = Color.FromArgb(r, g, b);
                    objek.SetPixel(x, y, cn);
                }
            }
            pictureBox2.Image = objek;
            hScrollBar2.Value = 100;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            objek = new Bitmap(objbitmap);
            for (int x = 0; x < objek.Width; x++)
            {
                for (int y = 0; y < objek.Height; y++)
                {
                    Color c = objbitmap.GetPixel(x, y);

                    int r = (int)(255 - c.R);
                    int g = (int)(255 - c.G);
                    int b = (int)(255 - c.B);

                    Color rgb = Color.FromArgb(r, g, b);
                    objek.SetPixel(x, y, rgb);
                }
            }
            pictureBox2.Image = objek;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int rmin = 255, gmin = 255, bmin = 255;
            int rmax = 0, gmax = 0, bmax = 0;
            objek = new Bitmap(objbitmap);
            for (int x = 0; x < objek.Width; x++)
            {
                for (int y = 0; y < objek.Height; y++)
                {
                    Color c = objbitmap.GetPixel(x, y);

                    int r = c.R;
                    int g = c.G;
                    int b = c.B;

                    if (r < rmin) rmin = r;
                    if (r > rmax) rmax = r;

                    if (g < gmin) gmin = g;
                    if (g > gmax) gmax = g;

                    if (b < bmin) bmin = b;
                    if (b > bmax) bmax = b;
                }
            }

            for (int x = 0; x < objek.Width; x++)
            {
                for (int y = 0; y < objek.Height; y++)
                {
                    Color c = objbitmap.GetPixel(x, y);

                    int r = c.R;
                    int g = c.G;
                    int b = c.B;

                    int rn = (int)(255 * (r - rmin) / (rmax - rmin));
                    int gn = (int)(255 * (g - gmin) / (gmax - gmin));
                    int bn = (int)(255 * (b - bmin) / (bmax - bmin));

                    Color rgb = Color.FromArgb(rn, gn, bn);
                    objek.SetPixel(x, y, rgb);
                }
            }
            pictureBox2.Image = objek;
        }
    }
}
