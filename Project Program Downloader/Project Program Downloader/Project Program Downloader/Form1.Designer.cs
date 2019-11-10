namespace Project_Program_Downloader
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
            this.cbFirefox = new System.Windows.Forms.CheckBox();
            this.cbBrowserChrome = new System.Windows.Forms.CheckBox();
            this.cbLibreOffice = new System.Windows.Forms.CheckBox();
            this.cb7Zip = new System.Windows.Forms.CheckBox();
            this.cbSkype = new System.Windows.Forms.CheckBox();
            this.cbDiscord = new System.Windows.Forms.CheckBox();
            this.cbqBittorent = new System.Windows.Forms.CheckBox();
            this.cbSteam = new System.Windows.Forms.CheckBox();
            this.cbEverything = new System.Windows.Forms.CheckBox();
            this.cbVSCode = new System.Windows.Forms.CheckBox();
            this.cbVLC = new System.Windows.Forms.CheckBox();
            this.cbCodecs = new System.Windows.Forms.CheckBox();
            this.cbSpotify = new System.Windows.Forms.CheckBox();
            this.bDownload = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lDownloadProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbFirefox
            // 
            this.cbFirefox.AutoSize = true;
            this.cbFirefox.Location = new System.Drawing.Point(1, 12);
            this.cbFirefox.Name = "cbFirefox";
            this.cbFirefox.Size = new System.Drawing.Size(57, 17);
            this.cbFirefox.TabIndex = 0;
            this.cbFirefox.Text = "Firefox";
            this.cbFirefox.UseVisualStyleBackColor = true;
            // 
            // cbBrowserChrome
            // 
            this.cbBrowserChrome.AutoSize = true;
            this.cbBrowserChrome.Location = new System.Drawing.Point(1, 35);
            this.cbBrowserChrome.Name = "cbBrowserChrome";
            this.cbBrowserChrome.Size = new System.Drawing.Size(62, 17);
            this.cbBrowserChrome.TabIndex = 1;
            this.cbBrowserChrome.Text = "Chrome";
            this.cbBrowserChrome.UseVisualStyleBackColor = true;
            // 
            // cbLibreOffice
            // 
            this.cbLibreOffice.AutoSize = true;
            this.cbLibreOffice.Location = new System.Drawing.Point(1, 58);
            this.cbLibreOffice.Name = "cbLibreOffice";
            this.cbLibreOffice.Size = new System.Drawing.Size(77, 17);
            this.cbLibreOffice.TabIndex = 2;
            this.cbLibreOffice.Text = "LibreOffice";
            this.cbLibreOffice.UseVisualStyleBackColor = true;
            // 
            // cb7Zip
            // 
            this.cb7Zip.AutoSize = true;
            this.cb7Zip.Location = new System.Drawing.Point(1, 81);
            this.cb7Zip.Name = "cb7Zip";
            this.cb7Zip.Size = new System.Drawing.Size(47, 17);
            this.cb7Zip.TabIndex = 3;
            this.cb7Zip.Text = "7Zip";
            this.cb7Zip.UseVisualStyleBackColor = true;
            // 
            // cbSkype
            // 
            this.cbSkype.AutoSize = true;
            this.cbSkype.Location = new System.Drawing.Point(1, 104);
            this.cbSkype.Name = "cbSkype";
            this.cbSkype.Size = new System.Drawing.Size(56, 17);
            this.cbSkype.TabIndex = 4;
            this.cbSkype.Text = "Skype";
            this.cbSkype.UseVisualStyleBackColor = true;
            // 
            // cbDiscord
            // 
            this.cbDiscord.AutoSize = true;
            this.cbDiscord.Location = new System.Drawing.Point(87, 12);
            this.cbDiscord.Name = "cbDiscord";
            this.cbDiscord.Size = new System.Drawing.Size(62, 17);
            this.cbDiscord.TabIndex = 5;
            this.cbDiscord.Text = "Discord";
            this.cbDiscord.UseVisualStyleBackColor = true;
            // 
            // cbqBittorent
            // 
            this.cbqBittorent.AutoSize = true;
            this.cbqBittorent.Location = new System.Drawing.Point(87, 35);
            this.cbqBittorent.Name = "cbqBittorent";
            this.cbqBittorent.Size = new System.Drawing.Size(74, 17);
            this.cbqBittorent.TabIndex = 6;
            this.cbqBittorent.Text = "qBittorrent";
            this.cbqBittorent.UseVisualStyleBackColor = true;
            // 
            // cbSteam
            // 
            this.cbSteam.AutoSize = true;
            this.cbSteam.Location = new System.Drawing.Point(87, 58);
            this.cbSteam.Name = "cbSteam";
            this.cbSteam.Size = new System.Drawing.Size(56, 17);
            this.cbSteam.TabIndex = 7;
            this.cbSteam.Text = "Steam";
            this.cbSteam.UseVisualStyleBackColor = true;
            // 
            // cbEverything
            // 
            this.cbEverything.AutoSize = true;
            this.cbEverything.Location = new System.Drawing.Point(87, 81);
            this.cbEverything.Name = "cbEverything";
            this.cbEverything.Size = new System.Drawing.Size(76, 17);
            this.cbEverything.TabIndex = 8;
            this.cbEverything.Text = "Everything";
            this.cbEverything.UseVisualStyleBackColor = true;
            // 
            // cbVSCode
            // 
            this.cbVSCode.AutoSize = true;
            this.cbVSCode.Location = new System.Drawing.Point(87, 104);
            this.cbVSCode.Name = "cbVSCode";
            this.cbVSCode.Size = new System.Drawing.Size(65, 17);
            this.cbVSCode.TabIndex = 9;
            this.cbVSCode.Text = "VSCode";
            this.cbVSCode.UseVisualStyleBackColor = true;
            // 
            // cbVLC
            // 
            this.cbVLC.AutoSize = true;
            this.cbVLC.Location = new System.Drawing.Point(173, 12);
            this.cbVLC.Name = "cbVLC";
            this.cbVLC.Size = new System.Drawing.Size(46, 17);
            this.cbVLC.TabIndex = 10;
            this.cbVLC.Text = "VLC";
            this.cbVLC.UseVisualStyleBackColor = true;
            // 
            // cbCodecs
            // 
            this.cbCodecs.AutoSize = true;
            this.cbCodecs.Location = new System.Drawing.Point(173, 35);
            this.cbCodecs.Name = "cbCodecs";
            this.cbCodecs.Size = new System.Drawing.Size(80, 17);
            this.cbCodecs.TabIndex = 11;
            this.cbCodecs.Text = "KLiteCodes";
            this.cbCodecs.UseVisualStyleBackColor = true;
            // 
            // cbSpotify
            // 
            this.cbSpotify.AutoSize = true;
            this.cbSpotify.Location = new System.Drawing.Point(173, 58);
            this.cbSpotify.Name = "cbSpotify";
            this.cbSpotify.Size = new System.Drawing.Size(58, 17);
            this.cbSpotify.TabIndex = 12;
            this.cbSpotify.Text = "Spotify";
            this.cbSpotify.UseVisualStyleBackColor = true;
            // 
            // bDownload
            // 
            this.bDownload.Location = new System.Drawing.Point(39, 141);
            this.bDownload.Name = "bDownload";
            this.bDownload.Size = new System.Drawing.Size(104, 39);
            this.bDownload.TabIndex = 13;
            this.bDownload.Text = "Download!";
            this.bDownload.UseVisualStyleBackColor = true;
            this.bDownload.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(191, 157);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 14;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // lDownloadProgress
            // 
            this.lDownloadProgress.AutoSize = true;
            this.lDownloadProgress.Location = new System.Drawing.Point(188, 141);
            this.lDownloadProgress.Name = "lDownloadProgress";
            this.lDownloadProgress.Size = new System.Drawing.Size(35, 13);
            this.lDownloadProgress.TabIndex = 15;
            this.lDownloadProgress.Text = "label1";
            this.lDownloadProgress.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 192);
            this.Controls.Add(this.lDownloadProgress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.bDownload);
            this.Controls.Add(this.cbSpotify);
            this.Controls.Add(this.cbCodecs);
            this.Controls.Add(this.cbVLC);
            this.Controls.Add(this.cbVSCode);
            this.Controls.Add(this.cbEverything);
            this.Controls.Add(this.cbSteam);
            this.Controls.Add(this.cbqBittorent);
            this.Controls.Add(this.cbDiscord);
            this.Controls.Add(this.cbSkype);
            this.Controls.Add(this.cb7Zip);
            this.Controls.Add(this.cbLibreOffice);
            this.Controls.Add(this.cbBrowserChrome);
            this.Controls.Add(this.cbFirefox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(319, 231);
            this.MinimumSize = new System.Drawing.Size(319, 231);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Program Downloader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbFirefox;
        private System.Windows.Forms.CheckBox cbBrowserChrome;
        private System.Windows.Forms.CheckBox cbLibreOffice;
        private System.Windows.Forms.CheckBox cb7Zip;
        private System.Windows.Forms.CheckBox cbSkype;
        private System.Windows.Forms.CheckBox cbDiscord;
        private System.Windows.Forms.CheckBox cbqBittorent;
        private System.Windows.Forms.CheckBox cbSteam;
        private System.Windows.Forms.CheckBox cbEverything;
        private System.Windows.Forms.CheckBox cbVSCode;
        private System.Windows.Forms.CheckBox cbVLC;
        private System.Windows.Forms.CheckBox cbCodecs;
        private System.Windows.Forms.CheckBox cbSpotify;
        private System.Windows.Forms.Button bDownload;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lDownloadProgress;
    }
}

