using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image5
{
    public partial class Form1 : Form
    {
        Bitmap obj;
        Bitmap objek; // Hasil Manipulasi

        public Form1()
        {
            InitializeComponent();
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

        private void button2_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++)
                {
                    Color color = obj.GetPixel(x, y);
                    int xygray = (int)(color.R + color.G + color.B) / 3;
                    Color gray = Color.FromArgb(xygray, xygray, xygray);
                    obj.SetPixel(x, y, gray);
                }
            }
            pictureBox1.Image = obj;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            objek = new Bitmap(obj);
            int bright = Convert.ToInt16(textBox1.Text); // Menampung nilai dari textbox1

            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++)
                {
                    Color color = obj.GetPixel(x, y);
                    int xg = (int)(color.R + color.G + color.B) / 3;

                    // Proses Brightness
                    int xb = xg + bright; //Brightness
                    if (xb < 0) xb = 0; // Membatasi nilai brightness tidak kurang dari 0
                    if (xb > 255) xb = 255; // Membatasi nilai brightness tidak melebihi 255
                    Color brightness = Color.FromArgb(xb, xb, xb);
                    objek.SetPixel(x, y, brightness);
                }
            }
            pictureBox2.Image = objek;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            objek = new Bitmap(obj);
            float contra = Convert.ToSingle(textBox2.Text); // Menampung nilai dari textbox2

            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++)
                {
                    Color color = obj.GetPixel(x, y);
                    int xg = (int)(color.R + color.G + color.B) / 3;

                    // Proses Contrast
                    int xb = (int)(((contra * xg)-128)+128); // Contrast
                    if (xb < 0) xb = 0;
                    if (xb > 255) xb = 255;
                    Color contrast = Color.FromArgb(xb, xb, xb);
                    objek.SetPixel(x, y, contrast);
                }
            }
            pictureBox2.Image = objek;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            objek = new Bitmap(obj);
            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++)
                {
                    Color color = obj.GetPixel(x, y);
                    int xg = color.R;

                    // Proses Invers
                    int xb = (int) 255 - xg; // Invers
                    Color invers = Color.FromArgb(xb, xb, xb);
                    objek.SetPixel(x, y, invers);
                }
            }
            pictureBox2.Image = objek;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            objek = new Bitmap(obj);
            int xgmax = 0;
            int xgmin = 255;

            // Menentukan nilai xgmax dan xgmin
            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++)
                {
                    Color color = obj.GetPixel(x, y);
                    int xg = (int)(color.R + color.G + color.B) / 3;
                    if (xg < xgmin) xgmin = xg;
                    if (xg > xgmax) xgmax = xg;
                }
            }

            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++)
                {
                    Color color = obj.GetPixel(x, y);
                    int xg = (int)(color.R + color.G + color.B) / 3;

                    // Proses Auto-level
                    int xb = (int)((255 * (xg - xgmin)) / (xgmax - xgmin));
                    Color al = Color.FromArgb(xb, xb, xb);
                    objek.SetPixel(x, y, al);
                }
            }
            pictureBox2.Image = objek;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are U Sure ?", "CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit(); // STOP
            }
        }
    }
}
