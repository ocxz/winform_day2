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
    public partial class LoginForm : Form
    {
        private static LoginForm loginForm = new LoginForm();
        public string loginName;
        public string loginPwd;
        public int category;
        public TextBox nameTextBox;
        public static LoginForm getForm()
        {
            return loginForm;
        }
        private LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 点击登录按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(unInput.Text.Trim()) || string.IsNullOrEmpty(upInput.Text))
            {
                MessageBox.Show("用户名或密码不能为空");
                return;
            }
            string id = unInput.Text.Trim();
            string pwd = upInput.Text;
            string message;
            if (rbStu.Checked)
            {
                if(CheckLogin(1, id, pwd, out message))  // 如果登录成功
                {
                    this.Hide();
                    StudentShowForm.GetForm().stuId = unInput.Text.Trim();
                    StudentShowForm.GetForm().Show(this);
                    MessageBox.Show("学生登录成功");
                }
                MessageBox.Show(message);
            }
            else if (rbTea.Checked)
            {
                if (CheckLogin(2, id, pwd, out message))  // 如果登录成功
                {
                    MessageBox.Show("老师登录成功");
                    return;
                }
                MessageBox.Show(message);
            }
            else
            {
                if (CheckLogin(3, id, pwd, out message))  // 如果登录成功
                {
                    this.Hide();
                    AdminShowForm.GetForm().Show(this);
                }
                MessageBox.Show(message);
            }
        }

        /// <summary>
        /// 用来核对登录成功否
        /// </summary>
        /// <param name="category">账户类别</param>
        /// <param name="id">账户id</param>
        /// <param name="pwd">账户密码</param>
        /// <param name="message">返回核对信息</param>
        /// <returns>返回核对结果</returns>
        private bool CheckLogin(int category, string id, string pwd, out string message)
        {
            if (MyData.GetManFormCate(category, id) == null)
            {
                message = "用户名不存在";
                return false;
            }
            else
            {
                Person person = (Person)MyData.GetManFormCate(category, id);
                if (pwd != person.UPwd)
                {
                    message = "密码错误";
                    return false;
                }
                else
                {
                    message = "登录成功";
                    return true;
                }
            }
        }

        /// <summary>
        /// 点击注册，弹出注册框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReg_Click(object sender, EventArgs e)
        {
            RegisterForm rForm = RegisterForm.getRegisterForm();
            rForm.Show();
        }

        /// <summary>
        /// 窗体加载时，要干的事情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginForm_Load(object sender, EventArgs e)
        {
            unInput.Focus();
            nameTextBox = unInput;
        }

        private void UpInput_TextChanged(object sender, EventArgs e)
        {
            if (upInput.Text.Length > 5)
            {
                upSeePwd.Visible = true;
            }
            else
            {
                upSeePwd.Visible = false;
            }
        }

        private void UpSeePwd_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
            {
                upInput.PasswordChar = '\0';
            }
        }

        private void UpSeePwd_MouseUp(object sender, MouseEventArgs e)
        {
            upInput.PasswordChar = '*';
        }

        private void LoginForm_Activated(object sender, EventArgs e)
        {

        }

        private void UnInput_Enter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(loginName))
            {
                unInput.Text = loginName;
                upInput.Text = loginPwd;
                switch (category)
                {
                    case 1:
                        rbStu.Checked = true;
                        break;
                    case 2:
                        rbTea.Checked = true;
                        break;
                    case 3:
                        rbAdmin.Checked = true;
                        break;
                }
            }
        }
    }
}
