using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;

namespace _02_超市收银系统
{
    public partial class RegisterForm : Form
    {
        // 用来辨别账户类型 学生1、老师2、管理员3
        private static int category = 1;

        private Dictionary<string, Dictionary<string, List<string>>> colleges;

        #region 第一步：窗体的初始化|生成 采用单例设计模式

        private static RegisterForm rform = new RegisterForm();

        /// <summary>
        /// 得到一个窗体对象，如果被销毁，则另创
        /// </summary>
        /// <returns>返回RegisterForm对象</returns>
        public static RegisterForm getRegisterForm()
        {
            if (rform.IsDisposed)   // 如果窗体被销毁，直接另创一个窗体
            {
                rform = new RegisterForm();
            }
            return rform;
        }

        private RegisterForm()
        {
            InitializeComponent();
        }

        #endregion

        #region 第二步：窗体加载时的代码

        /// <summary>
        /// 注册窗口加载时，处理的事情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private void RegisterForm_Load_1(object sender, EventArgs e)
        {
            runInput.Focus();
            runInfoLabel.Visible = false;
            rupInfoLabel.Visible = false;
            rrupInfoLabel.Visible = false;
            rStudentPanel.Visible = false;

            colleges = MyData.LoadData();

            rsCollege.Items.Clear();
            foreach (var item in colleges.Keys)
            {
                rsCollege.Items.Add(item);
            }
        }

        #endregion

        #region 一些常用方法：

        /// <summary>
        /// 按下enter键，焦点到指定文本输入框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="tb"></param>
        private void EnterToNext(KeyEventArgs e, TextBox tb)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tb.Focus();
            }
        }

        /// <summary>
        /// 指定一个或多个文本置空
        /// </summary>
        /// <param name="tb"></param>
        private void TextBoxTextToNull(params TextBox[] tb)
        {
            for (int i = 0; i < tb.Length; i++)
            {
                tb[i].Text = null;
            }
        }

        /// <summary>
        /// 检测输入名字字段是否合法 （空，已存在，太长，太短）
        /// </summary>
        /// <param name="name">要检查名字字段</param>
        /// <param name="category">账户类别：学生1 老师2 管理员3</param>
        /// <param name="message">返回检测的信息</param>
        /// <returns>检测的结果</returns>
        private bool CheckName(string name, int category, out string message)
        {
            if (string.IsNullOrEmpty(name))  // 用户没有输入用户名或者只打了一连串的空格
            {
                message = "*请输入用户名";
                return false;
            }
            else if (MyData.GetManFormCate(category, name) != null)
            {
                message = "*用户名已存在";
                return false;
            }
            else
            {
                if (!CheckInputLength(name, 6, 12, out message))   // 长度检查
                {
                    message = "*用户名" + message;
                    return false;
                }
                else
                {
                    message = "";
                    return true;
                }
            }
        }
        private bool CheckName(string name, int categroy, Label nameInfoLabel)
        {
            string message;
            nameInfoLabel.Visible = !CheckName(name.Trim(), categroy, out message);
            nameInfoLabel.Text = message;
            return !nameInfoLabel.Visible;
        }

        /// <summary>
        /// 检查密码输入是否合法 （空，太长，太短）
        /// </summary>
        /// <param name="password">要检查的密码</param>
        /// <param name="pwdInfoLabel">提示信息Label</param>
        /// <returns>检查的结果</returns>
        private bool CheckPwd(string password, Label pwdInfoLabel)
        {
            string pwdInfo;
            pwdInfoLabel.Visible = !CheckInputLength(password, 6, 12, out pwdInfo);
            pwdInfoLabel.Text = "*密码" + pwdInfo;
            return !pwdInfoLabel.Visible;
        }

        /// <summary>
        /// 检验确定密码输入是否合法
        /// </summary>
        /// <param name="rpassword">确定密码</param>
        /// <param name="password">密码</param>
        /// <param name="rpwdInfoLabel">确定密码提示Label</param>
        /// <param name="pwdInfoLabel">密码提示Label</param>
        /// <returns>返回检验的结果</returns>
        private bool CheckRPwd(string rpassword, string password, Label rpwdInfoLabel, Label pwdInfoLabel, TextBox pwdtb)
        {
            if (CheckPwd(password, pwdInfoLabel))   // 密码合法
            {
                string rpasswordInfo;
                if (CheckInputLength(rpassword, 6, 12, out rpasswordInfo))  // 确定密码长度合法
                {
                    rpwdInfoLabel.Visible = !CheckTowStringEqu(rpassword, password, out rpasswordInfo);
                    rpwdInfoLabel.Text = "*两次密码输入" + rpasswordInfo;
                }
                else   // 确定密码长度不合法
                {
                    rpwdInfoLabel.Visible = true;
                    rpwdInfoLabel.Text = "*确定密码" + rpasswordInfo;
                }
            }
            else   // 密码不合法，焦点到密码框
            {
                pwdtb.Focus();
                return false;
            }
            return !rpwdInfoLabel.Visible;   // 返回检验成果
        }

        /// <summary>
        /// 判断两个字符串是否一致
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private bool CheckTowStringEqu(string str1, string str2, out string message)
        {
            if (str1 == null || str2 == null)
            {
                message = "为空，无法判断";
                return false;
            }
            else if (str1 == str2)
            {
                message = "";
                return true;
            }
            else
            {
                message = "不一致";
                return false;
            }
        }

        /// <summary>
        /// 检测字符串的长度问题
        /// </summary>
        /// <param name="input">要检查的字符串</param>
        /// <param name="minLength">最短长度</param>
        /// <param name="maxLength">最大长度</param>
        /// <param name="message">返回检测信息</param>
        /// <returns>返回检测结果</returns>
        private bool CheckInputLength(string input, int minLength, int maxLength, out string message)
        {
            if (string.IsNullOrEmpty(input))
            {
                message = "不能为空";
                return false;
            }
            else if (input.Length < minLength)
            {
                message = "太短了";
                return false;
            }
            else if (input.Length > maxLength)
            {
                message = "太长了";
                return false;
            }
            else
            {
                message = "";
                return true;
            }
        }

        /// <summary>
        /// 检查邮箱输入是否合法
        /// </summary>
        /// <param name="email">要检查的邮箱</param>
        /// <param name="messageLabel">邮箱检查后的Label信息</param>
        /// <returns>返回检查的结果</returns>
        private bool CheckEmail(string email, Label messageLabel)
        {
            if (string.IsNullOrEmpty(email.Trim()))
            {
                messageLabel.Text = "*请输入常用邮箱";
                messageLabel.Visible = true;
            }
            else
            {
                if (MyData.GetVerifier(VerifierKeep.Email).IsValidity(email))
                {
                    if (MyData.EmailIsExist(email))
                    {
                        messageLabel.Text = "*该邮箱已被注册";
                        messageLabel.Visible = true;
                    }
                    else
                    {
                        messageLabel.Visible = false;
                    }
                }
                else
                {
                    messageLabel.Text = "*邮箱格式不正确";
                    messageLabel.Visible = true;
                }
            }

            return !messageLabel.Visible;
        }

        /// <summary>
        /// 根据用户类型框，来确定用户类型
        /// </summary>
        private void HanderCateChange()
        {
            if (rbStudent.Checked)
            {
                category = 1;
            }
            else if (rbTeacher.Checked)
            {
                category = 2;
            }
            else
            {
                category = 3;
            }
        }

        /// <summary>
        /// 验证手机号是否合法
        /// </summary>
        /// <param name="phone">要验证的手机号</param>
        /// <param name="messageLabel">验证信息提示Label</param>
        /// <returns>验证的结果</returns>
        private bool CheckPhone(string phone, Label messageLabel)
        {
            if (string.IsNullOrEmpty(phone.Trim()))   // 输入为空
            {
                messageLabel.Text = "*请输入手机号";
                messageLabel.Visible = true;
            }
            else
            {
                if (MyData.GetVerifier(VerifierKeep.Phone).IsValidity(phone))   // 验证输入手机号是否合法
                {
                    if (MyData.PhoneIsExist(phone))   // 判断手机号是否已存在
                    {
                        messageLabel.Text = "*手机号已被注册";
                        messageLabel.Visible = true;
                    }
                    else
                    {
                        messageLabel.Visible = false;
                    }
                }
                else   // 手机号不合法
                {
                    messageLabel.Text = "*手机号格式不正确";
                    messageLabel.Visible = true;
                }
            }

            return !messageLabel.Visible;
        }

        /// <summary>
        /// 检测用户名是否合法
        /// </summary>
        /// <param name="uName">要检查的用户名</param>
        /// <param name="messageLabel">检测信息的提示Label</param>
        /// <returns>返回的检测结果</returns>
        private bool CheckUserName(string uName, Label messageLabel)
        {
            if (string.IsNullOrEmpty(uName.Trim()))
            {
                messageLabel.Text = "*姓名不能为空";
                messageLabel.Visible = true;
            }
            else
            {
                if (MyData.GetVerifier(VerifierKeep.Name).IsValidity(uName))   // 用户名合法
                {
                    messageLabel.Visible = false;
                }
                else
                {
                    messageLabel.Text = "*用户名输入不合法";
                    messageLabel.Visible = true;
                }
            }
            return !messageLabel.Visible;
        }

        /// <summary>
        /// 将List<string>中的数据，加到ListBox中
        /// </summary>
        /// <param name="lb"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private bool ListAddToListBox(ComboBox cb, List<string> data)
        {
            if (data.Count == 0)
            {
                return false;
            }
            else
            {
                foreach (var item in data)
                {
                    cb.Items.Add(item);
                }
                return true;
            }
        }

        /// <summary>
        /// 检测combox的下拉选择的合法性
        /// </summary>
        /// <param name="cb">要检查的combox下拉框</param>
        /// <param name="messageLabel">检查信息的提示Label</param>
        /// <param name="exInfo">信息追加的字符串</param>
        /// <returns>返回检查的结果</returns>
        private bool CheckCbInput(ComboBox cb, Label messageLabel, string exInfo)
        {
            messageLabel.Text = "*请选择" + exInfo;
            messageLabel.Visible = cb.SelectedIndex <= -1;
            return !messageLabel.Visible;
        }

        #endregion

        #region 第三步：注册的主窗体代码

        /// <summary>
        /// 用户名输入时，密码和确认密码重置为空 提示信息消失
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunInput_TextChanged(object sender, EventArgs e)
        {
            TextBoxTextToNull(rupInput, rrupInput);
            runInfoLabel.Visible = false;
        }

        /// <summary>
        /// 当用户名输入框失去焦点时 检测输入用的名字，展示错误信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunInput_Leave(object sender, EventArgs e)
        {
            HanderCateChange();
            string message;
            runInfoLabel.Visible = !CheckName(runInput.Text.Trim(), 1, out message);
            runInfoLabel.Text = message;
        }

        /// <summary>
        /// 用户输入框，按下enter键，焦点到rupInput中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunInput_KeyDown(object sender, KeyEventArgs e)
        {
            EnterToNext(e, rupInput);
        }

        /// <summary>
        /// 密码输入时，确认密码重置为空 密码提示消失
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RupInput_TextChanged(object sender, EventArgs e)
        {
            TextBoxTextToNull(rrupInput);
            rupInfoLabel.Visible = false;
        }

        /// <summary>
        /// 离开密码输入框失去焦点时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RupInput_Leave(object sender, EventArgs e)
        {
            CheckPwd(rupInput.Text, rupInfoLabel);
        }

        /// <summary>
        /// 密码输入框，按下enter键，焦点到rrupInput中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RupInput_KeyDown(object sender, KeyEventArgs e)
        {
            EnterToNext(e, rrupInput);
        }

        /// <summary>
        /// 确定密码输入时，提示信息消除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RrupInput_TextChanged(object sender, EventArgs e)
        {
            rrupInfoLabel.Visible = false;
        }

        /// <summary>
        /// 确定密码框失去焦点时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RrupInput_Leave(object sender, EventArgs e)
        {
            CheckRPwd(rrupInput.Text, rupInput.Text, rrupInfoLabel, rupInfoLabel, rupInput);
        }

        /// <summary>
        /// 确定密码框，点击Enter直接激活注册按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RrupInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnRegister1_Click(sender, e);
            }
        }

        #region 事件：用户类型单项按钮点击时 分别触发的三个点击按钮

        /// <summary>
        /// 当学生状态发生改变时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RbStudent_CheckedChanged(object sender, EventArgs e)
        {
            HanderCateChange();
            string info;
            runInfoLabel.Visible = !CheckName(runInput.Text.Trim(), 1, out info);
            runInfoLabel.Text = info;
        }

        /// <summary>
        /// 老师状态发生改变触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RbTeacher_CheckedChanged(object sender, EventArgs e)
        {
            HanderCateChange();
            string info;
            runInfoLabel.Visible = !CheckName(runInput.Text.Trim(), 2, out info);
            runInfoLabel.Text = info;
        }

        /// <summary>
        /// 管理员状态改变触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RbAdmin_CheckedChanged(object sender, EventArgs e)
        {
            HanderCateChange();
            string info;
            runInfoLabel.Visible = !CheckName(runInput.Text.Trim(), 3, out info);
            runInfoLabel.Text = info;
        }

        #endregion

        /// <summary>
        /// 注册按钮点击事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRegister1_Click(object sender, EventArgs e)
        {
            CheckName(runInput.Text, category, runInfoLabel);
            CheckPwd(rupInput.Text, rupInfoLabel);
            CheckRPwd(rrupInput.Text, rupInput.Text, rrupInfoLabel, rupInfoLabel, rupInput);
            if (runInfoLabel.Visible || rupInfoLabel.Visible || rrupInfoLabel.Visible)
            {
                MessageBox.Show("输入不合法");
            }
            else
            {
                switch (category)
                {
                    case 1:
                        MessageBox.Show("学生注册成功");
                        rStudentPanel.Visible = true;
                        break;
                    case 2:
                        MessageBox.Show("老师注册成功");
                        break;
                    case 3:
                        MessageBox.Show("管理员注册成功");
                        rStudentPanel.Visible = true;
                        rAdminPanel.Visible = true;
                        break;
                }
            }
        }

        #endregion


        #region 第四步：学生注册信息补充提交

        /// <summary>
        /// 学生输入名字时，提示取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RsNameInput_TextChanged(object sender, EventArgs e)
        {
            rsNameInfo.Visible = false;

        }

        /// <summary>
        /// 学生名字输入框失去焦点时，触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RsNameInput_Leave(object sender, EventArgs e)
        {
            CheckUserName(rsNameInput.Text.Trim(), rsNameInfo);
        }

        /// <summary>
        /// 学生手机号码输入框，输入时，提示信息消失
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RsPhone_TextChanged(object sender, EventArgs e)
        {
            rsphoneInfo.Visible = false;
        }

        /// <summary>
        /// 学生手机号码输入框，失去焦点时，检测手机号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RsPhone_Leave(object sender, EventArgs e)
        {
            CheckPhone(rsPhone.Text.Trim(), rsphoneInfo);
        }

        /// <summary>
        /// 学生手机号码输入框按下Enter键时，电子邮箱输入框获得焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RsPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rsEmail.Focus();
            }
        }

        /// <summary>
        /// 学生电子邮箱输入时，提示信息消失
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RsEmail_TextChanged(object sender, EventArgs e)
        {
            rsemailInfo.Visible = false;
        }

        /// <summary>
        /// 学生电子邮箱失去焦点时，检测邮箱输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RsEmail_Leave(object sender, EventArgs e)
        {
            CheckEmail(rsEmail.Text.Trim(), rsemailInfo);
        }

        /// <summary>
        /// 学生电子邮箱输入框输入Enter键时，直接激活提交按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RsEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RsbtnSubmit_Click(sender, e);
            }
        }

        /// <summary>
        /// 选择学院，根据学院，来加载班级
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RsCollege_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CheckCbInput(rsCollege, rsCollegeInfo, "学院"))   // 检查合格
            {
                rsMajorInput.Items.Clear();
                foreach (var item in colleges[rsCollege.SelectedItem.ToString()].Keys)
                {
                    rsMajorInput.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// 根据专业，加载班级数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RsMajorInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CheckCbInput(rsMajorInput, rsMajorInfo, "所选专业"))
            {
                rsClass.Items.Clear();
                foreach (var item in colleges[rsCollege.SelectedItem.ToString()][rsMajorInput.SelectedItem.ToString()])
                {
                    rsClass.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// 选择班级，提示信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RsClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckCbInput(rsClass, rsClassInfo, "班级");
        }

        /// <summary>
        /// 点击提交，保存学生注册的个人信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RsbtnSubmit_Click(object sender, EventArgs e)
        {

            CheckUserName(rsNameInput.Text.Trim(), rsNameInfo);
            CheckPhone(rsPhone.Text.Trim(), rsphoneInfo);
            CheckEmail(rsEmail.Text.Trim(), rsemailInfo);
            CheckCbInput(rsCollege, rsCollegeInfo, "学院");
            CheckCbInput(rsMajorInput, rsMajorInfo, "专业");
            CheckCbInput(rsClass, rsClassInfo, "班级");


            if (rsNameInfo.Visible || rsCollegeInfo.Visible || rsMajorInfo.Visible || rsClassInfo.Visible || rsphoneInfo.Visible || rsemailInfo.Visible)
            {
                MessageBox.Show("信息填入错误，提交失败");
            }
            else
            {
                string userName = runInput.Text.Trim();
                string userPwd = rupInput.Text;
                string name = rsNameInput.Text;
                char gender = rsGenderM.Checked ? '男' : '女';
                string birthday = rsAgeInput.Value.Date.ToShortDateString();
                string college = rsCollege.SelectedItem.ToString();
                string major = rsMajorInput.SelectedItem.ToString();
                string classes = rsClass.SelectedItem.ToString();
                string phone = rsPhone.Text;
                string email = rsEmail.Text;
                Student stu = new Student(userName, userPwd, name, birthday, gender, phone, email, college, major, classes);
                if (MyData.AddManOfCate(category, userName, stu))
                {
                    MessageBox.Show("提交成功");
                    LoginForm loginForm = LoginForm.getForm();
                    loginForm.loginName = runInput.Text.Trim();
                    loginForm.loginPwd = rupInput.Text;
                    loginForm.category = category;
                    MyUtils.SetFocus(loginForm.nameTextBox);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("提交失败");
                }

            }
        }

        #endregion

        #region 管理员信息补充

        /// <summary>
        /// 管理员姓名输入框，输入时，提示消失
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RaNameInput_TextChanged(object sender, EventArgs e)
        {
            raNameInfo.Visible = false;
        }

        /// <summary>
        /// 管理员姓名输入框失去焦点时，检查输入名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RaNameInput_Leave(object sender, EventArgs e)
        {
            CheckUserName(raNameInput.Text.Trim(), raNameInfo);
        }

        /// <summary>
        /// 管理员手机号输入时，提示消失
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RaPhoneInput_TextChanged(object sender, EventArgs e)
        {
            raPhoneInfo.Visible = false;
        }

        /// <summary>
        /// 管理员手机号输入框失去焦点时，检查手机号输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RaPhoneInput_Leave(object sender, EventArgs e)
        {
            CheckPhone(raPhoneInput.Text.Trim(), raPhoneInfo);
        }

        /// <summary>
        /// 管理员手机号输入框按下Enter键后，焦点在邮箱输入框中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RaPhoneInput_KeyDown(object sender, KeyEventArgs e)
        {
            EnterToNext(e, raEmailInput);
        }

        /// <summary>
        /// 管理员邮箱输入时，提示消失
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RaEmailInput_TextChanged(object sender, EventArgs e)
        {
            raEmailInfo.Visible = false;
        }

        /// <summary>
        /// 管理员邮箱输入框，失去焦点时，检查邮箱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RaEmailInput_Leave(object sender, EventArgs e)
        {
            CheckEmail(raEmailInput.Text.Trim(), raEmailInfo);
        }

        /// <summary>
        /// 管理员邮箱输入框，按下Enter键时，激活提交按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RaEmailInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RaSubmit_Click(sender, e);
            }
        }




        /// <summary>
        /// 管理员点击提交按钮时，检查姓名、手机号、邮箱，加入数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RaSubmit_Click(object sender, EventArgs e)
        {
            CheckUserName(raNameInput.Text.Trim(), raNameInfo);
            CheckPhone(raPhoneInput.Text.Trim(), raPhoneInfo);
            CheckEmail(raEmailInput.Text.Trim(), raEmailInfo);

            if (raNameInfo.Visible || raPhoneInfo.Visible || raEmailInfo.Visible)
            {
                MessageBox.Show("输入不合法，提交失败");
            }
            else
            {
                string aName = runInput.Text.Trim();
                string aPwd = rupInput.Text;
                string aUserName = raNameInput.Text.Trim();
                string aBirthday = raBirthday.Value.Date.ToShortDateString();
                char agender = raGenderM.Checked ? '男' : '女';
                string aPhone = raPhoneInput.Text.Trim();
                string aEmail = raEmailInput.Text.Trim();

                // 如果添加成功 提示 关闭注册框
                if (MyData.AddAdmin(aName, new Admin(aName, aPwd, aUserName, aBirthday, agender, aPhone, aEmail)))
                {
                    MessageBox.Show("提交成功");
                    LoginForm loginForm = LoginForm.getForm();
                    loginForm.loginName = runInput.Text.Trim();
                    loginForm.loginName = rupInput.Text;
                    loginForm.category = category;
                    MyUtils.SetFocus(loginForm.nameTextBox);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("提交失败");
                }
            }
        }





        #endregion

    }
}
