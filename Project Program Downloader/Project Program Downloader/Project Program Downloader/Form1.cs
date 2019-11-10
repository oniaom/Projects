using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Project_Program_Downloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //First we need to initialize a few vars. Checkwhatischecked is what our checkboxes's texts are.
            //Checkboxnames are our checkboxes's names
            //Whatischecked is going to give us the checked checkboxes.

            string[] CheckWhatisChecked = new string[] { "Firefox", "Chrome", "LibreOffice", "7Zip", "Skype", "Discord", "qBittorrent", "Steam", "Everything", "VSCode", "VLC", "KLiteCodecs", "Spotify" };
            CheckBox[] checkBoxNames = new CheckBox[] { cbFirefox, cbBrowserChrome, cbLibreOffice, cb7Zip, cbSkype, cbDiscord, cbqBittorent, cbSteam, cbEverything, cbVSCode, cbVLC, cbCodecs, cbSpotify };
            string[] Whatischecked = new string[13];
            string url = "";

            //Check if checkboxes are checked, and if they contain the program's name from checkwhatischecked. Then, append them to our whatischecked array.
            for (int i =0; i < checkBoxNames.Length; i++)
            {
                if (checkBoxNames[i].Checked == true && checkBoxNames[i].Text.Contains(CheckWhatisChecked[i]))
                {
                   Whatischecked = Whatischecked.Append(CheckWhatisChecked[i]).ToArray();
                }
            }
                //We now create a url based on what checkboxes we found checked.

                for(int i=0; i < Whatischecked.Length; i++)
                {
                    if(Whatischecked[i] == null | Whatischecked[i] == "" | Whatischecked[i] == " ")
                    {
                    //This is needed since we initiated an array with the length of 13 strings. If empty, do nothing
                        continue;
                    }
                    else
                    {
                        url += Whatischecked[i] + "-";
                    }
                }
            try
            {
                //Remove the last " - " from the url, and download the file using WebClient.
                url = url.TrimEnd(url[url.Length - 1]);
                string FinalUrl = "https://www.ninite.com/" + url + "/ninite.exe";
                WebClient fileDownloader = new WebClient();
                fileDownloader.DownloadProgressChanged += (s, progress) => { progressBar1.Value = progress.ProgressPercentage; lDownloadProgress.Visible = true; lDownloadProgress.Text = "Downloading..."; };
                fileDownloader.DownloadFileCompleted += (s, completed) => { progressBar1.Value = 0; lDownloadProgress.Text = "Download Complete!"; };
                try
                {
                    fileDownloader.DownloadFileAsync(new Uri(FinalUrl), AppDomain.CurrentDomain.BaseDirectory + "/Ninite " + url + ".exe");
                }
                catch
                {
                    MessageBox.Show("Sorry, There was a problem. Make sure you have an active internet connection and try again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Sorry, There was a problem. Make sure you have ticked programs and try again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
