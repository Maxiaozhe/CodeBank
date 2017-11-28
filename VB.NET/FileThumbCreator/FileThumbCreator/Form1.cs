using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FileThumbCreator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                Image imgThumb = null;
                IFileThumbCreator creator = null;
                if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    creator=FileThumbController.GetCreator(openFileDialog1.FileName);
                    imgThumb = creator.GetThumbnail();
                    this.pictureBox1.Image = imgThumb;
                }

            }
            catch{
                MessageBox.Show("ファイルのサムネールがありません。");
            }
        }
    }
}
