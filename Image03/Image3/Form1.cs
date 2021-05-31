using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image3
{
    public partial class Form1 : Form
    {

        // Deklarasi objek
        Bitmap obj, objrgb;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) // Mengambil nilai RGB
        {
            objrgb = new Bitmap(obj);
            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++)
                {
                    Color w = obj.GetPixel(x, y);
                    int r = w.R;
                    int g = w.G;
                    int b = w.B;
                    Color wb = Color.FromArgb(r, g, b); // Membuat atribut baru dan memberi nilai rgb
                    objrgb.SetPixel(x, y, wb);
                }
            }
            pictureBox2.Image = objrgb;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are U sure ?", "Confirm",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit(); // Keluar dari aplikasi
            }
        }

        private void button4_Click(object sender, EventArgs e) // Menset nilai RGB R
        {
            objrgb = new Bitmap(obj);
            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++)
                {
                    Color w = obj.GetPixel(x, y);
                    int r = w.R;
                    Color wb = Color.FromArgb(r, 0, 0);
                    objrgb.SetPixel(x, y, wb);
                }
            }
            pictureBox2.Image = objrgb;
        }

        private void button5_Click(object sender, EventArgs e) // Menset nilai RGB G
        {
            objrgb = new Bitmap(obj);
            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++)
                {
                    Color w = obj.GetPixel(x, y);
                    int g = w.G;
                    Color wb = Color.FromArgb(0, g, 0);
                    objrgb.SetPixel(x, y, wb);
                }
            }
            pictureBox2.Image = objrgb;
        }

        private void button6_Click(object sender, EventArgs e) // Menset nilai RGB B
        {
            objrgb = new Bitmap(obj);
            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++)
                {
                    Color w = obj.GetPixel(x, y);
                    int b = w.B;
                    Color wb = Color.FromArgb(0, 0, b);
                    objrgb.SetPixel(x, y, wb);
                }
            }
            pictureBox2.Image = objrgb;
        }

        private void button7_Click(object sender, EventArgs e) // Greyscale Red
        {
            objrgb = new Bitmap(obj);
            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++)
                {
                    Color w = obj.GetPixel(x, y);
                    int r = w.R;
                    Color wb = Color.FromArgb(r, r, r); // Greyscale menggunakan nilai RGB yg sama.
                    objrgb.SetPixel(x, y, wb);
                }
            }
            pictureBox2.Image = objrgb;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            objrgb = new Bitmap(obj);
            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++)
                {
                    Color w = obj.GetPixel(x, y);
                    int g = w.G;
                    Color wb = Color.FromArgb(g, g, g); // Greyscale menggunakan nilai RGB yg sama.
                    objrgb.SetPixel(x, y, wb);
                }
            }
            pictureBox2.Image = objrgb;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            objrgb = new Bitmap(obj);
            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++)
                {
                    Color w = obj.GetPixel(x, y);
                    int b = w.B;
                    Color wb = Color.FromArgb(b, b, b); // Greyscale menggunakan nilai RGB yg sama.
                    objrgb.SetPixel(x, y, wb);
                }
            }
            pictureBox2.Image = objrgb;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            objrgb = new Bitmap(obj);
            for (int x = 0; x < obj.Width; x++)
            {
                for (int y = 0; y < obj.Height; y++)
                {
                    Color sephia = obj.GetPixel(x, y);
                    int r = sephia.R;
                    int nr = r;
                    int ng = (82 / 100) * r;
                    int nb = (28 / 100) * r;
                    Color newsephia = Color.FromArgb(nr, ng, nb);
                    objrgb.SetPixel(x, y, newsephia);
                }
            }
            pictureBox2.Image = objrgb;
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
    }
}
