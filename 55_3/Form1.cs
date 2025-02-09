﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _55_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string filePath;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "選擇文字檔或圖片檔";
            ofd.Filter= "Text Files (*.txt)|*.txt|Image Files (*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
                string extension = Path.GetExtension(filePath).ToLower();
                if (extension == ".txt")
                {
                    textBox1.Text = File.ReadAllText(filePath);
                    textBox1.Visible = true;
                    pictureBox1.Visible = false;
                    button2.Visible = button3.Visible = true;
                }
                else if (extension == ".jpg" || extension == ".png" || extension == ".bmp")
                {
                    pictureBox1.Image = Image.FromFile(filePath);
                    pictureBox1.Visible = true;
                    textBox1.Visible = false;
                }
                else
                {
                    MessageBox.Show("不支援的檔案格式", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("上傳失敗", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Visible = button3.Visible = false;
            pictureBox1.Visible = false;
            textBox1.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(trackBar1.Value * 4, trackBar1.Value * 3);
            textBox1.Size = new Size(trackBar1.Value * 4, trackBar1.Value * 3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.AppendAllText(filePath,textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            File.WriteAllText(filePath,textBox1.Text);
        }
    }
}
