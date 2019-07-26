using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testGDI
{
    public partial class Form1 : Form
    {
        private string Course = "无";
        public Form1()
        {
            InitializeComponent();
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel2_DoubleClick(object sender, EventArgs e)
        {
            Point newPoint = new Point(MousePosition.X + 10, MousePosition.Y +10);
            Form2 form2 = Form2.GetForm2();
            form2.Location = newPoint;
            Course = form2.Course;
            form2.OutLabel = this.label11;
            form2.Show(this);
            
        }

        private void LbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbPanel.Visible = true;
            try
            {
                label11.Text = lbCourse.SelectedItem.ToString();
            }
            catch (Exception)
            {

                label11.Text = "无";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            
        }
    }
}
