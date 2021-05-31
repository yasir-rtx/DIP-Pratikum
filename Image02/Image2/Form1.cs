using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image2
{
    public partial class Form1 : Form
    {
        // Deklarasi objek bitmap
        Bitmap objbit;
        Bitmap objbitcp;

        public Form1()
        {
            InitializeComponent();
        }

        // Load
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialog = openFileDialog1.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                objbit = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = objbit;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            objbitcp = new Bitmap(objbit);
            for (int x = 0; x < objbit.Width; x++) // objbit.Width ==> Menghitung panjang dari gambar
            {
                for (int y = 0; y < objbit.Height; y++) // objbit.Height ==> Menghitung tinggi dari gambar
                {
                    Color warna = objbit.GetPixel(x, y); // Membuat atribut warna dan Membaca nilai warna dari posisi x,y
                    objbitcp.SetPixel(x, y, warna); // Memberi nilai warna pada posisi x,y
                }
            }
            pictureBox2.Image = objbitcp; // Menampilkan hasil copy dari gambar
        }

        private void button3_Click(object sender, EventArgs e)
        {
            objbitcp = new Bitmap(objbit);
            for (int x = 0; x < objbit.Width; x++)
            {
                for (int y = 0; y < objbit.Height; y++)
                {
                    Color color = objbit.GetPixel(x, y);
                    objbitcp.SetPixel(objbit.Width - 1 - x, y, color); // Membalik nilai x agar gambar flip secara horiozontal
                }
            }
            pictureBox2.Image = objbitcp;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            objbit = new Bitmap(objbit);
            for (int x = 0; x < objbit.Width; x++)
            {
                for (int y = 0; y < objbit.Height; y++)
                {
                    Color c = objbit.GetPixel(x, y);
                    objbitcp.SetPixel(x, objbit.Height - 1 - y, c); // Membalik nilai y agar gambar flip secara vertikal
                }
            }
            pictureBox2.Image = objbitcp;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit(); // Keluar dari aplikasi
            }
        }
    }
}
