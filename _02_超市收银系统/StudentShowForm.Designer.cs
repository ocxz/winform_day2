namespace _02_超市收银系统
{
    partial class StudentShowForm
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
            this.components = new System.ComponentModel.Container();
            this.stuTopLb = new System.Windows.Forms.Label();
            this.timeShowLb = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // stuTopLb
            // 
            this.stuTopLb.AutoSize = true;
            this.stuTopLb.Font = new System.Drawing.Font("宋体", 10F);
            this.stuTopLb.Location = new System.Drawing.Point(40, 24);
            this.stuTopLb.Name = "stuTopLb";
            this.stuTopLb.Size = new System.Drawing.Size(35, 14);
            this.stuTopLb.TabIndex = 0;
            this.stuTopLb.Text = "欢迎";
            // 
            // timeShowLb
            // 
            this.timeShowLb.AutoSize = true;
            this.timeShowLb.Location = new System.Drawing.Point(661, 9);
            this.timeShowLb.Name = "timeShowLb";
            this.timeShowLb.Size = new System.Drawing.Size(65, 12);
            this.timeShowLb.TabIndex = 1;
            this.timeShowLb.Text = "当前时间：";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // StudentShowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.timeShowLb);
            this.Controls.Add(this.stuTopLb);
            this.Name = "StudentShowForm";
            this.Text = "StudentShowForm";
            this.Load += new System.EventHandler(this.StudentShowForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label stuTopLb;
        private System.Windows.Forms.Label timeShowLb;
        private System.Windows.Forms.Timer timer1;
    }
}