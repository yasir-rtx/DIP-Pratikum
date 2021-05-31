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
        Bitmap sobel;
        Bitmap laplacian;

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
            sobel = new Bitmap(objek);

            for (int x = 1; x < sobel.Width - 1; x++)
            {
                for (int y = 1; y < sobel.Height - 1; y++)
                {
                    // Read RGB from objek
                    Color c1 = objek.GetPixel(x - 1, y - 1);
                    Color c2 = objek.GetPixel(x, y - 1);
                    Color c3 = objek.GetPixel(x + 1, y - 1);
                    Color c4 = objek.GetPixel(x - 1, y);
                    Color c5 = objek.GetPixel(x, y);
                    Color c6 = objek.GetPixel(x + 1, y);
                    Color c7 = objek.GetPixel(x - 1, y + 1);
                    Color c8 = objek.GetPixel(x, y + 1);
                    Color c9 = objek.GetPixel(x + 1, y + 1);

                    // Grayscale 3x3 Kernel 
                    int xg1 = (int)((c1.R + c1.G + c1.B) / 3);
                    int xg2 = (int)((c2.R + c2.G + c2.B) / 3);
                    int xg3 = (int)((c3.R + c3.G + c3.B) / 3);
                    int xg4 = (int)((c4.R + c4.G + c4.B) / 3);
                    int xg5 = (int)((c5.R + c5.G + c5.B) / 3);
                    int xg6 = (int)((c6.R + c6.G + c6.B) / 3);
                    int xg7 = (int)((c7.R + c7.G + c7.B) / 3);
                    int xg8 = (int)((c8.R + c8.G + c8.B) / 3);
                    int xg9 = (int)((c9.R + c9.G + c9.B) / 3);

                    // Horiozaonal
                    int xh = (int)(-xg1 - (2 * xg4) - xg7 + xg3 + (2 * xg6) + xg9);
                    // Vertical
                    int xv = (int)(-xg1 - (2 * xg2) - xg3 + xg7 + (2 * xg8) + xg9);

                    int nX = xh + xv;

                    if (nX < 0) nX = -nX;
                    if (nX > 255) nX = 255;

                    Color nC = Color.FromArgb(nX, nX, nX);
                    sobel.SetPixel(x, y, nC);
                }
            }
            pictureBox4.Image = sobel;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Laplacian Method
            laplacian = new Bitmap(objek);

            for (int x = 1; x < laplacian.Width - 1; x++)
            {
                for (int y = 1; y < laplacian.Height - 1; y++)
                {
                    // Read RGB from objek
                    Color c1 = objek.GetPixel(x - 1, y - 1);
                    Color c2 = objek.GetPixel(x, y - 1);
                    Color c3 = objek.GetPixel(x + 1, y - 1);
                    Color c4 = objek.GetPixel(x - 1, y);
                    Color c5 = objek.GetPixel(x, y);
                    Color c6 = objek.GetPixel(x + 1, y);
                    Color c7 = objek.GetPixel(x - 1, y + 1);
                    Color c8 = objek.GetPixel(x, y + 1);
                    Color c9 = objek.GetPixel(x + 1, y + 1);

                    // Grayscale 3x3 Kernel 
                    int xg1 = (int)((c1.R + c1.G + c1.B) / 3);
                    int xg2 = (int)((c2.R + c2.G + c2.B) / 3);
                    int xg3 = (int)((c3.R + c3.G + c3.B) / 3);
                    int xg4 = (int)((c4.R + c4.G + c4.B) / 3);
                    int xg5 = (int)((c5.R + c5.G + c5.B) / 3);
                    int xg6 = (int)((c6.R + c6.G + c6.B) / 3);
                    int xg7 = (int)((c7.R + c7.G + c7.B) / 3);
                    int xg8 = (int)((c8.R + c8.G + c8.B) / 3);
                    int xg9 = (int)((c9.R + c9.G + c9.B) / 3);

                    // Laplacian Method
                    int xnew = (int)(xg1 + (-2 * xg2) + xg3 + (-2 * xg4) + (4 * xg5) + (-2 * xg6) + xg7 + (-2 * xg8) + xg9);
                    if (xnew < 0) xnew = -xnew;
                    if (xnew > 255) xnew = 255;
                    Color cn = Color.FromArgb(xnew, xnew, xnew);
                    laplacian.SetPixel(x, y, cn);
                }
            }
            pictureBox5.Image = laplacian;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Exit
            if (MessageBox.Show("Apa anda yakin ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Binerisasi
            int thres = 128;

            Bitmap bin1, bin2, bin3, bin4;
            bin1 = new Bitmap(pictureBox2.Image);
            bin2 = new Bitmap(pictureBox3.Image);
            bin3 = new Bitmap(pictureBox4.Image);
            bin4 = new Bitmap(pictureBox5.Image);

            for (int x = 0; x < bin1.Width; x++)
            {
                for (int y = 0; y < bin1.Height; y++)
                {
                    // Robert
                    Color c1 = bin1.GetPixel(x, y);
                    int xg1 = (int)((c1.R + c1.G + c1.B) / 3);
                    int bw1 = 0;
                    if (xg1 >= thres) bw1 = 255;
                    Color nc1 = Color.FromArgb(bw1, bw1, bw1);
                    bin1.SetPixel(x, y, nc1);

                    // Prewitt
                    Color c2 = bin2.GetPixel(x, y);
                    int xg2 = (int)((c2.R + c2.G + c2.B) / 3);
                    int bw2 = 0;
                    if (xg2 >= thres) bw2 = 255;
                    Color nc2 = Color.FromArgb(bw2, bw2, bw2);
                    bin2.SetPixel(x, y, nc2);

                    // Sobel
                    Color c3 = bin3.GetPixel(x, y);
                    int xg3 = (int)((c3.R + c3.G + c3.B) / 3);
                    int bw3 = 0;
                    if (xg3 >= thres) bw3 = 255;
                    Color nc3 = Color.FromArgb(bw3, bw3, bw3);
                    bin3.SetPixel(x, y, nc3);

                    // Laplacian
                    Color c4 = bin4.GetPixel(x, y);
                    int xg4 = (int)((c4.R + c4.G + c4.B) / 3);
                    int bw4 = 0;
                    if (xg4 >= thres) bw4 = 255;
                    Color nc4 = Color.FromArgb(bw4, bw4, bw4);
                    bin4.SetPixel(x, y, nc4);
                }
            }
            pictureBox2.Image = bin1;
            pictureBox3.Image = bin2;
            pictureBox4.Image = bin3;
            pictureBox5.Image = bin4;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Invers
            Bitmap invers1, invers2, invers3, invers4;
            invers1 = new Bitmap(pictureBox2.Image);
            invers2 = new Bitmap(pictureBox3.Image);
            invers3 = new Bitmap(pictureBox4.Image);
            invers4 = new Bitmap(pictureBox5.Image);

            for (int x = 0; x < invers1.Width; x++)
            {
                for (int y = 0; y < invers1.Height; y++)
                {
                    // Robert
                    Color c1 = invers1.GetPixel(x, y);
                    int xnr1 = (int)(255 - c1.R);
                    int xng1 = (int)(255 - c1.G);
                    int xnb1 = (int)(255 - c1.B);
                    Color cn1 = Color.FromArgb(xnr1, xng1, xnb1);
                    invers1.SetPixel(x, y, cn1);

                    // Prewitt
                    Color c2 = invers2.GetPixel(x, y);
                    int xnr2 = (int)(255 - c2.R);
                    int xng2 = (int)(255 - c2.G);
                    int xnb2 = (int)(255 - c2.B);
                    Color cn2 = Color.FromArgb(xnr2, xng2, xnb2);
                    invers2.SetPixel(x, y, cn2);

                    // Sobel
                    Color c3 = invers3.GetPixel(x, y);
                    int xnr3 = (int)(255 - c3.R);
                    int xng3 = (int)(255 - c3.G);
                    int xnb3 = (int)(255 - c3.B);
                    Color cn3 = Color.FromArgb(xnr3, xng3, xnb3);
                    invers3.SetPixel(x, y, cn3);

                    // Laplacian
                    Color c4 = invers4.GetPixel(x, y);
                    int xnr4 = (int)(255 - c4.R);
                    int xng4 = (int)(255 - c4.G);
                    int xnb4 = (int)(255 - c4.B);
                    Color cn4 = Color.FromArgb(xnr4, xng4, xnb4);
                    invers4.SetPixel(x, y, cn4);
                }
            }

            pictureBox2.Image = invers1;
            pictureBox3.Image = invers2;
            pictureBox4.Image = invers3;
            pictureBox5.Image = invers4;
        }
    }
}
