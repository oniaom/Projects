namespace Project_Calculator
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
            this.tbDisplay = new System.Windows.Forms.TextBox();
            this.bNum1 = new System.Windows.Forms.Button();
            this.bNum2 = new System.Windows.Forms.Button();
            this.bNum3 = new System.Windows.Forms.Button();
            this.bNum4 = new System.Windows.Forms.Button();
            this.bNum5 = new System.Windows.Forms.Button();
            this.bNum6 = new System.Windows.Forms.Button();
            this.bNum8 = new System.Windows.Forms.Button();
            this.bNum7 = new System.Windows.Forms.Button();
            this.bNum9 = new System.Windows.Forms.Button();
            this.bNum0 = new System.Windows.Forms.Button();
            this.bPlus = new System.Windows.Forms.Button();
            this.bTimes = new System.Windows.Forms.Button();
            this.bDivide = new System.Windows.Forms.Button();
            this.bMinus = new System.Windows.Forms.Button();
            this.bCalculate = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.bMistake = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbDisplay
            // 
            this.tbDisplay.Location = new System.Drawing.Point(12, 12);
            this.tbDisplay.Name = "tbDisplay";
            this.tbDisplay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbDisplay.Size = new System.Drawing.Size(173, 20);
            this.tbDisplay.TabIndex = 0;
            this.tbDisplay.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // bNum1
            // 
            this.bNum1.Location = new System.Drawing.Point(13, 66);
            this.bNum1.Name = "bNum1";
            this.bNum1.Size = new System.Drawing.Size(75, 23);
            this.bNum1.TabIndex = 1;
            this.bNum1.Text = "1";
            this.bNum1.UseVisualStyleBackColor = true;
            this.bNum1.Click += new System.EventHandler(this.BNum1_Click);
            // 
            // bNum2
            // 
            this.bNum2.Location = new System.Drawing.Point(110, 66);
            this.bNum2.Name = "bNum2";
            this.bNum2.Size = new System.Drawing.Size(75, 23);
            this.bNum2.TabIndex = 2;
            this.bNum2.Text = "2";
            this.bNum2.UseVisualStyleBackColor = true;
            this.bNum2.Click += new System.EventHandler(this.BNum2_Click);
            // 
            // bNum3
            // 
            this.bNum3.Location = new System.Drawing.Point(13, 95);
            this.bNum3.Name = "bNum3";
            this.bNum3.Size = new System.Drawing.Size(75, 23);
            this.bNum3.TabIndex = 3;
            this.bNum3.Text = "3";
            this.bNum3.UseVisualStyleBackColor = true;
            this.bNum3.Click += new System.EventHandler(this.BNum3_Click);
            // 
            // bNum4
            // 
            this.bNum4.Location = new System.Drawing.Point(110, 95);
            this.bNum4.Name = "bNum4";
            this.bNum4.Size = new System.Drawing.Size(75, 23);
            this.bNum4.TabIndex = 4;
            this.bNum4.Text = "4";
            this.bNum4.UseVisualStyleBackColor = true;
            this.bNum4.Click += new System.EventHandler(this.BNum4_Click);
            // 
            // bNum5
            // 
            this.bNum5.Location = new System.Drawing.Point(12, 124);
            this.bNum5.Name = "bNum5";
            this.bNum5.Size = new System.Drawing.Size(75, 23);
            this.bNum5.TabIndex = 5;
            this.bNum5.Text = "5";
            this.bNum5.UseVisualStyleBackColor = true;
            this.bNum5.Click += new System.EventHandler(this.BNum5_Click);
            // 
            // bNum6
            // 
            this.bNum6.Location = new System.Drawing.Point(110, 124);
            this.bNum6.Name = "bNum6";
            this.bNum6.Size = new System.Drawing.Size(75, 23);
            this.bNum6.TabIndex = 6;
            this.bNum6.Text = "6";
            this.bNum6.UseVisualStyleBackColor = true;
            this.bNum6.Click += new System.EventHandler(this.BNum6_Click);
            // 
            // bNum8
            // 
            this.bNum8.Location = new System.Drawing.Point(110, 153);
            this.bNum8.Name = "bNum8";
            this.bNum8.Size = new System.Drawing.Size(75, 23);
            this.bNum8.TabIndex = 7;
            this.bNum8.Text = "8";
            this.bNum8.UseVisualStyleBackColor = true;
            this.bNum8.Click += new System.EventHandler(this.BNum8_Click);
            // 
            // bNum7
            // 
            this.bNum7.Location = new System.Drawing.Point(13, 153);
            this.bNum7.Name = "bNum7";
            this.bNum7.Size = new System.Drawing.Size(75, 23);
            this.bNum7.TabIndex = 8;
            this.bNum7.Text = "7";
            this.bNum7.UseVisualStyleBackColor = true;
            this.bNum7.Click += new System.EventHandler(this.BNum7_Click);
            // 
            // bNum9
            // 
            this.bNum9.Location = new System.Drawing.Point(13, 182);
            this.bNum9.Name = "bNum9";
            this.bNum9.Size = new System.Drawing.Size(75, 23);
            this.bNum9.TabIndex = 9;
            this.bNum9.Text = "9";
            this.bNum9.UseVisualStyleBackColor = true;
            this.bNum9.Click += new System.EventHandler(this.BNum9_Click);
            // 
            // bNum0
            // 
            this.bNum0.Location = new System.Drawing.Point(110, 182);
            this.bNum0.Name = "bNum0";
            this.bNum0.Size = new System.Drawing.Size(75, 23);
            this.bNum0.TabIndex = 10;
            this.bNum0.Text = "0";
            this.bNum0.UseVisualStyleBackColor = true;
            this.bNum0.Click += new System.EventHandler(this.BNum0_Click);
            // 
            // bPlus
            // 
            this.bPlus.Location = new System.Drawing.Point(12, 226);
            this.bPlus.Name = "bPlus";
            this.bPlus.Size = new System.Drawing.Size(75, 23);
            this.bPlus.TabIndex = 11;
            this.bPlus.Text = "+";
            this.bPlus.UseVisualStyleBackColor = true;
            this.bPlus.Click += new System.EventHandler(this.BPlus_Click);
            // 
            // bTimes
            // 
            this.bTimes.Location = new System.Drawing.Point(12, 255);
            this.bTimes.Name = "bTimes";
            this.bTimes.Size = new System.Drawing.Size(75, 23);
            this.bTimes.TabIndex = 12;
            this.bTimes.Text = "*";
            this.bTimes.UseVisualStyleBackColor = true;
            this.bTimes.Click += new System.EventHandler(this.BTimes_Click);
            // 
            // bDivide
            // 
            this.bDivide.Location = new System.Drawing.Point(110, 255);
            this.bDivide.Name = "bDivide";
            this.bDivide.Size = new System.Drawing.Size(75, 23);
            this.bDivide.TabIndex = 13;
            this.bDivide.Text = "/";
            this.bDivide.UseVisualStyleBackColor = true;
            this.bDivide.Click += new System.EventHandler(this.BDivide_Click);
            // 
            // bMinus
            // 
            this.bMinus.Location = new System.Drawing.Point(110, 226);
            this.bMinus.Name = "bMinus";
            this.bMinus.Size = new System.Drawing.Size(75, 23);
            this.bMinus.TabIndex = 14;
            this.bMinus.Text = "-";
            this.bMinus.UseVisualStyleBackColor = true;
            this.bMinus.Click += new System.EventHandler(this.BMinus_Click);
            // 
            // bCalculate
            // 
            this.bCalculate.Location = new System.Drawing.Point(13, 285);
            this.bCalculate.Name = "bCalculate";
            this.bCalculate.Size = new System.Drawing.Size(75, 46);
            this.bCalculate.TabIndex = 15;
            this.bCalculate.Text = "Calculate";
            this.bCalculate.UseVisualStyleBackColor = true;
            this.bCalculate.Click += new System.EventHandler(this.BCalculate_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            // 
            // bMistake
            // 
            this.bMistake.Location = new System.Drawing.Point(110, 297);
            this.bMistake.Name = "bMistake";
            this.bMistake.Size = new System.Drawing.Size(75, 23);
            this.bMistake.TabIndex = 16;
            this.bMistake.Text = "C";
            this.bMistake.UseVisualStyleBackColor = true;
            this.bMistake.Click += new System.EventHandler(this.BMistake_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 342);
            this.Controls.Add(this.bMistake);
            this.Controls.Add(this.bCalculate);
            this.Controls.Add(this.bMinus);
            this.Controls.Add(this.bDivide);
            this.Controls.Add(this.bTimes);
            this.Controls.Add(this.bPlus);
            this.Controls.Add(this.bNum0);
            this.Controls.Add(this.bNum9);
            this.Controls.Add(this.bNum7);
            this.Controls.Add(this.bNum8);
            this.Controls.Add(this.bNum6);
            this.Controls.Add(this.bNum5);
            this.Controls.Add(this.bNum4);
            this.Controls.Add(this.bNum3);
            this.Controls.Add(this.bNum2);
            this.Controls.Add(this.bNum1);
            this.Controls.Add(this.tbDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calc";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDisplay;
        private System.Windows.Forms.Button bNum1;
        private System.Windows.Forms.Button bNum2;
        private System.Windows.Forms.Button bNum3;
        private System.Windows.Forms.Button bNum4;
        private System.Windows.Forms.Button bNum5;
        private System.Windows.Forms.Button bNum6;
        private System.Windows.Forms.Button bNum8;
        private System.Windows.Forms.Button bNum7;
        private System.Windows.Forms.Button bNum9;
        private System.Windows.Forms.Button bNum0;
        private System.Windows.Forms.Button bPlus;
        private System.Windows.Forms.Button bTimes;
        private System.Windows.Forms.Button bDivide;
        private System.Windows.Forms.Button bMinus;
        private System.Windows.Forms.Button bCalculate;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button bMistake;
    }
}

