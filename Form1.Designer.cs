namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            pictureBox2 = new PictureBox();
            label13 = new Label();
            pictureBox3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 75);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(494, 331);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(12, 25);
            button1.Name = "button1";
            button1.Size = new Size(122, 29);
            button1.TabIndex = 2;
            button1.Text = "开始获取屏幕";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1002, 65);
            label1.Name = "label1";
            label1.Size = new Size(194, 20);
            label1.TabIndex = 3;
            label1.Text = "F1   【开始/结束】获取屏幕";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1002, 114);
            label2.Name = "label2";
            label2.Size = new Size(194, 20);
            label2.TabIndex = 4;
            label2.Text = "F2   【开始/结束】判断红名";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1053, 266);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 5;
            label3.Text = "当前状态";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(995, 298);
            label4.Name = "label4";
            label4.Size = new Size(201, 20);
            label4.TabIndex = 6;
            label4.Text = "--------------------------------";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1002, 331);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 7;
            label5.Text = "获取屏幕";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1089, 331);
            label6.Name = "label6";
            label6.Size = new Size(24, 20);
            label6.TabIndex = 8;
            label6.Text = "否";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1089, 377);
            label7.Name = "label7";
            label7.Size = new Size(24, 20);
            label7.TabIndex = 10;
            label7.Text = "否";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(1002, 377);
            label8.Name = "label8";
            label8.Size = new Size(69, 20);
            label8.TabIndex = 9;
            label8.Text = "判断红名";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = SystemColors.ControlText;
            label9.Location = new Point(1002, 158);
            label9.Name = "label9";
            label9.Size = new Size(130, 20);
            label9.TabIndex = 11;
            label9.Text = "F3           全部关闭";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = SystemColors.ControlText;
            label10.Location = new Point(1002, 201);
            label10.Name = "label10";
            label10.Size = new Size(186, 20);
            label10.TabIndex = 12;
            label10.Text = "F4          保存一张当前图片";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(251, 448);
            label11.Name = "label11";
            label11.Size = new Size(99, 20);
            label11.TabIndex = 13;
            label11.Text = "是否需要开枪";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(375, 449);
            label12.Name = "label12";
            label12.Size = new Size(24, 20);
            label12.TabIndex = 14;
            label12.Text = "否";
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(535, 75);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(257, 87);
            pictureBox2.TabIndex = 15;
            pictureBox2.TabStop = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(535, 448);
            label13.Name = "label13";
            label13.Size = new Size(69, 20);
            label13.TabIndex = 16;
            label13.Text = "调试信息";
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(535, 217);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(141, 87);
            pictureBox3.TabIndex = 17;
            pictureBox3.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1242, 511);
            Controls.Add(pictureBox3);
            Controls.Add(label13);
            Controls.Add(pictureBox2);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private PictureBox pictureBox2;
        private Label label13;
        private PictureBox pictureBox3;
    }
}
