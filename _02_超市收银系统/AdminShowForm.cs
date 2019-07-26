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
    public partial class AdminShowForm : Form
    {
        private Dictionary<string, Dictionary<string, List<string>>> colleges;
        private string college, major;
        private Label[] courseLabels = new Label[20];
        private Panel[] panels = new Panel[20];

        private static AdminShowForm form = new AdminShowForm();
        public static AdminShowForm GetForm()
        {
            if (form.IsDisposed)
            {
                form = new AdminShowForm();
            }
            return form;
        }
        private AdminShowForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载时，要做的处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdminShowForm_Load(object sender, EventArgs e)
        {
            colleges = MyData.LoadData();
            foreach (var item in colleges.Keys)
            {
                cbCollege.Items.Add(item);
            }

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

            panels[0] = panelc11;
            panels[1] = panelc12;
            panels[2] = panelc13;
            panels[3] = panelc14;
            panels[4] = panelc15;
            panels[5] = panelc21;
            panels[6] = panelc22;
            panels[7] = panelc23;
            panels[8] = panelc24;
            panels[9] = panelc25;
            panels[10] = panelc31;
            panels[11] = panelc32;
            panels[12] = panelc33;
            panels[13] = panelc34;
            panels[14] = panelc35;
            panels[15] = panelc41;
            panels[16] = panelc42;
            panels[17] = panelc43;
            panels[18] = panelc44;
            panels[19] = panelc45;
        }

        #region 每个课程框中的点击事件处理
        private void Panelc11_DoubleClick(object sender, EventArgs e)
        {
            ShowSelectCourse(Course11);
        }
        private void Panelc12_DoubleClick(object sender, EventArgs e)
        {
            ShowSelectCourse(Course12);
        }
        private void Panelc13_DoubleClick(object sender, EventArgs e)
        {
            ShowSelectCourse(Course13);
        }
        private void Panelc14_DoubleClick(object sender, EventArgs e)
        {
            ShowSelectCourse(Course14);
        }
        private void Panelc15_DoubleClick(object sender, EventArgs e)
        {
            ShowSelectCourse(Course15);
        }
        private void Panelc21_DoubleClick(object sender, EventArgs e)
        {
            ShowSelectCourse(Course21);
        }
        private void Panelc22_DoubleClick(object sender, EventArgs e)
        {
            ShowSelectCourse(Course22);
        }
        private void Panelc23_DoubleClick(object sender, EventArgs e)
        {
            ShowSelectCourse(Course23);
        }
        private void Panelc24_DoubleClick(object sender, EventArgs e)
        {
            ShowSelectCourse(Course24);
        }
        private void Panelc25_DoubleClick(object sender, EventArgs e)
        {
            ShowSelectCourse(Course25);
        }
        private void Panelc31_DoubleClick(object sender, EventArgs e)
        {
            ShowSelectCourse(Course31);
        }
        private void Panelc32_DoubleClick(object sender, EventArgs e)
        {
            ShowSelectCourse(Course32);
        }
        private void Panelc33_DoubleClick(object sender, EventArgs e)
        {
            ShowSelectCourse(Course33);
        }
        private void Panelc34_DoubleClick(object sender, EventArgs e)
        {
            ShowSelectCourse(Course34);
        }
        private void Panelc35_DoubleClick(object sender, EventArgs e)
        {
            ShowSelectCourse(Course35);
        }
        private void Panelc41_DoubleClick(object sender, EventArgs e)
        {
            ShowSelectCourse(Course41);
        }
        private void Panelc42_DoubleClick(object sender, EventArgs e)
        {
            ShowSelectCourse(Course42);
        }
        private void Panelc43_DoubleClick(object sender, EventArgs e)
        {
            ShowSelectCourse(Course43);
        }
        private void Panelc44_DoubleClick(object sender, EventArgs e)
        {
            ShowSelectCourse(Course44);
        }
        private void Panelc45_DoubleClick(object sender, EventArgs e)
        {
            ShowSelectCourse(Course45);
        }
        #endregion

        #region 课程选择点击处理事件的具体函数

        private void ShowSelectCourse(Label label)
        {
            CourseSelect courseSelect = CourseSelect.GetForm2();
            if (!courseSelect.Visible)
            {
                Point newPoint = new Point(MousePosition.X + 10, MousePosition.Y + 10);
                courseSelect.OutLabel = label;
                courseSelect.Location = newPoint;
                courseSelect.Show(this);
            }

        }

        #endregion

                
        #region 处理课程panel选中问题

        private void CoursePanelSelect(object sender)
        {
            for (int i = 0; i<panels.Length; i++)
            {
                panels[i].BackColor = Color.LightCyan;
                courseLabels[i].BackColor = Color.LightCyan;
            }
        }
        #endregion




        /// <summary>
        /// 学院选择下拉框选择事件，加载专业数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbCollege_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMajor.Items.Clear();
            cbClass.Items.Clear();
            college = cbCollege.SelectedItem.ToString();
            foreach (var item in colleges[college].Keys)
            {
                cbMajor.Items.Add(item);
            }
        }

        /// <summary>
        /// 班级下拉框选择事件，加载班级课表信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbClass.SelectedIndex != -1)
            {
                string[] courseInfo = MyData.GetCouseInfo(cbClass.SelectedItem.ToString());
                if (courseInfo==null||courseInfo.Length == 0)
                {
                    for (int i = 0; i < courseLabels.Length; i++)
                    {
                        courseLabels[i].Text = "无";
                    }
                }
                else
                {
                    for (int i = 0; i < courseInfo.Length; i++)
                    {
                        if (string.IsNullOrEmpty(courseInfo[i]))
                        {
                            courseLabels[i].Text = "无";
                        }
                        else
                        {
                            courseLabels[i].Text = courseInfo[i];
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 提交课表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CourseSubmit_Click(object sender, EventArgs e)
        {
            if (cbCollege.SelectedIndex == -1 || cbMajor.SelectedIndex == -1 || cbClass.SelectedIndex == -1)
            {
                MessageBox.Show("操作有误");
            }
            else
            {
                string[] courses = new string[courseLabels.Length];
                for (int i = 0; i < courses.Length; i++)
                {
                    courses[i] = courseLabels[i].Text;
                }

                MyData.SetCouseInfo(cbClass.SelectedItem.ToString(), courses);
                MessageBox.Show("操作成功");
            }
        }

        /// <summary>
        /// 点击返回登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RLogin_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm.getForm().Show();
        }

        private void Panelc_Click(object sender, EventArgs e)
        {
            CoursePanelSelect(sender);
            Panel panel = (Panel)sender;
            courseLabels[int.Parse(panel.Tag.ToString())].BackColor = Color.LightPink;
            panel.BackColor = Color.LightPink;
        }

        private void AdminShowForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoginForm.getForm().Dispose();
        }


        /// <summary>
        /// 专业选择下拉框事件，加载班级数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbClass.Items.Clear();
            major = cbMajor.SelectedItem.ToString();
            foreach (var item in colleges[college][major])
            {
                cbClass.Items.Add(item);
            }
        }
    }
}
