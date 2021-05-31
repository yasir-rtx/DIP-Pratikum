using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image4
{
    public partial class Form1 : Form
    {
        Bitmap obj;
        Bitmap objek; // hasil manipulasi

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialog = openFileDialog1.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                obj = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = obj;
            }
        }

        // Grayscale
        private void button2_Click(object sender, EventArgs e)
        {
            objek = new Bitmap(obj);
            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++)
                {
                    Color color = obj.GetPixel(x, y);
                    int gs = (color.R + color.G + color.B) / 3;
                    Color grayscale = Color.FromArgb(gs, gs, gs);
                    objek.SetPixel(x, y, grayscale);
                }
            }
            pictureBox2.Image = objek;
        }

        // Black and White
        private void button3_Click(object sender, EventArgs e)
        {
            objek = new Bitmap(obj);
            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++)
                {
                    Color color = obj.GetPixel(x, y);
                    int xg = (int)(color.R + color.G + color.B) / 3;
                    int threshold = 128; // Nilai threshold
                    int xbw = 0;
                    if (xg >= threshold) xbw = 255;
                    Color bnw = Color.FromArgb(xbw, xbw, xbw);
                    objek.SetPixel(x, y, bnw);
                }
            }
            pictureBox2.Image = objek;
        }

        // Kuantisasi
        private void button4_Click(object sender, EventArgs e)
        {
            objek = new Bitmap(obj);
            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++)
                {
                    Color w = obj.GetPixel(x, y);
                    int xg = (int)(w.R + w.G + w.B) / 3;
                    int k = 64; // Nilai kuantisasi
                    int xk = k * (int)(xg / k);
                    Color kuantisasi = Color.FromArgb(xk, xk, xk);
                    objek.SetPixel(x, y, kuantisasi);
                }
            }
            pictureBox2.Image = objek;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ARE U SURE ?", "CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
