using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image10
{
    public partial class Form1 : Form
    {
        Bitmap obj;
        Bitmap objNoise;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                obj = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = obj;
            }
        }

        // Grayscale
        private void button7_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++)
                {
                    Color color = obj.GetPixel(x, y);
                    int xg = (int)(color.R + color.G + color.B) / 3;
                    Color newColor = Color.FromArgb(xg, xg, xg);
                    obj.SetPixel(x, y, newColor);
                }
            }
            pictureBox1.Image = obj;
        }

        // Noise Gaussian
        private void button3_Click(object sender, EventArgs e)
        {
            objNoise = new Bitmap(obj);
            Random random = new Random();
            int n = Convert.ToInt16(textBox1.Text);

            for (int x = 0; x < objNoise.Width; x++)
            {
                for (int y = 0; y < objNoise.Height; y++)
                {
                    Color color = objNoise.GetPixel(x, y);
                    int xg = (int)(color.R + color.G + color.B) / 3;
                    int xb = xg;
                    int newRandom = random.Next(0, 100);
                    if (newRandom < n) // Noise = 20%
                    {
                        int noise = random.Next(0, 256) - 128;
                        xb = (int)(xg + noise);
                        if (xb < 0) xb = -xb;
                        if (xb > 255) xb = 255;
                    }
                    Color newColor = Color.FromArgb(xb, xb, xb);
                    objNoise.SetPixel(x, y, newColor);
                }
            }
            pictureBox2.Image = objNoise;
        }

        // Noise Speckle
        private void button4_Click(object sender, EventArgs e)
        {
            objNoise = new Bitmap(obj);
            Random random = new Random();
            int n = Convert.ToInt16(textBox1.Text);

            for (int x = 0; x < objNoise.Width; x++)
            {
                for (int y = 0; y < objNoise.Height; y++)
                {
                    Color color = objNoise.GetPixel(x, y);
                    int xg = (int)(color.R + color.G + color.B) / 3;
                    int xb = xg;
                    int newRandom = random.Next(0, 100);
                    if (newRandom < n) xb = 0; // Noise Speckle
                    Color newColor = Color.FromArgb(xb, xb, xb);
                    objNoise.SetPixel(x, y, newColor);
                }
            }
            pictureBox3.Image = objNoise;
        }

        // Noise Salt & Pepper
        private void button5_Click(object sender, EventArgs e)
        {
            objNoise = new Bitmap(obj);
            Random random = new Random();
            int n = Convert.ToInt16(textBox1.Text);

            for (int x = 0; x < objNoise.Width; x++)
            {
                for (int y = 0; y < objNoise.Height; y++)
                {
                    Color color = objNoise.GetPixel(x, y);
                    int xg = (int)(color.R + color.G + color.B) / 3;
                    int xb = xg;
                    int newRandom = random.Next(0, 100);
                    if (newRandom < n) xb = 255; // Noise Salt & Pepper
                    Color newColor = Color.FromArgb(xb, xb, xb);
                    objNoise.SetPixel(x, y, newColor);
                }
            }
            pictureBox4.Image = objNoise;
        }



        // Filter Rata-rata untuk Noise Gaussian
        private void button8_Click(object sender, EventArgs e)
        {
            objNoise = new Bitmap(pictureBox2.Image);
            for (int x = 1; x < objNoise.Width - 1; x++)
            {
                for (int y = 1; y < objNoise.Height - 1; y++)
                {
                    // Membaca data RGB
                    Color c1 = objNoise.GetPixel(x - 1, y - 1);
                    Color c2 = objNoise.GetPixel(x - 1, y);
                    Color c3 = objNoise.GetPixel(x - 1, y + 1);
                    Color c4 = objNoise.GetPixel(x, y - 1);
                    Color c5 = objNoise.GetPixel(x, y);
                    Color c6 = objNoise.GetPixel(x, y + 1);
                    Color c7 = objNoise.GetPixel(x + 1, y - 1);
                    Color c8 = objNoise.GetPixel(x + 1, y);
                    Color c9 = objNoise.GetPixel(x + 1, y + 1);

                    // Grayscale
                    int x1 = (int)(c1.R + c1.G + c1.B) / 3;
                    int x2 = (int)(c2.R + c2.G + c2.B) / 3;
                    int x3 = (int)(c3.R + c3.G + c3.B) / 3;
                    int x4 = (int)(c4.R + c4.G + c4.B) / 3;
                    int x5 = (int)(c5.R + c5.G + c5.B) / 3;
                    int x6 = (int)(c6.R + c6.G + c6.B) / 3;
                    int x7 = (int)(c7.R + c7.G + c7.B) / 3;
                    int x8 = (int)(c8.R + c8.G + c8.B) / 3;
                    int x9 = (int)(c9.R + c9.G + c9.B) / 3;

                    // Filter Rata-rata
                    int xb = (int)((x1 + x2 + x3 + x4 + x5 + x6 + x7 + x8 + x9) / 9);
                    if (xb < 0) xb = 0;
                    if (xb > 255) xb = 255;
                    Color wb = Color.FromArgb(xb, xb, xb);
                    objNoise.SetPixel(x, y, wb);
                }
             }
            pictureBox2.Image = objNoise;
        }

        // Filter Gaussian untuk Noise Gaussian
        private void button9_Click(object sender, EventArgs e)
        {
            objNoise = new Bitmap(pictureBox2.Image);
            for (int x = 1; x < objNoise.Width - 1; x++)
            {
                for (int y = 1; y < objNoise.Height - 1; y++)
                {
                    // Membaca data RGB
                    Color c1 = objNoise.GetPixel(x - 1, y - 1);
                    Color c2 = objNoise.GetPixel(x - 1, y);
                    Color c3 = objNoise.GetPixel(x - 1, y + 1);
                    Color c4 = objNoise.GetPixel(x, y - 1);
                    Color c5 = objNoise.GetPixel(x, y);
                    Color c6 = objNoise.GetPixel(x, y + 1);
                    Color c7 = objNoise.GetPixel(x + 1, y - 1);
                    Color c8 = objNoise.GetPixel(x + 1, y);
                    Color c9 = objNoise.GetPixel(x + 1, y + 1);

                    // Grayscale
                    int x1 = (int)(c1.R + c1.G + c1.B) / 3;
                    int x2 = (int)(c2.R + c2.G + c2.B) / 3;
                    int x3 = (int)(c3.R + c3.G + c3.B) / 3;
                    int x4 = (int)(c4.R + c4.G + c4.B) / 3;
                    int x5 = (int)(c5.R + c5.G + c5.B) / 3;
                    int x6 = (int)(c6.R + c6.G + c6.B) / 3;
                    int x7 = (int)(c7.R + c7.G + c7.B) / 3;
                    int x8 = (int)(c8.R + c8.G + c8.B) / 3;
                    int x9 = (int)(c9.R + c9.G + c9.B) / 3;

                    // Filter Gaussian
                    int xb = (int)((x1 + x2 + x3 + x4 + (4 * x5) + x6 + x7 + x8 + x9) / 13);
                    if (xb < 0) xb = 0;
                    if (xb > 255) xb = 255;
                    Color wb = Color.FromArgb(xb, xb, xb);
                    objNoise.SetPixel(x, y, wb);
                }
            }
            pictureBox2.Image = objNoise;
        }

        // Filter Median untuk Noise Gaussian
        private void button10_Click(object sender, EventArgs e)
        {
            objNoise = new Bitmap(pictureBox2.Image);
            int[] xt = new int[10];

            for (int x = 1; x < objNoise.Width - 1; x++)
            {
                for (int y = 1; y < objNoise.Height - 1; y++)
                {
                    // Membaca data RGB
                    Color c1 = objNoise.GetPixel(x - 1, y - 1);
                    Color c2 = objNoise.GetPixel(x - 1, y);
                    Color c3 = objNoise.GetPixel(x - 1, y + 1);
                    Color c4 = objNoise.GetPixel(x, y - 1);
                    Color c5 = objNoise.GetPixel(x, y);
                    Color c6 = objNoise.GetPixel(x, y + 1);
                    Color c7 = objNoise.GetPixel(x + 1, y - 1);
                    Color c8 = objNoise.GetPixel(x + 1, y);
                    Color c9 = objNoise.GetPixel(x + 1, y + 1);

                    // Grayscale
                    xt[1] = (int)(c1.R + c1.G + c1.B) / 3;
                    xt[2] = (int)(c2.R + c2.G + c2.B) / 3;
                    xt[3] = (int)(c3.R + c3.G + c3.B) / 3;
                    xt[4] = (int)(c4.R + c4.G + c4.B) / 3;
                    xt[5] = (int)(c5.R + c5.G + c5.B) / 3;
                    xt[6] = (int)(c6.R + c6.G + c6.B) / 3;
                    xt[7] = (int)(c7.R + c7.G + c7.B) / 3;
                    xt[8] = (int)(c8.R + c8.G + c8.B) / 3;
                    xt[9] = (int)(c9.R + c9.G + c9.B) / 3;

                    // Sorting Median
                    for (int i = 1; i < 9; i++)
                    {
                        for (int j = 1; j < 9; j++)
                        {
                            if (xt[j] > xt[j + 1])
                            {
                                int a = xt[j];
                                xt[j] = xt[j + 1];
                                xt[j + 1] = a;
                            }
                        }
                    }

                    int xb = xt[5]; // Mengambil median
                    Color wb = Color.FromArgb(xb, xb, xb);
                    objNoise.SetPixel(x, y, wb);
                }
            }
            pictureBox2.Image = objNoise;
        }



        // Filter rata-rata untuk Noise Speckle
        private void button12_Click(object sender, EventArgs e)
        {
            objNoise = new Bitmap(pictureBox3.Image);
            for (int x = 1; x < objNoise.Width - 1; x++)
            {
                for (int y = 1; y < objNoise.Height - 1; y++)
                {
                    // Membaca data RGB
                    Color c1 = objNoise.GetPixel(x - 1, y - 1);
                    Color c2 = objNoise.GetPixel(x - 1, y);
                    Color c3 = objNoise.GetPixel(x - 1, y + 1);
                    Color c4 = objNoise.GetPixel(x, y - 1);
                    Color c5 = objNoise.GetPixel(x, y);
                    Color c6 = objNoise.GetPixel(x, y + 1);
                    Color c7 = objNoise.GetPixel(x + 1, y - 1);
                    Color c8 = objNoise.GetPixel(x + 1, y);
                    Color c9 = objNoise.GetPixel(x + 1, y + 1);

                    // Grayscale
                    int x1 = (int)(c1.R + c1.G + c1.B) / 3;
                    int x2 = (int)(c2.R + c2.G + c2.B) / 3;
                    int x3 = (int)(c3.R + c3.G + c3.B) / 3;
                    int x4 = (int)(c4.R + c4.G + c4.B) / 3;
                    int x5 = (int)(c5.R + c5.G + c5.B) / 3;
                    int x6 = (int)(c6.R + c6.G + c6.B) / 3;
                    int x7 = (int)(c7.R + c7.G + c7.B) / 3;
                    int x8 = (int)(c8.R + c8.G + c8.B) / 3;
                    int x9 = (int)(c9.R + c9.G + c9.B) / 3;

                    // Filter Rata-rata
                    int xb = (int)((x1 + x2 + x3 + x4 + x5 + x6 + x7 + x8 + x9) / 9);
                    if (xb < 0) xb = 0;
                    if (xb > 255) xb = 255;
                    Color wb = Color.FromArgb(xb, xb, xb);
                    objNoise.SetPixel(x, y, wb);
                }
            }
            pictureBox3.Image = objNoise;
        }

        // Filter Gaussian untuk Noise Speckle
        private void button11_Click(object sender, EventArgs e)
        {
            objNoise = new Bitmap(pictureBox3.Image);
            for (int x = 1; x < objNoise.Width - 1; x++)
            {
                for (int y = 1; y < objNoise.Height - 1; y++)
                {
                    // Membaca data RGB
                    Color c1 = objNoise.GetPixel(x - 1, y - 1);
                    Color c2 = objNoise.GetPixel(x - 1, y);
                    Color c3 = objNoise.GetPixel(x - 1, y + 1);
                    Color c4 = objNoise.GetPixel(x, y - 1);
                    Color c5 = objNoise.GetPixel(x, y);
                    Color c6 = objNoise.GetPixel(x, y + 1);
                    Color c7 = objNoise.GetPixel(x + 1, y - 1);
                    Color c8 = objNoise.GetPixel(x + 1, y);
                    Color c9 = objNoise.GetPixel(x + 1, y + 1);

                    // Grayscale
                    int x1 = (int)(c1.R + c1.G + c1.B) / 3;
                    int x2 = (int)(c2.R + c2.G + c2.B) / 3;
                    int x3 = (int)(c3.R + c3.G + c3.B) / 3;
                    int x4 = (int)(c4.R + c4.G + c4.B) / 3;
                    int x5 = (int)(c5.R + c5.G + c5.B) / 3;
                    int x6 = (int)(c6.R + c6.G + c6.B) / 3;
                    int x7 = (int)(c7.R + c7.G + c7.B) / 3;
                    int x8 = (int)(c8.R + c8.G + c8.B) / 3;
                    int x9 = (int)(c9.R + c9.G + c9.B) / 3;

                    // Filter Gaussian
                    int xb = (int)((x1 + x2 + x3 + x4 + (4 * x5) + x6 + x7 + x8 + x9) / 13);
                    if (xb < 0) xb = 0;
                    if (xb > 255) xb = 255;
                    Color wb = Color.FromArgb(xb, xb, xb);
                    objNoise.SetPixel(x, y, wb);
                }
            }
            pictureBox3.Image = objNoise;
        }

        // Filter Median untuk Noise Speckle
        private void button2_Click(object sender, EventArgs e)
        {
            objNoise = new Bitmap(pictureBox3.Image);
            int[] xt = new int[10];

            for (int x = 1; x < objNoise.Width - 1; x++)
            {
                for (int y = 1; y < objNoise.Height - 1; y++)
                {
                    // Membaca data RGB
                    Color c1 = objNoise.GetPixel(x - 1, y - 1);
                    Color c2 = objNoise.GetPixel(x - 1, y);
                    Color c3 = objNoise.GetPixel(x - 1, y + 1);
                    Color c4 = objNoise.GetPixel(x, y - 1);
                    Color c5 = objNoise.GetPixel(x, y);
                    Color c6 = objNoise.GetPixel(x, y + 1);
                    Color c7 = objNoise.GetPixel(x + 1, y - 1);
                    Color c8 = objNoise.GetPixel(x + 1, y);
                    Color c9 = objNoise.GetPixel(x + 1, y + 1);

                    // Grayscale
                    xt[1] = (int)(c1.R + c1.G + c1.B) / 3;
                    xt[2] = (int)(c2.R + c2.G + c2.B) / 3;
                    xt[3] = (int)(c3.R + c3.G + c3.B) / 3;
                    xt[4] = (int)(c4.R + c4.G + c4.B) / 3;
                    xt[5] = (int)(c5.R + c5.G + c5.B) / 3;
                    xt[6] = (int)(c6.R + c6.G + c6.B) / 3;
                    xt[7] = (int)(c7.R + c7.G + c7.B) / 3;
                    xt[8] = (int)(c8.R + c8.G + c8.B) / 3;
                    xt[9] = (int)(c9.R + c9.G + c9.B) / 3;

                    // Sorting Median
                    for (int i = 1; i < 9; i++)
                    {
                        for (int j = 1; j < 9; j++)
                        {
                            if (xt[j] > xt[j + 1])
                            {
                                int a = xt[j];
                                xt[j] = xt[j + 1];
                                xt[j + 1] = a;
                            }
                        }
                    }

                    int xb = xt[5]; // Mengambil median
                    Color wb = Color.FromArgb(xb, xb, xb);
                    objNoise.SetPixel(x, y, wb);
                }
            }
            pictureBox3.Image = objNoise;
        }



        // Filter Rata-rata untuk Noise Salt&Pepper
        private void button15_Click(object sender, EventArgs e)
        {
            objNoise = new Bitmap(pictureBox4.Image);
            for (int x = 1; x < objNoise.Width - 1; x++)
            {
                for (int y = 1; y < objNoise.Height - 1; y++)
                {
                    // Membaca data RGB
                    Color c1 = objNoise.GetPixel(x - 1, y - 1);
                    Color c2 = objNoise.GetPixel(x - 1, y);
                    Color c3 = objNoise.GetPixel(x - 1, y + 1);
                    Color c4 = objNoise.GetPixel(x, y - 1);
                    Color c5 = objNoise.GetPixel(x, y);
                    Color c6 = objNoise.GetPixel(x, y + 1);
                    Color c7 = objNoise.GetPixel(x + 1, y - 1);
                    Color c8 = objNoise.GetPixel(x + 1, y);
                    Color c9 = objNoise.GetPixel(x + 1, y + 1);

                    // Grayscale
                    int x1 = (int)(c1.R + c1.G + c1.B) / 3;
                    int x2 = (int)(c2.R + c2.G + c2.B) / 3;
                    int x3 = (int)(c3.R + c3.G + c3.B) / 3;
                    int x4 = (int)(c4.R + c4.G + c4.B) / 3;
                    int x5 = (int)(c5.R + c5.G + c5.B) / 3;
                    int x6 = (int)(c6.R + c6.G + c6.B) / 3;
                    int x7 = (int)(c7.R + c7.G + c7.B) / 3;
                    int x8 = (int)(c8.R + c8.G + c8.B) / 3;
                    int x9 = (int)(c9.R + c9.G + c9.B) / 3;

                    // Filter Rata-rata
                    int xb = (int)((x1 + x2 + x3 + x4 + x5 + x6 + x7 + x8 + x9) / 9);
                    if (xb < 0) xb = 0;
                    if (xb > 255) xb = 255;
                    Color wb = Color.FromArgb(xb, xb, xb);
                    objNoise.SetPixel(x, y, wb);
                }
            }
            pictureBox4.Image = objNoise;
        }

        // Filter Gaussian untuk Noise Salt&Pepper
        private void button14_Click(object sender, EventArgs e)
        {
            objNoise = new Bitmap(pictureBox4.Image);
            for (int x = 1; x < objNoise.Width - 1; x++)
            {
                for (int y = 1; y < objNoise.Height - 1; y++)
                {
                    // Membaca data RGB
                    Color c1 = objNoise.GetPixel(x - 1, y - 1);
                    Color c2 = objNoise.GetPixel(x - 1, y);
                    Color c3 = objNoise.GetPixel(x - 1, y + 1);
                    Color c4 = objNoise.GetPixel(x, y - 1);
                    Color c5 = objNoise.GetPixel(x, y);
                    Color c6 = objNoise.GetPixel(x, y + 1);
                    Color c7 = objNoise.GetPixel(x + 1, y - 1);
                    Color c8 = objNoise.GetPixel(x + 1, y);
                    Color c9 = objNoise.GetPixel(x + 1, y + 1);

                    // Grayscale
                    int x1 = (int)(c1.R + c1.G + c1.B) / 3;
                    int x2 = (int)(c2.R + c2.G + c2.B) / 3;
                    int x3 = (int)(c3.R + c3.G + c3.B) / 3;
                    int x4 = (int)(c4.R + c4.G + c4.B) / 3;
                    int x5 = (int)(c5.R + c5.G + c5.B) / 3;
                    int x6 = (int)(c6.R + c6.G + c6.B) / 3;
                    int x7 = (int)(c7.R + c7.G + c7.B) / 3;
                    int x8 = (int)(c8.R + c8.G + c8.B) / 3;
                    int x9 = (int)(c9.R + c9.G + c9.B) / 3;

                    // Filter Gaussian
                    int xb = (int)((x1 + x2 + x3 + x4 + (4 * x5) + x6 + x7 + x8 + x9) / 13);
                    if (xb < 0) xb = 0;
                    if (xb > 255) xb = 255;
                    Color wb = Color.FromArgb(xb, xb, xb);
                    objNoise.SetPixel(x, y, wb);
                }
            }
            pictureBox4.Image = objNoise;
        }

        // Filter Median untuk Noise Salt&Pepper
        private void button13_Click(object sender, EventArgs e)
        {
            objNoise = new Bitmap(pictureBox4.Image);
            int[] xt = new int[10];

            for (int x = 1; x < objNoise.Width - 1; x++)
            {
                for (int y = 1; y < objNoise.Height - 1; y++)
                {
                    // Membaca data RGB
                    Color c1 = objNoise.GetPixel(x - 1, y - 1);
                    Color c2 = objNoise.GetPixel(x - 1, y);
                    Color c3 = objNoise.GetPixel(x - 1, y + 1);
                    Color c4 = objNoise.GetPixel(x, y - 1);
                    Color c5 = objNoise.GetPixel(x, y);
                    Color c6 = objNoise.GetPixel(x, y + 1);
                    Color c7 = objNoise.GetPixel(x + 1, y - 1);
                    Color c8 = objNoise.GetPixel(x + 1, y);
                    Color c9 = objNoise.GetPixel(x + 1, y + 1);

                    // Grayscale
                    xt[1] = (int)(c1.R + c1.G + c1.B) / 3;
                    xt[2] = (int)(c2.R + c2.G + c2.B) / 3;
                    xt[3] = (int)(c3.R + c3.G + c3.B) / 3;
                    xt[4] = (int)(c4.R + c4.G + c4.B) / 3;
                    xt[5] = (int)(c5.R + c5.G + c5.B) / 3;
                    xt[6] = (int)(c6.R + c6.G + c6.B) / 3;
                    xt[7] = (int)(c7.R + c7.G + c7.B) / 3;
                    xt[8] = (int)(c8.R + c8.G + c8.B) / 3;
                    xt[9] = (int)(c9.R + c9.G + c9.B) / 3;

                    // Sorting Median
                    for (int i = 1; i < 9; i++)
                    {
                        for (int j = 1; j < 9; j++)
                        {
                            if (xt[j] > xt[j + 1])
                            {
                                int a = xt[j];
                                xt[j] = xt[j + 1];
                                xt[j + 1] = a;
                            }
                        }
                    }

                    int xb = xt[5]; // Mengambil median
                    Color wb = Color.FromArgb(xb, xb, xb);
                    objNoise.SetPixel(x, y, wb);
                }
            }
            pictureBox4.Image = objNoise;
        }



        // Exit
        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin ?", "KOnfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit(); // STOP
            }
        }
    }
}