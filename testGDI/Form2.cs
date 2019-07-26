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
    public partial class Form2 : Form
    {

        private static Form2 form2 = new Form2();
        public Label OutLabel
        {
            set;
            get;
        }
        public static Form2 GetForm2()
        {
            if (form2.IsDisposed)
            {
                form2 = new Form2();
            }
            return form2;
        }

        private Form2()
        {
            InitializeComponent();
            this.Course = "无";
        }

        public string Course
        {
            set;
            get;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                this.Course = cbCourse.SelectedItem.ToString();
                OutLabel.Text = this.Course;
            }
            catch (Exception)
            {
                this.Course = "无";
            }
        }
    }
}
