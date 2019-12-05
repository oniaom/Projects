using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.Management;


namespace Project_Program_Downloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true;
            this.bAutoDetect.KeyDown += new KeyEventHandler(this.oniMode);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            // First we need to initialize a few vars.
            // url: Is the url we're going to use. It'll eventually contain the user's selection of software.
            // everything: Is our dictionary that contains a checkbox, and its corresponding text. Used to check which checkbox is checked.

            string url = "";
            Dictionary<CheckBox, string> everything = new Dictionary<CheckBox, string>()
            {
                {cbFirefox,"Firefox" }, {cbBrowserChrome,"Chrome" },
                {cbLibreOffice,"LibreOffice" },{cb7Zip,"7Zip" },
                {cbSkype,"Skype" },{cbDiscord,"Discord" },
                {cbqBittorent,"qBittorrent" },{cbSteam,"Steam" },
                {cbEverything,"Everything" },{cbVSCode,"VSCode" },
                {cbVLC,"VLC" },{cbkLiteCodecs,"KLiteCodecs" },
                {cbSpotify,"Spotify" }
            };

            foreach (var item in everything)
            {
                if (item.Key.Checked) { url += (item.Value + "-"); }
            }
            try
            {               
                //Remove the last " - " from the url, and download the file using WebClient.
                url = url.TrimEnd(url[url.Length - 1]);
                string FinalUrl = "https://www.ninite.com/" + url + "/ninite.exe";
                WebClient fileDownloader = new WebClient();
                fileDownloader.DownloadProgressChanged += (s, progress) => { progressBar1.Value = progress.ProgressPercentage; lDownloadProgress.Visible = true; lDownloadProgress.Text = "Downloading..."; };
                fileDownloader.DownloadFileCompleted += (s, completed) => {
                    progressBar1.Value = 0; lDownloadProgress.Text = "Download Complete!";
                    DialogResult openOrNot = MessageBox.Show("Download complete!\n Do you want to start installing now?", "Download complete!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (openOrNot == DialogResult.Yes)
                    {
                       Process.Start("Ninite" + " " + url + ".exe"); // Start the program                                
                    }
                };
                try
                {
                    fileDownloader.DownloadFileAsync(new Uri(FinalUrl), AppDomain.CurrentDomain.BaseDirectory + "/Ninite " + url + ".exe");
                }
                catch //If the url goes down, or the user has no internet access, then present an error.
                {
                    MessageBox.Show("Sorry, There was a problem. Make sure you have an active internet connection and try again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                fileDownloader.Dispose();
            }
            catch (IndexOutOfRangeException) // If the user hasn't clicked any checkboxes.
            {
                MessageBox.Show("Sorry, There was a problem. Make sure you have ticked programs and try again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }         
        }


        private void bInstallExtensions_Click(object sender, EventArgs e)
        {
            // This function get the selected extensions from a group list box, and opens the browser to the corresponding url.

            List<string> FirefoxWantedExtensions = new List<string>(); // Since we don't know which were selected, a list is better.
            List<string> ChromeWantedExtensions = new List<string>();

            foreach (string check in clbFirefox.CheckedItems) { FirefoxWantedExtensions.Add(check);} // Get the names of the checked and add them to the list we created earlier
            foreach (string check in clbChrome.CheckedItems) { ChromeWantedExtensions.Add(check);}

            Dictionary<string, string> FirefoxExtensionsDict = new Dictionary<string, string>()
            {
                // Name, Url of the addons.
                {"LastPass","https://addons.mozilla.org/en-US/firefox/addon/lastpass-password-manager/"},
                {"Ublock Origin","https://addons.mozilla.org/en-US/firefox/addon/ublock-origin/"},
                {"Dark Reader","https://addons.mozilla.org/en-US/firefox/addon/darkreader/"},
                {"Honey","https://addons.mozilla.org/en-US/firefox/addon/honey/"}
            };
            Dictionary<string, string> ChromeExtensionsDict = new Dictionary<string, string>()
            {
                // Name, Url of the addons.
                {"LastPass","https://chrome.google.com/webstore/detail/lastpass-free-password-ma/hdokiejnpimakedhajhdlcegeplioahd"},
                {"Ublock Origin","https://chrome.google.com/webstore/detail/ublock-origin/cjpalhdlnbpafiamejdnhcphjbkeiagm?hl=en"},
                {"Dark Reader","https://chrome.google.com/webstore/detail/dark-reader/eimadpbcbfnmbkopoojfekhnkhdbieeh?hl=en"},
                {"Honey","https://chrome.google.com/webstore/detail/honey/bmnlcjabgnpnenekpadlanbbkooimhnj?hl=en"}
            };

            // Open the browser to the corresponding extension URL based on what was checked.
            foreach (string extensions in FirefoxWantedExtensions)
            {
                if (FirefoxExtensionsDict.ContainsKey(extensions))
                {
                    try
                    { 
                       Process.Start(@"C:\Program Files\Mozilla Firefox\firefox.exe", FirefoxExtensionsDict[extensions]);
                    }
                    catch
                    {
                        MessageBox.Show("You don't have Firefox Installed!", "Firefox Not Found", MessageBoxButtons.OK ,MessageBoxIcon.Error);
                    }
                }
            }

            foreach(string extensions in ChromeWantedExtensions)
            {
                if (ChromeExtensionsDict.ContainsKey(extensions))
                {
                    try 
                    {
                        Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", ChromeExtensionsDict[extensions]);
                    }
                    catch
                    {
                        MessageBox.Show("You don't have Chrome Installed!", "Chrome Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                   
                }
            }

        }

        private void bAutoDetect_Click(object sender, EventArgs e)
        {
            // This function finds the GPU Model, and does the appropriate actions
            ManagementObjectSearcher gpuSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DisplayConfiguration");

            string foundGPU = "";
            // We use the managementObjectSearcher to get the name of the GPU
            foreach(ManagementObject Object in gpuSearcher.Get())
            {
                foreach ( PropertyData properties in Object.Properties)
                {
                    if (properties.Name == "Description") { foundGPU = properties.Value.ToString(); }
                }
            }
            gpuSearcher.Dispose();

            lGPU.Visible = true;
            lGPU.Text = "GPU:\n"+foundGPU;
            
            // Check the vendor and execute the appropriate commands.
            if (foundGPU.ToLower().Contains("nvidia") | foundGPU.Contains("geforce"))
            {
              Process.Start("https://www.nvidia.com/Download/Scan.aspx?lang=en-us"); // Open the Nvidia Autodetect site with the default browser.
            }
            else if (foundGPU.ToLower().Contains("amd") | foundGPU.Contains("ati"))
            {
                // AMD (and Intel) have their own downloadable Autodetect executable, unlike NVIDIA where you have to have Java installed.
                pgDriverDownload.Visible = true;
                // This block uses a WebClient to download that executable, and if the user wishes to, opens the installer.
                string url = "https://drivers.amd.com/drivers/installer/19.30/beta/radeon-software-adrenalin-2019-19.12.1-minimalsetup-191202_web.exe";

                WebClient amdDownload = new WebClient();
                amdDownload.DownloadProgressChanged += (s, progress) => { pgDriverDownload.Value = progress.ProgressPercentage; };
                amdDownload.DownloadFileCompleted += (s, completed) =>
                {
                    pgDriverDownload.Value = 0;
                    DialogResult result = MessageBox.Show("Download Completed!\n Do you want to run the Installer now?", "Driver Downloaded", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        Process.Start(@"radeon-software-adrenalin-2019-19.12.1-minimalsetup-191202_web.exe");
                    }

                };
                try
                {
                    amdDownload.DownloadFileAsync(new Uri(url), AppDomain.CurrentDomain.BaseDirectory + "/radeon-software-adrenalin-2019-19.12.1-minimalsetup-191202_web.exe");
                }
                catch
                {
                    MessageBox.Show("Sorry, There was a problem. Make sure you have an active internet connection and try again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                pgDriverDownload.Visible = false;
                amdDownload.Dispose();
            }
            else
            {
                // This is if the user doesn't have an Nvidia or AMD Gpu. It downloads Intel's autodetect software, and if the user wishes to, opens it.
                pgDriverDownload.Visible = true;

                string url = "https://downloadmirror.intel.com/28425/a08/Intel-Driver-and-Support-Assistant-Installer.exe";

                WebClient intelDownload = new WebClient();

                intelDownload.DownloadProgressChanged += (s, progress) => { pgDriverDownload.Value = progress.ProgressPercentage; };
                intelDownload.DownloadFileCompleted += (s, completed) =>
                {
                    pgDriverDownload.Value = 0;
                    DialogResult result = MessageBox.Show("Download Completed!\n Do you want to run the Installer now?", "Driver Downloaded", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        Process.Start(@"Intel-Driver-and-Support-Assistant-Installer.exe");
                    }

                };
                try
                {
                    intelDownload.DownloadFileAsync(new Uri(url), AppDomain.CurrentDomain.BaseDirectory + "/Intel-Driver-and-Support-Assistant-Installer.exe");
                }
                catch
                {
                    MessageBox.Show("Sorry, There was a problem. Make sure you have an active internet connection and try again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                pgDriverDownload.Visible = false;
                intelDownload.Dispose();
            }
        }

        private void oniMode(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Alt)
            {
                using(Form2 onimode = new Form2())
                {
                    onimode.ShowDialog();
                }
            }
        }
      
        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

    }
}
