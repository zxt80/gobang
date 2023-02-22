
namespace gobang
{
    partial class Form1
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
            this.btn_start = new System.Windows.Forms.Button();
            this.checkBox_ai = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbt_color_black = new System.Windows.Forms.RadioButton();
            this.rbt_color_white = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbt_second = new System.Windows.Forms.RadioButton();
            this.rbt_frist = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(726, 327);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(150, 40);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "开始";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox_ai
            // 
            this.checkBox_ai.AutoSize = true;
            this.checkBox_ai.Location = new System.Drawing.Point(726, 276);
            this.checkBox_ai.Name = "checkBox_ai";
            this.checkBox_ai.Size = new System.Drawing.Size(90, 22);
            this.checkBox_ai.TabIndex = 2;
            this.checkBox_ai.Text = "人机对战";
            this.checkBox_ai.UseVisualStyleBackColor = true;
            this.checkBox_ai.Click += new System.EventHandler(this.checkBox_ai_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbt_color_white);
            this.groupBox1.Controls.Add(this.rbt_color_black);
            this.groupBox1.Location = new System.Drawing.Point(726, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择棋子颜色";
            // 
            // rbt_color_black
            // 
            this.rbt_color_black.AutoSize = true;
            this.rbt_color_black.Checked = true;
            this.rbt_color_black.Location = new System.Drawing.Point(27, 26);
            this.rbt_color_black.Name = "rbt_color_black";
            this.rbt_color_black.Size = new System.Drawing.Size(59, 22);
            this.rbt_color_black.TabIndex = 0;
            this.rbt_color_black.TabStop = true;
            this.rbt_color_black.Text = "黑色";
            this.rbt_color_black.UseVisualStyleBackColor = true;
            this.rbt_color_black.Click += new System.EventHandler(this.rbt_color_black_Click);
            // 
            // rbt_color_white
            // 
            this.rbt_color_white.AutoSize = true;
            this.rbt_color_white.Location = new System.Drawing.Point(27, 54);
            this.rbt_color_white.Name = "rbt_color_white";
            this.rbt_color_white.Size = new System.Drawing.Size(59, 22);
            this.rbt_color_white.TabIndex = 0;
            this.rbt_color_white.Text = "白色";
            this.rbt_color_white.UseVisualStyleBackColor = true;
            this.rbt_color_white.Click += new System.EventHandler(this.rbt_color_white_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbt_second);
            this.groupBox2.Controls.Add(this.rbt_frist);
            this.groupBox2.Location = new System.Drawing.Point(726, 159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(177, 100);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选择优先权";
            // 
            // rbt_second
            // 
            this.rbt_second.AutoSize = true;
            this.rbt_second.Enabled = false;
            this.rbt_second.Location = new System.Drawing.Point(27, 54);
            this.rbt_second.Name = "rbt_second";
            this.rbt_second.Size = new System.Drawing.Size(59, 22);
            this.rbt_second.TabIndex = 0;
            this.rbt_second.Text = "后手";
            this.rbt_second.UseVisualStyleBackColor = true;
            // 
            // rbt_frist
            // 
            this.rbt_frist.AutoSize = true;
            this.rbt_frist.Checked = true;
            this.rbt_frist.Enabled = false;
            this.rbt_frist.Location = new System.Drawing.Point(27, 26);
            this.rbt_frist.Name = "rbt_frist";
            this.rbt_frist.Size = new System.Drawing.Size(59, 22);
            this.rbt_frist.TabIndex = 0;
            this.rbt_frist.TabStop = true;
            this.rbt_frist.Text = "先手";
            this.rbt_frist.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 714);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBox_ai);
            this.Controls.Add(this.btn_start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.InactiveGlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "AI五子棋";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.CheckBox checkBox_ai;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbt_color_white;
        private System.Windows.Forms.RadioButton rbt_color_black;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbt_second;
        private System.Windows.Forms.RadioButton rbt_frist;
    }
}

