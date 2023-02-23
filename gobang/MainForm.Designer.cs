
namespace gobang
{
    partial class MainForm
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
            this.btn_start = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbt_color_white = new System.Windows.Forms.RadioButton();
            this.rbt_color_black = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbt_second = new System.Windows.Forms.RadioButton();
            this.rbt_frist = new System.Windows.Forms.RadioButton();
            this.label_count = new System.Windows.Forms.Label();
            this.label_time = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(726, 285);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(150, 40);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "开始";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.button1_Click);
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
            // rbt_color_white
            // 
            this.rbt_color_white.AutoSize = true;
            this.rbt_color_white.Location = new System.Drawing.Point(27, 54);
            this.rbt_color_white.Name = "rbt_color_white";
            this.rbt_color_white.Size = new System.Drawing.Size(59, 22);
            this.rbt_color_white.TabIndex = 0;
            this.rbt_color_white.Text = "白色";
            this.rbt_color_white.UseVisualStyleBackColor = true;
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
            this.rbt_frist.Location = new System.Drawing.Point(27, 26);
            this.rbt_frist.Name = "rbt_frist";
            this.rbt_frist.Size = new System.Drawing.Size(59, 22);
            this.rbt_frist.TabIndex = 0;
            this.rbt_frist.TabStop = true;
            this.rbt_frist.Text = "先手";
            this.rbt_frist.UseVisualStyleBackColor = true;
            // 
            // label_count
            // 
            this.label_count.AutoSize = true;
            this.label_count.Font = new System.Drawing.Font("Tahoma", 18F);
            this.label_count.ForeColor = System.Drawing.Color.Maroon;
            this.label_count.Location = new System.Drawing.Point(765, 363);
            this.label_count.Name = "label_count";
            this.label_count.Size = new System.Drawing.Size(31, 36);
            this.label_count.TabIndex = 4;
            this.label_count.Text = "0";
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Location = new System.Drawing.Point(768, 687);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(52, 18);
            this.label_time.TabIndex = 5;
            this.label_time.Text = "0.00秒";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MainForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 714);
            this.Controls.Add(this.label_time);
            this.Controls.Add(this.label_count);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.InactiveGlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "AI五子棋";
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbt_color_white;
        private System.Windows.Forms.RadioButton rbt_color_black;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbt_second;
        private System.Windows.Forms.RadioButton rbt_frist;
        private System.Windows.Forms.Label label_count;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.Timer timer;
    }
}

