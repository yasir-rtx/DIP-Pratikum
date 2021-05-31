using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Image1
{
    public partial class Form1 : Form
    {
        Image File;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Nggak penting !!!
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                File = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = File;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult d = saveFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                File.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit(); // Keluar dari aplikasi
            }
        }
    }
}
