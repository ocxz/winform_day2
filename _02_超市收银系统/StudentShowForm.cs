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
        private Dictionary<string, Dictionary<string, List<string>>> colleges;
        private Label[] courseLabels = new Label[20];

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
            
            

            colleges = MyData.LoadData();

            courseLabels[0] = Course11;
            courseLabels[1] = Course12;
            courseLabels[2] = Course13;
            courseLabels[3] = Course14;
            courseLabels[4] = Course15;
            courseLabels[5] = Course21;
            courseLabels[6] = Course22;
            courseLabels[7] = Course23;
            courseLabels[8] = Course24;
            courseLabels[9] = Course25;
            courseLabels[10] = Course31;
            courseLabels[11] = Course32;
            courseLabels[12] = Course33;
            courseLabels[13] = Course34;
            courseLabels[14] = Course35;
            courseLabels[15] = Course41;
            courseLabels[16] = Course42;
            courseLabels[17] = Course43;
            courseLabels[18] = Course44;
            courseLabels[19] = Course45;

            CourseInit();
        }


        private void CourseInit()
        {
            Student stu = MyData.GetStudent(stuId);
            stuTopLb.Text = "欢迎" + MyData.GetStudent(stuId).Name + "登录";
            timeShowLb.Text = "当前时间：" + DateTime.Now.ToLongTimeString();
            for (int i = 0; i <courseLabels.Length ; i++)
            {
                courseLabels[i].Text = MyData.GetCouseInfo(stu.Class)[i];
            }
        }

        private void StudentShowForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoginForm.getForm().Dispose();
        }
    }
}
