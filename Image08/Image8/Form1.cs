using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image8
{
    public partial class Form1 : Form
    {
        Bitmap objek;
        Bitmap objek4;
        Bitmap objek8;


        public Form1()
        {
            InitializeComponent();
        }

        // load
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                objek = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = objek;
            }
        }

        // Grayscale
        private void button2_Click(object sender, EventArgs e)
        {
            objek = new Bitmap(openFileDialog1.FileName);
            for (int i = 0; i < objek.Width; i++)
            {
                for (int j = 0; j < objek.Height; j++)
                {
                    Color c = objek.GetPixel(i, j);
                    int xg = (int)(c.R + c.G + c.B) / 3;
                    Color nC = Color.FromArgb(xg, xg, xg);
                    objek.SetPixel(i, j, nC);
                }
            }
            pictureBox1.Image = objek;
        }

        // Filter 4 Node
        private void button3_Click(object sender, EventArgs e)
        {
            /*
             *     |  0   0.2   0  |
             * H = | 0.2  0.2  0.2 |
             *     |  0   0.2   0  |
             *     
             */

            float[] a = new float[5];
            // Inisiasi a[0...4] dengan 0.2
            for (int i = 0; i < 5; i++) a[i] = (float)0.2;

            objek4 = new Bitmap(objek);

            for (int x = 1; x < objek.Width-1; x++)
            {
                for (int y = 1; y < objek.Height-1; y++)
                {
                    // Membaca warna matrix 4 node
                    Color c0 = objek4.GetPixel(x, y);
                    Color c1 = objek4.GetPixel(x - 1, y);
                    Color c2 = objek4.GetPixel(x + 1, y);
                    Color c3 = objek4.GetPixel(x, y - 1);
                    Color c4 = objek4.GetPixel(x, y + 1);

                    // Grayscale c[1...4]
                    int x0 = (int)(c0.R + c0.G + c0.B) / 3;
                    int x1 = (int)(c1.R + c1.G + c1.B) / 3;
                    int x2 = (int)(c2.R + c2.G + c2.B) / 3;
                    int x3 = (int)(c3.R + c3.G + c3.B) / 3;
                    int x4 = (int)(c4.R + c4.G + c4.B) / 3;

                    // Initaite Filtering 4
                    int xb = (int)(a[0] *x0 + a[1] * x1 + a[2] * x2 + a[3] * x3 + a[3] * x4);
                    if (xb < 0) xb = 0;
                    if (xb > 255) xb = 255;

                    Color color = Color.FromArgb(xb, xb, xb);
                    objek4.SetPixel(x, y, color);
                }
            }
            pictureBox2.Image = objek4;
        }

        // Filter 8 Node
        private void button4_Click(object sender, EventArgs e)
        {
            /*
             *     | 0.1  0.1  0.1 |
             * H = | 0.1  0.2  0.1 |
             *     | 0.1  0.1  0.1 |
             *     
             */

            float[] a = new float[10];
            // Inisiasi a[1...9] dengan 0.1 kecuali a[5] dengan 0.2
            for (int i = 1; i < 10; i++)
            {
                if (i == 5) a[i] = (float)0.2;
                if (i != 5) a[i] = (float)0.1;
            }

            objek8 = new Bitmap(objek);

            for (int x = 1; x < objek8.Width-1; x++)
            {
                for (int y = 1; y < objek8.Height-1; y++)
                {
                    // Membaca warna matrix 4 node
                    Color c1 = objek8.GetPixel(x-1, y-1);
                    Color c2 = objek8.GetPixel(x-1, y);
                    Color c3 = objek8.GetPixel(x-1, y+1);
                    Color c4 = objek8.GetPixel(x, y-1);
                    Color c5 = objek8.GetPixel(x, y);
                    Color c6 = objek8.GetPixel(x, y+1);
                    Color c7 = objek8.GetPixel(x+1, y-1);
                    Color c8 = objek8.GetPixel(x+1, y);
                    Color c9 = objek8.GetPixel(x+1, y+1);

                    // Grayscale c[1...0]
                    int x1 = (int)(c1.R + c1.G + c1.B) / 3;
                    int x2 = (int)(c2.R + c2.G + c2.B) / 3;
                    int x3 = (int)(c3.R + c3.G + c3.B) / 3;
                    int x4 = (int)(c4.R + c4.G + c4.B) / 3;
                    int x5 = (int)(c5.R + c5.G + c5.B) / 3;
                    int x6 = (int)(c6.R + c6.G + c6.B) / 3;
                    int x7 = (int)(c7.R + c7.G + c7.B) / 3;
                    int x8 = (int)(c8.R + c8.G + c8.B) / 3;
                    int x9 = (int)(c9.R + c9.G + c9.B) / 3;

                    // Initiate Filtering 8
                    int xb = (int)(a[1] * x1 + a[2] * x2 + a[3] * x3 + a[4] * x4 + a[5] * x5 + a[6] * x6 + a[7] * x7 + a[8] * x8 + a[9] * x9);
                    if (xb < 0) xb = 0;
                    if (xb > 255) xb = 255;

                    Color color = Color.FromArgb(xb, xb, xb);
                    objek8.SetPixel(x, y, color);
                }
            }
            pictureBox3.Image = objek8;
        }

        // Exit
        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin ?", "Konfirmasi", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
