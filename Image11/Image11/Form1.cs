using System;
using System.Drawing;
using System.Windows.Forms;

namespace Image11
{
    public partial class Form1 : Form
    {
        // Objek declaration
        Bitmap objek;
        Bitmap robert;
        Bitmap preewite;
        //Bitmap sobel;
        //Bitmap laplacian;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                objek = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = objek;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Grayscale
            objek = new Bitmap(pictureBox1.Image);
            for (int x = 0; x < objek.Width; x++)
            {
                for (int y = 0; y < objek.Height; y++)
                {
                    Color color = objek.GetPixel(x, y);
                    int xg = (int)((color.R + color.G + color.B) / 3);
                    Color newColor = Color.FromArgb(xg, xg, xg);
                    objek.SetPixel(x, y, newColor);
                }
            }
            pictureBox1.Image = objek;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Robert  Method
            robert = new Bitmap(objek);
            for (int x = 0; x < robert.Width - 1; x++)
            {
                for (int y = 0; y < robert.Height - 1; y++)
                {
                    // horizontal
                    Color w1 = robert.GetPixel(x + 1, y + 1);
                    Color w2 = robert.GetPixel(x, y);
                    // vertical
                    Color w3 = robert.GetPixel(x + 1, y);
                    Color w4 = robert.GetPixel(x, y + 1);

                    // Grayscale
                    int xg1 = (int)((w1.R + w1.G + w1.B) / 3);
                    int xg2 = (int)((w2.R + w2.G + w2.B) / 3);
                    int xg3 = (int)((w3.R + w3.G + w3.B) / 3);
                    int xg4 = (int)((w4.R + w4.G + w4.B) / 3);

                    // Robert Method
                    int newX = (int)((xg2 - xg1) + (xg4 - xg3));
                    if (newX < 0) newX = -newX;
                    if (newX > 255) newX = 255;

                    // Set new RGB
                    Color newColor = Color.FromArgb(newX, newX, newX);
                    robert.SetPixel(x, y, newColor);
                }
            }
            pictureBox2.Image = robert;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Prewitt Method
            preewite = new Bitmap(objek);
            for (int x = 1; x < preewite.Width - 1; x++)
            {
                for (int y = 1; y < preewite.Height - 1; y++)
                {
                    // Read RGB in 3x3 Kernel
                    Color c1 = objek.GetPixel(x - 1, y - 1);
                    Color c2 = objek.GetPixel(x, y - 1);
                    Color c3 = objek.GetPixel(x + 1, y - 1);
                    Color c4 = objek.GetPixel(x - 1, y);
                    Color c5 = objek.GetPixel(x, y);
                    Color c6 = objek.GetPixel(x + 1, y);
                    Color c7 = objek.GetPixel(x - 1, y + 1);
                    Color c8 = objek.GetPixel(x, y + 1);
                    Color c9 = objek.GetPixel(x + 1, y + 1);

                    // Grayscale
                    int xg1 = (int)((c1.R + c1.G + c1.B) / 3);
                    int xg2 = (int)((c2.R + c2.G + c2.B) / 3);
                    int xg3 = (int)((c3.R + c3.G + c3.B) / 3);
                    int xg4 = (int)((c4.R + c4.G + c4.B) / 3);
                    int xg5 = (int)((c5.R + c5.G + c5.B) / 3);
                    int xg6 = (int)((c6.R + c6.G + c6.B) / 3);
                    int xg7 = (int)((c7.R + c7.G + c7.B) / 3);
                    int xg8 = (int)((c8.R + c8.G + c8.B) / 3);
                    int xg9 = (int)((c9.R + c9.G + c9.B) / 3);

                    // Horiozontal
                    //int xh = (xg1 * -1) + (xg2 * 0) + (xg3 * 1) + (xg4 * -1) + (xg5 * 0) + (xg6 * 1) + (xg7 * -1) + (xg8 * 0) + (xg9 * 1);
                    int xh = (int)(-xg1 - xg4 - xg7 + xg3 + xg6 + xg9);
                    // vertical
                    //int xv = (xg1 * -1) + (xg2 * -1) + (xg3 * -1) + (xg4 * 0) + (xg5 * 0) + (xg6 * 0) + (xg7 * 1) + (xg8 * 1) + (xg9 * 1);
                    int xv = (int)(-xg1 - xg2 - xg3 + xg7 + xg8 + xg9);

                    int newX = xh + xv;

                    if (newX < 0) newX = newX * -1;
                    if (newX > 255) newX = 255;

                    Color newColor = Color.FromArgb(newX, newX, newX);
                    preewite.SetPixel(x, y, newColor);
                }
            }
            pictureBox3.Image = preewite;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Sobel Method
            Bitmap sobel;
            sobel = new Bitmap(objek);

            for (int x = 1; x < sobel.Width; x++)
            {
                for (int y = 1; y < sobel.Height - 1; y++)
                {

                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Laplacian Method
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Exit
            if (MessageBox.Show("Apa anda yakin ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
