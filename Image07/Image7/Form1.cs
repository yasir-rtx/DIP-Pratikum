using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image7
{
    public partial class Form1 : Form
    {
        Bitmap objek;
        //Bitmap objekGray;
        Bitmap objekHist;

        public Form1()
        {
            InitializeComponent();
        }

        // Load 
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                objek = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = objek;
            }
        }

        // Grayscale & Histogram
        private void button2_Click(object sender, EventArgs e)
        {
            // Deklarasi array histogram
            float[] h = new float[256];

            // Inisialisasi h[0...255] dengan 0
            for (int i = 0; i < 256; i++) h[i] = 0;

            // Membaca nilai derajat keabuan xg di seluruh titik dan menyimpan ke array hs
            for (int x = 0; x < objek.Width; x++)
            {
                for (int y = 0; y < objek.Height; y++)
                {
                    Color color = objek.GetPixel(x, y);
                    int xg = (int)(color.R + color.G + color.B) / 3;
                    h[xg] = h[xg] + 1;
                    Color newColor = Color.FromArgb(xg, xg, xg);
                    objek.SetPixel(x, y, newColor);
                }
            }
            pictureBox1.Image = objek;

            for (int i = 0; i < 256; i++)
            {
                chart1.Series["Series1"].Points.AddXY(i, h[i]);
            }
        }

        //Histogram Equalization
        private void button3_Click(object sender, EventArgs e)
        {
            objekHist = new Bitmap(objek);
            float[] Hist = new float[256];
            float[] CDF = new float[256];

            // Inisiasi array Hist[0...255] dengan 0
            for (int i = 0; i < 256; i++) Hist[i] = 0;

            // Membaca histogram derajat keabuan Hist[xg]
            for (int x = 0; x < objekHist.Width; x++)
            {
                for (int y = 0; y < objekHist.Height; y++)
                {
                    Color color = objekHist.GetPixel(x, y);
                    int xg = (int)((color.R + color.G + color.B) / 3);
                    Hist[xg] = Hist[xg] + 1;
                }
            }

            // CDF
            CDF[0] = Hist[0];
            for (int i = 1; i < 256; i++) CDF[i] = CDF[i - 1] + Hist[i];

            // Initiate Histogram Equalization
            for (int x = 0; x < objekHist.Width; x++)
            {
                for (int y = 0; y < objekHist.Height; y++)
                {
                    Color color = objekHist.GetPixel(x, y);
                    int xg = (int)((color.R + color.G + color.B) / 3);

                    // Formula Equalization
                    int xb = (int)((255 * CDF[xg]) / (objekHist.Width * objekHist.Height));
                    Color newColor = Color.FromArgb(xb, xb, xb);
                    objekHist.SetPixel(x, y, newColor);
                }
            }
            pictureBox2.Image = objekHist;

            // Membaca Histogram objek hasil equalization
            for (int x = 0; x < objekHist.Width; x++)
            {
                for (int y = 0; y < objekHist.Height; y++)
                {
                    Color color = objekHist.GetPixel(x, y);
                    int xg = (int)((color.R + color.G + color.B) / 3);
                    Hist[xg] = Hist[xg] + 1;
                }
            }

            // Menampilkan Histogram
            for (int i = 0; i < 256; i++)
            {
                chart2.Series["Series1"].Points.AddXY(i, Hist[i]);
            }
        }

        // Exit
        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Auto Level
        private void button5_Click(object sender, EventArgs e)
        {
            objek = new Bitmap(pictureBox1.Image);
            float[] Hist = new float[256];
            int xgmax = 0;
            int xgmin = 255;

            for (int x = 0; x < objek.Width; x++)
            {
                for (int y = 0; y < objek.Height; y++)
                {
                    Color color = objek.GetPixel(x, y);
                    int xg = (int)(color.R + color.G + color.B) / 3;
                    if (xg < xgmin) xgmin = xg;
                    if (xg > xgmax) xgmax = xg;
                }
            }

            for (int x = 0; x < objek.Width; x++)
            {
                for (int y = 0; y < objek.Height; y++)
                {
                    Color color = objek.GetPixel(x, y);
                    int xg = (int)((color.R + color.G + color.B) / 3);
                    int xb = (int)(255 * (xg - xgmin) / (xgmax - xgmin));

                    Color newColor = Color.FromArgb(xb, xb, xb);
                    objek.SetPixel(x, y, newColor);
                }
            }
            pictureBox3.Image = objek;

            // Membaca histogram hasil auto level
            for (int x = 0; x < objek.Width; x++)
            {
                for (int y = 0; y < objek.Height; y++)
                {
                    Color color = objek.GetPixel(x, y);
                    int xg = (int)((color.R + color.G + color.B) / 3);
                    Hist[xg] = Hist[xg] + 1;
                }
            }

            // Menampilkan histogram
            for (int i = 0; i < 256; i++)
            {
                chart3.Series["Series1"].Points.AddXY(i, Hist[i]);
            }
        }
    }
}