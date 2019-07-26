namespace testGDI
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ps = new System.Windows.Forms.Panel();
            this.lbCourse = new System.Windows.Forms.ListBox();
            this.tbPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.panel18 = new System.Windows.Forms.Panel();
            this.panel19 = new System.Windows.Forms.Panel();
            this.panel20 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.ps.SuspendLayout();
            this.tbPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 103);
            this.panel1.TabIndex = 0;
            // 
            // ps
            // 
            this.ps.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ps.Controls.Add(this.tbPanel);
            this.ps.Controls.Add(this.lbCourse);
            this.ps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ps.Location = new System.Drawing.Point(0, 103);
            this.ps.Name = "ps";
            this.ps.Size = new System.Drawing.Size(800, 347);
            this.ps.TabIndex = 1;
            // 
            // lbCourse
            // 
            this.lbCourse.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lbCourse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbCourse.FormattingEnabled = true;
            this.lbCourse.ItemHeight = 12;
            this.lbCourse.Items.AddRange(new object[] {
            "语文",
            "数学",
            "英语",
            "物理",
            "化学",
            "生物"});
            this.lbCourse.Location = new System.Drawing.Point(392, 60);
            this.lbCourse.Name = "lbCourse";
            this.lbCourse.Size = new System.Drawing.Size(74, 86);
            this.lbCourse.TabIndex = 0;
            this.lbCourse.SelectedIndexChanged += new System.EventHandler(this.LbCourse_SelectedIndexChanged);
            // 
            // tbPanel
            // 
            this.tbPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tbPanel.ColumnCount = 6;
            this.tbPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tbPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbPanel.Controls.Add(this.panel2, 1, 1);
            this.tbPanel.Controls.Add(this.panel3);
            this.tbPanel.Controls.Add(this.panel4, 2, 1);
            this.tbPanel.Controls.Add(this.panel5, 3, 1);
            this.tbPanel.Controls.Add(this.panel6, 5, 0);
            this.tbPanel.Controls.Add(this.panel7);
            this.tbPanel.Controls.Add(this.panel8);
            this.tbPanel.Controls.Add(this.panel9, 3, 2);
            this.tbPanel.Controls.Add(this.panel10, 4, 1);
            this.tbPanel.Controls.Add(this.panel11, 5, 1);
            this.tbPanel.Controls.Add(this.panel12, 4, 2);
            this.tbPanel.Controls.Add(this.panel13);
            this.tbPanel.Controls.Add(this.panel14, 2, 2);
            this.tbPanel.Controls.Add(this.panel15);
            this.tbPanel.Controls.Add(this.panel16, 4, 3);
            this.tbPanel.Controls.Add(this.panel17, 0, 1);
            this.tbPanel.Controls.Add(this.panel18, 0, 2);
            this.tbPanel.Controls.Add(this.panel19, 1, 2);
            this.tbPanel.Controls.Add(this.panel20, 2, 2);
            this.tbPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPanel.Location = new System.Drawing.Point(0, 0);
            this.tbPanel.Name = "tbPanel";
            this.tbPanel.RowCount = 5;
            this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbPanel.Size = new System.Drawing.Size(798, 345);
            this.tbPanel.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label11);
            this.panel2.Location = new System.Drawing.Point(108, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(131, 69);
            this.panel2.TabIndex = 0;
            this.panel2.DoubleClick += new System.EventHandler(this.Panel2_DoubleClick);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(97, 30);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(246, 41);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(131, 69);
            this.panel4.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(384, 41);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(131, 69);
            this.panel5.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.Location = new System.Drawing.Point(660, 4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(134, 30);
            this.panel6.TabIndex = 4;
            // 
            // panel7
            // 
            this.panel7.Location = new System.Drawing.Point(108, 4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(131, 30);
            this.panel7.TabIndex = 5;
            // 
            // panel8
            // 
            this.panel8.Location = new System.Drawing.Point(246, 4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(131, 30);
            this.panel8.TabIndex = 6;
            // 
            // panel9
            // 
            this.panel9.Location = new System.Drawing.Point(522, 117);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(131, 69);
            this.panel9.TabIndex = 7;
            // 
            // panel10
            // 
            this.panel10.Location = new System.Drawing.Point(522, 41);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(131, 69);
            this.panel10.TabIndex = 8;
            // 
            // panel11
            // 
            this.panel11.Location = new System.Drawing.Point(660, 41);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(134, 69);
            this.panel11.TabIndex = 9;
            // 
            // panel12
            // 
            this.panel12.Location = new System.Drawing.Point(660, 117);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(134, 69);
            this.panel12.TabIndex = 10;
            // 
            // panel13
            // 
            this.panel13.Location = new System.Drawing.Point(384, 4);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(131, 30);
            this.panel13.TabIndex = 11;
            // 
            // panel14
            // 
            this.panel14.Location = new System.Drawing.Point(384, 117);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(131, 69);
            this.panel14.TabIndex = 12;
            // 
            // panel15
            // 
            this.panel15.Location = new System.Drawing.Point(522, 4);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(131, 30);
            this.panel15.TabIndex = 13;
            // 
            // panel16
            // 
            this.panel16.Location = new System.Drawing.Point(522, 193);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(131, 69);
            this.panel16.TabIndex = 14;
            // 
            // panel17
            // 
            this.panel17.Location = new System.Drawing.Point(4, 41);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(97, 69);
            this.panel17.TabIndex = 15;
            // 
            // panel18
            // 
            this.panel18.Location = new System.Drawing.Point(4, 117);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(97, 69);
            this.panel18.TabIndex = 16;
            // 
            // panel19
            // 
            this.panel19.Location = new System.Drawing.Point(108, 117);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(131, 69);
            this.panel19.TabIndex = 17;
            // 
            // panel20
            // 
            this.panel20.Location = new System.Drawing.Point(246, 117);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(131, 69);
            this.panel20.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(55, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "无";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ps);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ps.ResumeLayout(false);
            this.tbPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel ps;
        private System.Windows.Forms.ListBox lbCourse;
        private System.Windows.Forms.TableLayoutPanel tbPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.Label label11;
    }
}

