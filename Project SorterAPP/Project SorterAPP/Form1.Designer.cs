namespace Project_SorterAPP
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
            this.tbNumbers = new System.Windows.Forms.TextBox();
            this.bAdd = new System.Windows.Forms.Button();
            this.bSort = new System.Windows.Forms.Button();
            this.lView = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbNumbers
            // 
            this.tbNumbers.Location = new System.Drawing.Point(12, 12);
            this.tbNumbers.Name = "tbNumbers";
            this.tbNumbers.Size = new System.Drawing.Size(217, 20);
            this.tbNumbers.TabIndex = 0;
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(12, 51);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(75, 23);
            this.bAdd.TabIndex = 1;
            this.bAdd.Text = "Add";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.BAdd_Click);
            // 
            // bSort
            // 
            this.bSort.Location = new System.Drawing.Point(154, 51);
            this.bSort.Name = "bSort";
            this.bSort.Size = new System.Drawing.Size(75, 23);
            this.bSort.TabIndex = 2;
            this.bSort.Text = "Sort";
            this.bSort.UseVisualStyleBackColor = true;
            this.bSort.Click += new System.EventHandler(this.BSort_Click);
            // 
            // lView
            // 
            this.lView.AutoSize = true;
            this.lView.Location = new System.Drawing.Point(9, 188);
            this.lView.Name = "lView";
            this.lView.Size = new System.Drawing.Size(0, 13);
            this.lView.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 210);
            this.Controls.Add(this.lView);
            this.Controls.Add(this.bSort);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.tbNumbers);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbNumbers;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Button bSort;
        private System.Windows.Forms.Label lView;
    }
}

