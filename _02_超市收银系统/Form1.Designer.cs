namespace _02_超市收银系统
{
    partial class LoginForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.unLabel = new System.Windows.Forms.Label();
            this.upLabel = new System.Windows.Forms.Label();
            this.unInput = new System.Windows.Forms.TextBox();
            this.upInput = new System.Windows.Forms.TextBox();
            this.btnReg = new System.Windows.Forms.Button();
            this.btnCbPwd = new System.Windows.Forms.Button();
            this.cbRemPwd = new System.Windows.Forms.CheckBox();
            this.cbAtuoLogin = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.rbStu = new System.Windows.Forms.RadioButton();
            this.rbTea = new System.Windows.Forms.RadioButton();
            this.rbAdmin = new System.Windows.Forms.RadioButton();
            this.upSeePwd = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upSeePwd)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 94);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(192, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "欢迎登录";
            // 
            // unLabel
            // 
            this.unLabel.AutoSize = true;
            this.unLabel.Location = new System.Drawing.Point(129, 143);
            this.unLabel.Name = "unLabel";
            this.unLabel.Size = new System.Drawing.Size(53, 12);
            this.unLabel.TabIndex = 1;
            this.unLabel.Text = "用户名：";
            // 
            // upLabel
            // 
            this.upLabel.AutoSize = true;
            this.upLabel.Location = new System.Drawing.Point(129, 199);
            this.upLabel.Name = "upLabel";
            this.upLabel.Size = new System.Drawing.Size(47, 12);
            this.upLabel.TabIndex = 2;
            this.upLabel.Text = "密 码：";
            // 
            // unInput
            // 
            this.unInput.Location = new System.Drawing.Point(188, 140);
            this.unInput.Margin = new System.Windows.Forms.Padding(5);
            this.unInput.Name = "unInput";
            this.unInput.Size = new System.Drawing.Size(199, 21);
            this.unInput.TabIndex = 3;
            // 
            // upInput
            // 
            this.upInput.Location = new System.Drawing.Point(188, 190);
            this.upInput.Margin = new System.Windows.Forms.Padding(5);
            this.upInput.Name = "upInput";
            this.upInput.PasswordChar = '*';
            this.upInput.Size = new System.Drawing.Size(199, 21);
            this.upInput.TabIndex = 4;
            this.upInput.TextChanged += new System.EventHandler(this.UpInput_TextChanged);
            // 
            // btnReg
            // 
            this.btnReg.BackColor = System.Drawing.Color.Linen;
            this.btnReg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReg.Location = new System.Drawing.Point(413, 140);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(75, 23);
            this.btnReg.TabIndex = 5;
            this.btnReg.Text = "注册账号";
            this.btnReg.UseVisualStyleBackColor = false;
            this.btnReg.Click += new System.EventHandler(this.BtnReg_Click);
            // 
            // btnCbPwd
            // 
            this.btnCbPwd.BackColor = System.Drawing.Color.Linen;
            this.btnCbPwd.Location = new System.Drawing.Point(413, 187);
            this.btnCbPwd.Name = "btnCbPwd";
            this.btnCbPwd.Size = new System.Drawing.Size(75, 23);
            this.btnCbPwd.TabIndex = 6;
            this.btnCbPwd.Text = "找回密码";
            this.btnCbPwd.UseVisualStyleBackColor = false;
            // 
            // cbRemPwd
            // 
            this.cbRemPwd.AutoSize = true;
            this.cbRemPwd.Font = new System.Drawing.Font("宋体", 8F);
            this.cbRemPwd.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbRemPwd.Location = new System.Drawing.Point(188, 261);
            this.cbRemPwd.Name = "cbRemPwd";
            this.cbRemPwd.Size = new System.Drawing.Size(68, 15);
            this.cbRemPwd.TabIndex = 7;
            this.cbRemPwd.Text = "记住密码";
            this.cbRemPwd.UseVisualStyleBackColor = true;
            // 
            // cbAtuoLogin
            // 
            this.cbAtuoLogin.AutoSize = true;
            this.cbAtuoLogin.Font = new System.Drawing.Font("宋体", 8F);
            this.cbAtuoLogin.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbAtuoLogin.Location = new System.Drawing.Point(319, 261);
            this.cbAtuoLogin.Name = "cbAtuoLogin";
            this.cbAtuoLogin.Size = new System.Drawing.Size(68, 15);
            this.cbAtuoLogin.TabIndex = 8;
            this.cbAtuoLogin.Text = "自动登录";
            this.cbAtuoLogin.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Teal;
            this.btnLogin.Font = new System.Drawing.Font("幼圆", 13F);
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLogin.Location = new System.Drawing.Point(188, 294);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(199, 44);
            this.btnLogin.TabIndex = 9;
            this.btnLogin.Text = "登 录";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // rbStu
            // 
            this.rbStu.AutoSize = true;
            this.rbStu.Checked = true;
            this.rbStu.Location = new System.Drawing.Point(188, 226);
            this.rbStu.Name = "rbStu";
            this.rbStu.Size = new System.Drawing.Size(47, 16);
            this.rbStu.TabIndex = 10;
            this.rbStu.TabStop = true;
            this.rbStu.Text = "学生";
            this.rbStu.UseVisualStyleBackColor = true;
            // 
            // rbTea
            // 
            this.rbTea.AutoSize = true;
            this.rbTea.Location = new System.Drawing.Point(267, 226);
            this.rbTea.Name = "rbTea";
            this.rbTea.Size = new System.Drawing.Size(47, 16);
            this.rbTea.TabIndex = 11;
            this.rbTea.TabStop = true;
            this.rbTea.Text = "老师";
            this.rbTea.UseVisualStyleBackColor = true;
            // 
            // rbAdmin
            // 
            this.rbAdmin.AutoSize = true;
            this.rbAdmin.Location = new System.Drawing.Point(346, 226);
            this.rbAdmin.Name = "rbAdmin";
            this.rbAdmin.Size = new System.Drawing.Size(59, 16);
            this.rbAdmin.TabIndex = 12;
            this.rbAdmin.TabStop = true;
            this.rbAdmin.Text = "管理员";
            this.rbAdmin.UseVisualStyleBackColor = true;
            // 
            // upSeePwd
            // 
            this.upSeePwd.Image = ((System.Drawing.Image)(resources.GetObject("upSeePwd.Image")));
            this.upSeePwd.Location = new System.Drawing.Point(361, 191);
            this.upSeePwd.Name = "upSeePwd";
            this.upSeePwd.Size = new System.Drawing.Size(22, 19);
            this.upSeePwd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.upSeePwd.TabIndex = 13;
            this.upSeePwd.TabStop = false;
            this.upSeePwd.Visible = false;
            this.upSeePwd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UpSeePwd_MouseDown);
            this.upSeePwd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UpSeePwd_MouseUp);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(560, 367);
            this.Controls.Add(this.upSeePwd);
            this.Controls.Add(this.rbAdmin);
            this.Controls.Add(this.rbTea);
            this.Controls.Add(this.rbStu);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.cbAtuoLogin);
            this.Controls.Add(this.cbRemPwd);
            this.Controls.Add(this.btnCbPwd);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.upInput);
            this.Controls.Add(this.unInput);
            this.Controls.Add(this.upLabel);
            this.Controls.Add(this.unLabel);
            this.Controls.Add(this.panel1);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upSeePwd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label unLabel;
        private System.Windows.Forms.Label upLabel;
        private System.Windows.Forms.TextBox unInput;
        private System.Windows.Forms.TextBox upInput;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Button btnCbPwd;
        private System.Windows.Forms.CheckBox cbRemPwd;
        private System.Windows.Forms.CheckBox cbAtuoLogin;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.RadioButton rbStu;
        private System.Windows.Forms.RadioButton rbTea;
        private System.Windows.Forms.RadioButton rbAdmin;
        private System.Windows.Forms.PictureBox upSeePwd;
    }
}

