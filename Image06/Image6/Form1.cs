using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image6
{
    public partial class Form1 : Form
    {
        Bitmap objbitmap;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                objbitmap = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = objbitmap;
            }
        }

        // Grayscale
        private void button2_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < objbitmap.Width; x++)
            {
                for (int y = 0; y < objbitmap.Height; y++)
                {
                    Color color = objbitmap.GetPixel(x, y);
                    int xg = (int)((color.R + color.G + color.B) / 3);
                    Color newColor = Color.FromArgb(xg, xg, xg);
                    objbitmap.SetPixel(x, y, newColor);
                }
            }
            pictureBox1.Image = objbitmap;
        }

        // Histogram
        private void button3_Click(object sender, EventArgs e)
        {
            objbitmap = new Bitmap(pictureBox1.Image);
            float[] h = new float[256];

            // Inisialisasi h[0...255] dengan 0
            for (int i = 0; i < 256; i++) h[i] = 0;

            // Membaca nilai derajat keabuan xg di seluruh titik
            for (int x = 0; x < objbitmap.Width; x++)
            {
                for (int y = 0; y < objbitmap.Height; y++)
                {
                    Color color = objbitmap.GetPixel(x, y);
                    int xg = (int)((color.R + color.G + color.B) / 3);
                    h[xg] = h[xg] + 1;
                }
            }

            for (int i = 0; i < 256; i++)
            {
                chart1.Series["Series1"].Points.AddXY(i, h[i]);
            }
        }

        // Fungsi Distribusi Kumulatif
        private void button4_Click(object sender, EventArgs e)
        {
            objbitmap = new Bitmap(pictureBox1.Image);
            float[] Hist = new float[256];
            float[] CDF = new float[256];

            // Inisialisasi h[0...255] dengan 0
            for (int i = 0; i < 256; i++) Hist[i] = 0;

            // Membaca nilai derajat keabuan xg di seluruh titik
            for (int x = 0; x < objbitmap.Width; x++)
            {
                for (int y = 0; y < objbitmap.Height; y++)
                {
                    Color color = objbitmap.GetPixel(x, y);
                    int xg = (int)((color.R + color.G + color.B) / 3);
                    Hist[xg] = Hist[xg] + 1;
                }
            }

            // Fungski Distribusi Kumulatif
            CDF[0] = Hist[0];
            for (int i = 1; i < 256; i++) CDF[i] = CDF[i - 1] + Hist[i];

            for (int i = 0; i < 256; i++)
            {
                chart2.Series["Series1"].Points.AddXY(i, CDF[i]);
            }
        }

        // Exit
        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah anda yakin ingin keluar ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            objbitmap = new Bitmap(pictureBox1.Image);
            float[] h = new float[256];
            int nPixel = objbitmap.Width * objbitmap.Height;

            // Inisialisasi h[0...255] dengan 0
            for (int i = 0; i < 256; i++) h[i] = 0;

            // Membaca nilai derajat keabuan xg di seluruh titik
            for (int x = 0; x < objbitmap.Width; x++)
            {
                for (int y = 0; y < objbitmap.Height; y++)
                {
                    Color color = objbitmap.GetPixel(x, y);
                    int xg = (int)((color.R + color.G + color.B) / 3);
                    h[xg] = h[xg] + 1;
                }
            }

            /* Normalisasi h[i] */
            for (int i = 0; i < 256; i++)
            {
                h[i] = h[i] / (float)nPixel;
            }

            for (int i = 0; i < 256; i++)
            {
                chart3.Series["Series1"].Points.AddXY(i, h[i]);
            }
        }
    }
}
