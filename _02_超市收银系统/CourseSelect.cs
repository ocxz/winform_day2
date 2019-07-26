using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_超市收银系统
{
    public partial class CourseSelect : Form
    {
        private static CourseSelect courseSelect = new CourseSelect();
        public static CourseSelect GetForm2()
        {
            if (courseSelect.IsDisposed)
            {
                courseSelect = new CourseSelect();
            }
            return courseSelect;
        }
        private CourseSelect()
        {
            InitializeComponent();
        }

        public Label OutLabel
        {
            set;
            get;
        }

        private void CbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                OutLabel.Text = cbCourse.SelectedItem.ToString();
                OutLabel.BackColor = Color.LightCyan;
            }
            catch (Exception)
            {
                OutLabel.Text = "无";
            }
        }
    }
}



