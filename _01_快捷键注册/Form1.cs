using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_快捷键注册
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 点击项目，弹出一个对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 项目PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
        }

        /// <summary>
        /// 给窗体注册快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.A && e.Alt)
            {
                textBox1.Text = "+";
                textBox1.BackColor = Color.Yellow;
            }

            if(e.KeyCode == Keys.B && e.Alt)
            {
                textBox1.Text = "-";
                textBox1.BackColor = Color.Blue;
            }

            if(e.KeyCode == Keys.C && e.Alt)
            {
                textBox1.Text = "*";
                textBox1.BackColor = Color.Pink;
            }

            if(e.KeyCode == Keys.D && e.Alt)
            {
                textBox1.Text = "/";
                textBox1.BackColor = Color.Green;
            }
        }
    }
}
