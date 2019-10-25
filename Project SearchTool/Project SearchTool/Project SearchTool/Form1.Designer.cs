namespace Project_SearchTool
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
            this.tbQuery = new System.Windows.Forms.TextBox();
            this.rtbNames = new System.Windows.Forms.RichTextBox();
            this.bSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbQuery
            // 
            this.tbQuery.Location = new System.Drawing.Point(12, 12);
            this.tbQuery.Name = "tbQuery";
            this.tbQuery.Size = new System.Drawing.Size(100, 20);
            this.tbQuery.TabIndex = 0;
            this.tbQuery.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // rtbNames
            // 
            this.rtbNames.Location = new System.Drawing.Point(12, 39);
            this.rtbNames.Name = "rtbNames";
            this.rtbNames.Size = new System.Drawing.Size(416, 154);
            this.rtbNames.TabIndex = 1;
            this.rtbNames.Text = "";
            this.rtbNames.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // bSearch
            // 
            this.bSearch.Location = new System.Drawing.Point(138, 10);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(75, 23);
            this.bSearch.TabIndex = 2;
            this.bSearch.Text = "Search";
            this.bSearch.UseVisualStyleBackColor = true;
            this.bSearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 206);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.rtbNames);
            this.Controls.Add(this.tbQuery);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbQuery;
        private System.Windows.Forms.RichTextBox rtbNames;
        private System.Windows.Forms.Button bSearch;
    }
}

