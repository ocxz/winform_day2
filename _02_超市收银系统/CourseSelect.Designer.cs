namespace _02_超市收银系统
{
    partial class CourseSelect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbCourse = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbCourse
            // 
            this.cbCourse.FormattingEnabled = true;
            this.cbCourse.Items.AddRange(new object[] {
            "语文",
            "数学",
            "英语",
            "物理",
            "化学",
            "生物"});
            this.cbCourse.Location = new System.Drawing.Point(21, 41);
            this.cbCourse.Name = "cbCourse";
            this.cbCourse.Size = new System.Drawing.Size(121, 20);
            this.cbCourse.TabIndex = 1;
            this.cbCourse.SelectedIndexChanged += new System.EventHandler(this.CbCourse_SelectedIndexChanged);
            // 
            // CourseSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(167, 196);
            this.Controls.Add(this.cbCourse);
            this.Name = "CourseSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "课程选择";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCourse;
    }
}