using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image9
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        // Grayscale
        private void button2_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++) {
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

        // Exit
        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin ?", "KOnfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
