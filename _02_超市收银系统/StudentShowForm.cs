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
    public partial class StudentShowForm : Form
    {
        private static StudentShowForm form = new StudentShowForm();
        public static StudentShowForm GetForm()
        {
            if (form.IsDisposed)
            {
                form = new StudentShowForm();
            }
            return form;
        }
        private StudentShowForm()
        {
            InitializeComponent();
        }

        public string stuId
        {
            set;
            get;
        }

        /// <summary>
        /// 一秒更新一次时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            timeShowLb.Text = "当前时间：" + DateTime.Now.ToLongTimeString();
        }

        /// <summary>
        /// 加载的时候也要初始化当前时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StudentShowForm_Load(object sender, EventArgs e)
        {
            stuTopLb.Text = "欢迎" + MyData.GetStudent(stuId).Name + "登录";
            timeShowLb.Text = "当前时间：" + DateTime.Now.ToLongTimeString();
        }
    }
}
