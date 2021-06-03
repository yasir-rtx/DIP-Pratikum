using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Image14
{
    public partial class Form1 : Form
    {
        Bitmap objek;
        Bitmap objbitmap;

        public Form1()
        {
            InitializeComponent();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objek = new Bitmap(pictureBox2.Image);
            DialogResult d = saveFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                objek.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gaussianToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            objbitmap = new Bitmap(objek);
            Random random = new Random();
            int n = Convert.ToInt16(textBox1.Text);

            for (int x = 0; x < objek.Width; x++)
            {
                for (int y = 0; y < objek.Height; y++)
                {
                    Color c = objbitmap.GetPixel(x, y);
                    int newRandom = random.Next(0, 100);

                    if (newRandom < n)
                    {
                        int noise = random.Next(0, 256) - 128;
                        int r = (int)(c.R + noise);
                        if (r < 0) r = 0;
                        if (r > 255) r = 255;

                        int g = (int)(c.G + noise);
                        if (g < 0) g = 0;
                        if (g > 255) g = 255;

                        int b = (int)(c.B + noise);
                        if (b < 0) b = 0;
                        if (b > 255) b = 255;

                        Color cn = Color.FromArgb(r, g, b);
                        objbitmap.SetPixel(x, y, cn);
                    }
                }
            }
            pictureBox2.Image = objbitmap;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                objek = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = objek;
            }
        }

        private void speckleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objbitmap = new Bitmap(objek);
            Random random = new Random();
            int n = Convert.ToInt16(textBox1.Text);

            for (int x = 0; x < objek.Width; x++)
            {
                for (int y = 0; y < objek.Height; y++)
                {
                    Color c = objbitmap.GetPixel(x, y);
                    int newRandom = random.Next(0, 100);

                    int r = c.R;
                    int g = c.G;
                    int b = c.B;

                    if (newRandom < n) r = 0;
                    if (newRandom < n) g = 0;
                    if (newRandom < n) b = 0;

                    Color cn = Color.FromArgb(r, g, b);
                    objbitmap.SetPixel(x, y, cn);
                }
            }
            pictureBox2.Image = objbitmap;
        }

        private void saltPepperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objbitmap = new Bitmap(objek);
            Random random = new Random();
            int n = Convert.ToInt16(textBox1.Text);

            for (int x = 0; x < objek.Width; x++)
            {
                for (int y = 0; y < objek.Height; y++)
                {
                    Color c = objbitmap.GetPixel(x, y);
                    int newRandom = random.Next(0, 100);

                    int r = c.R;
                    int g = c.G;
                    int b = c.B;

                    if (newRandom < n) r = 255;
                    if (newRandom < n) g = 255;
                    if (newRandom < n) b = 255;

                    Color cn = Color.FromArgb(r, g, b);
                    objbitmap.SetPixel(x, y, cn);
                }
            }
            pictureBox2.Image = objbitmap;
        }

        private void ratarataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objbitmap = new Bitmap(objek);
            for (int x = 1; x < objek.Width - 1; x++)
            {
                for (int y = 1; y < objek.Height - 1; y++)
                {
                    Color c1 = objek.GetPixel(x - 1, y - 1);
                    Color c2 = objek.GetPixel(x, y - 1);
                    Color c3 = objek.GetPixel(x + 1, y - 1);
                    Color c4 = objek.GetPixel(x - 1, y);
                    Color c5 = objek.GetPixel(x, y);
                    Color c6 = objek.GetPixel(x + 1, y);
                    Color c7 = objek.GetPixel(x - 1, y + 1);
                    Color c8 = objek.GetPixel(x, y + 1);
                    Color c9 = objek.GetPixel(x + 1, y + 1);

                    // Red
                    int r = (int)((c1.R + c2.R + c3.R + c4.R + c5.R + c6.R + c7.R + c8.R + c9.R) / 9);
                    if (r < 0) r = 0;
                    if (r > 255) r = 255;

                    // Green
                    int g = (int)((c1.G + c2.G + c3.G + c4.G + c5.G + c6.G + c7.G + c8.G + c9.G) / 9);
                    if (g < 0) g = 0;
                    if (g > 255) g = 255;

                    // Blue
                    int b = (int)((c1.B + c2.B + c3.B + c4.B + c5.B + c6.B + c7.B + c8.B + c9.B) / 9);
                    if (b < 0) b = 0;
                    if (b > 255) b = 255;

                    Color cn = Color.FromArgb(r, g, b);
                    objbitmap.SetPixel(x, y, cn);
                }
            }
            pictureBox2.Image = objbitmap;
        }

        private void gaussianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objbitmap = new Bitmap(objek);
            for (int x = 1; x < objek.Width - 1; x++)
            {
                for (int y = 1; y < objek.Height - 1; y++)
                {
                    Color c1 = objek.GetPixel(x - 1, y - 1);
                    Color c2 = objek.GetPixel(x, y - 1);
                    Color c3 = objek.GetPixel(x + 1, y - 1);
                    Color c4 = objek.GetPixel(x - 1, y);
                    Color c5 = objek.GetPixel(x, y);
                    Color c6 = objek.GetPixel(x + 1, y);
                    Color c7 = objek.GetPixel(x - 1, y + 1);
                    Color c8 = objek.GetPixel(x, y + 1);
                    Color c9 = objek.GetPixel(x + 1, y + 1);

                    // Red
                    int r = (int)((c1.R + c2.R + c3.R + c4.R + (4 * c5.R) + c6.R + c7.R + c8.R + c9.R) / 9);
                    if (r < 0) r = 0;
                    if (r > 255) r = 255;

                    // Green
                    int g = (int)((c1.G + c2.G + c3.G + c4.G + (4 * c5.G) + c6.G + c7.G + c8.G + c9.G) / 9);
                    if (g < 0) g = 0;
                    if (g > 255) g = 255;

                    // Blue
                    int b = (int)((c1.B + c2.B + c3.B + c4.B + (4 * c5.B) + c6.B + c7.B + c8.B + c9.B) / 9);
                    if (b < 0) b = 0;
                    if (b > 255) b = 255;

                    Color cn = Color.FromArgb(r, g, b);
                    objbitmap.SetPixel(x, y, cn);
                }
            }
            pictureBox2.Image = objbitmap;
        }

        private void medianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objbitmap = new Bitmap(objek);
            int[] r = new int[10];
            int[] g = new int[10];
            int[] b = new int[10];

            for (int x = 1; x < objek.Width - 1; x++)
            {
                for (int y = 1; y < objek.Height - 1; y++)
                {
                    Color c1 = objek.GetPixel(x - 1, y - 1);
                    Color c2 = objek.GetPixel(x, y - 1);
                    Color c3 = objek.GetPixel(x + 1, y - 1);
                    Color c4 = objek.GetPixel(x - 1, y);
                    Color c5 = objek.GetPixel(x, y);
                    Color c6 = objek.GetPixel(x + 1, y);
                    Color c7 = objek.GetPixel(x - 1, y + 1);
                    Color c8 = objek.GetPixel(x, y + 1);
                    Color c9 = objek.GetPixel(x + 1, y + 1);

                    r[1] = c1.R; g[1] = c1.G; b[1] = c1.B;
                    r[2] = c2.R; g[2] = c2.G; b[2] = c2.B;
                    r[3] = c3.R; g[3] = c3.G; b[3] = c3.B;
                    r[4] = c4.R; g[4] = c4.G; b[4] = c4.B;
                    r[5] = c5.R; g[5] = c5.G; b[5] = c5.B;
                    r[6] = c6.R; g[6] = c6.G; b[6] = c6.B;
                    r[7] = c7.R; g[7] = c7.G; b[7] = c7.B;
                    r[8] = c8.R; g[8] = c8.G; b[8] = c8.B;
                    r[9] = c9.R; g[9] = c9.G; b[9] = c9.B;

                    for (int i = 1; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            if (r[j] > r[j+1])
                            {
                                int a = r[j];
                                r[j] = r[j + 1];
                                r[j + 1] = a;
                            }

                            if (g[j] > g[j + 1])
                            {
                                int a = g[j];
                                g[j] = g[j + 1];
                                g[j + 1] = a;
                            }

                            if (b[j] > b[j + 1])
                            {
                                int a = b[j];
                                b[j] = b[j + 1];
                                b[j + 1] = a;
                            }
                        }
                    }

                    int rn = r[5];
                    int gn = g[5];
                    int bn = b[5];

                    Color cn = Color.FromArgb(rn, gn, bn);
                    objbitmap.SetPixel(x, y, cn);
                }
            }
            pictureBox2.Image = objbitmap;
        }

        private void robertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objbitmap = new Bitmap(objek);
            for (int x = 0; x < objek.Width - 1; x++)
            {
                for (int y = 0; y < objek.Height - 1; y ++)
                {
                    // horizontal
                    Color c1 = objbitmap.GetPixel(x + 1, y + 1);
                    Color c2 = objbitmap.GetPixel(x, y);
                    // vertical
                    Color c3 = objbitmap.GetPixel(x + 1, y);
                    Color c4 = objbitmap.GetPixel(x, y + 1);

                    // Red
                    int r = (int)((c2.R - c1.R) + (c4.R + c3.R));
                    if (r < 0) r = -r;
                    if (r > 255) r = 255;

                    // Green
                    int g = (int)((c2.G - c1.G) + (c4.G + c3.G));
                    if (g < 0) g = -g;
                    if (g > 255) g = 255;

                    // Blue
                    int b = (int)((c2.B - c1.B) + (c4.B + c3.B));
                    if (b < 0) b = -b;
                    if (b > 255) b = 255;

                    Color cn = Color.FromArgb(r, g, b);
                    objbitmap.SetPixel(x, y, cn);
                }
            }
            pictureBox2.Image = objbitmap;
        }

        private void prewittToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objbitmap = new Bitmap(objek);
            for (int x = 1; x < objek.Width - 1; x++)
            {
                for (int y = 1; y < objek.Height - 1; y++)
                {
                    Color c1 = objek.GetPixel(x - 1, y - 1);
                    Color c2 = objek.GetPixel(x, y - 1);
                    Color c3 = objek.GetPixel(x + 1, y - 1);
                    Color c4 = objek.GetPixel(x - 1, y);
                    Color c5 = objek.GetPixel(x, y);
                    Color c6 = objek.GetPixel(x + 1, y);
                    Color c7 = objek.GetPixel(x - 1, y + 1);
                    Color c8 = objek.GetPixel(x, y + 1);
                    Color c9 = objek.GetPixel(x + 1, y + 1);

                    // Horiozontal
                    int rh = (int)(-c1.R - c4.R - c7.R + c3.R + c6.R + c9.R);
                    int gh = (int)(-c1.G - c4.G - c7.G + c3.G + c6.G + c9.G);
                    int bh = (int)(-c1.B - c4.B - c7.B + c3.B + c6.B + c9.B);

                    // Vertical
                    int rv = (int)(-c1.R - c2.R - c3.R + c7.R + c8.R + c9.R);
                    int gv = (int)(-c1.G - c2.G - c3.G + c7.G + c8.G + c9.G);
                    int bv = (int)(-c1.B - c2.B - c3.B + c7.B + c8.B + c9.B);

                    int r = rh + rv;
                    int g = gh + gv;
                    int b = bh + bv;

                    if (r < 0) r = -r;
                    if (g < 0) g = -g;
                    if (b < 0) b = -b;
                    if (r > 255) r = 255;
                    if (g > 255) g = 255;
                    if (b > 255) b = 255;

                    Color cn = Color.FromArgb(r, g, b);
                    objbitmap.SetPixel(x, y, cn);
                }
            }
            pictureBox2.Image = objbitmap;
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objbitmap = new Bitmap(objek);
            for (int x = 1; x < objek.Width - 1; x++)
            {
                for (int y = 1; y < objek.Height - 1; y++)
                {
                    Color c1 = objek.GetPixel(x - 1, y - 1);
                    Color c2 = objek.GetPixel(x, y - 1);
                    Color c3 = objek.GetPixel(x + 1, y - 1);
                    Color c4 = objek.GetPixel(x - 1, y);
                    Color c5 = objek.GetPixel(x, y);
                    Color c6 = objek.GetPixel(x + 1, y);
                    Color c7 = objek.GetPixel(x - 1, y + 1);
                    Color c8 = objek.GetPixel(x, y + 1);
                    Color c9 = objek.GetPixel(x + 1, y + 1);

                    // Horiozontal
                    int rh = (int)(-c1.R - (2 * c4.R) - c7.R + c3.R + (2 * c6.R) + c9.R);
                    int gh = (int)(-c1.G - (2 * c4.G) - c7.G + c3.G + (2 * c6.G) + c9.G);
                    int bh = (int)(-c1.B - (2 * c4.B) - c7.B + c3.B + (2 * c6.B) + c9.B);

                    // Vertical
                    int rv = (int)(-c1.R - (2 * c2.R) - c3.R + c7.R + (2 * c8.R) + c9.R);
                    int gv = (int)(-c1.G - (2 * c2.G) - c3.G + c7.G + (2 * c8.G) + c9.G);
                    int bv = (int)(-c1.B - (2 * c2.B) - c3.B + c7.B + (2 * c8.B) + c9.B);

                    int r = rh + rv;
                    int g = gh + gv;
                    int b = bh + bv;

                    if (r < 0) r = -r;
                    if (g < 0) g = -g;
                    if (b < 0) b = -b;
                    if (r > 255) r = 255;
                    if (g > 255) g = 255;
                    if (b > 255) b = 255;

                    Color cn = Color.FromArgb(r, g, b);
                    objbitmap.SetPixel(x, y, cn);
                }
            }
            pictureBox2.Image = objbitmap;
        }

        private void laplacianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objbitmap = new Bitmap(objek);
            for (int x = 1; x < objek.Width - 1; x++)
            {
                for (int y = 1; y < objek.Height - 1; y++)
                {
                    Color c1 = objek.GetPixel(x - 1, y - 1);
                    Color c2 = objek.GetPixel(x, y - 1);
                    Color c3 = objek.GetPixel(x + 1, y - 1);
                    Color c4 = objek.GetPixel(x - 1, y);
                    Color c5 = objek.GetPixel(x, y);
                    Color c6 = objek.GetPixel(x + 1, y);
                    Color c7 = objek.GetPixel(x - 1, y + 1);
                    Color c8 = objek.GetPixel(x, y + 1);
                    Color c9 = objek.GetPixel(x + 1, y + 1);

                    int r = (int)(c1.R + (-2 * c2.R) + c3.R + (-2 * c4.R) + (4 * c5.R) + (-2 * c6.R) + c7.R + (-2 * c8.R) + c9.R);
                    int g = (int)(c1.G + (-2 * c2.G) + c3.G + (-2 * c4.G) + (4 * c5.G) + (-2 * c6.G) + c7.G + (-2 * c8.G) + c9.G);
                    int b = (int)(c1.B + (-2 * c2.B) + c3.B + (-2 * c4.B) + (4 * c5.B) + (-2 * c6.B) + c7.B + (-2 * c8.B) + c9.B);

                    if (r < 0) r = -r;
                    if (g < 0) g = -g;
                    if (b < 0) b = -b;
                    if (r > 255) r = 255;
                    if (g > 255) g = 255;
                    if (b > 255) b = 255;

                    Color cn = Color.FromArgb(r, g, b);
                    objbitmap.SetPixel(x, y, cn);
                }
            }
            pictureBox2.Image = objbitmap;
        }

        private void sharpnessToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            objbitmap = new Bitmap(objek);
            for (int x = 1; x < objek.Width - 1; x++)
            {
                for (int y = 1; y < objek.Height - 1; y++)
                {
                    Color c = objbitmap.GetPixel(x, y);

                    Color c1 = objek.GetPixel(x - 1, y - 1);
                    Color c2 = objek.GetPixel(x, y - 1);
                    Color c3 = objek.GetPixel(x + 1, y - 1);
                    Color c4 = objek.GetPixel(x - 1, y);
                    Color c5 = objek.GetPixel(x, y);
                    Color c6 = objek.GetPixel(x + 1, y);
                    Color c7 = objek.GetPixel(x - 1, y + 1);
                    Color c8 = objek.GetPixel(x, y + 1);
                    Color c9 = objek.GetPixel(x + 1, y + 1);

                    int rt1 = (int)((c1.R + c2.R + c3.R + c4.R + c5.R + c6.R + c7.R + c8.R + c9.R) / 9);
                    int rt2 = (int)(-c1.R - (2 * c4.R) - c7.R + c3.R + (2 * c6.R) + c9.R);
                    int rt3 = (int)(-c1.R - (2 * c4.R) - c7.R + c3.R + (2 * c6.R) + c9.R);

                    int gt1 = (int)((c1.G + c2.G + c3.G + c4.G + c5.G + c6.G + c7.G + c8.G + c9.G) / 9);
                    int gt2 = (int)(-c1.G - (2 * c4.G) - c7.G + c3.G + (2 * c6.G) + c9.G);
                    int gt3 = (int)(-c1.G - (2 * c4.G) - c7.G + c3.G + (2 * c6.G) + c9.G);

                    int bt1 = (int)((c1.B + c2.B + c3.B + c4.B + c5.B + c6.B + c7.B + c8.B + c9.B) / 9);
                    int bt2 = (int)(-c1.B - (2 * c4.B) - c7.B + c3.B + (2 * c6.B) + c9.B);
                    int bt3 = (int)(-c1.B - (2 * c4.B) - c7.B + c3.B + (2 * c6.B) + c9.B);

                    int r = rt1 + rt2 + rt3;
                    int g = gt1 + gt2 + gt3;
                    int b = bt1 + bt2 + bt3;

                    if (r < 0) r = -r;
                    if (g < 0) g = -g;
                    if (b < 0) b = -b;
                    if (r > 255) r = 255;
                    if (g > 255) g = 255;
                    if (b > 255) b = 255;

                    Color cn = Color.FromArgb(r, g, b);
                    objbitmap.SetPixel(x, y, cn);
                }
            }
            pictureBox2.Image = objbitmap;
        }
    }
}
