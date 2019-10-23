using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Notepad
{
    public partial class Form1 : Form
    {     
        public bool textChanged = false;
        public Form1()
        {     
            InitializeComponent();
            this.FormClosing += Notepad_Closing; //To handle closing the app in case there are unsaved changes
            backgroundWorker1.RunWorkerAsync(); //To run the in the background checking if settings changed.
        }

        public static string openedFile = ""; //Is there a file currently open?
        
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            // Opening and reading the whole text file
            using (Stream openFile = openFileDialog.OpenFile())
            {
                StreamReader readFile = new StreamReader(openFile);
                using (readFile)
                {
                    openedFile = openFileDialog.FileName.ToString();
                    string text = readFile.ReadToEnd();
                    tbNotes.Text = text;
                }
                readFile.Close(); //Closing the file in case we need to quick save (otherwise we get a file is open error)
            }
        }
        private void SaveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            // Saving a file 
            using (StreamWriter writing = new StreamWriter(saveFileDialog.FileName))
            {
                string tbText = tbNotes.Text;
                writing.WriteLine(tbText);
                textChanged = false;
                writing.Close(); //Closing the file for the same reason as above.
            }
            
        }
        private void AltSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openedFile == "") //This is where the openedFile string comes in to play. If no files are open, show the normal save dialog.
            {
                saveFileDialog.ShowDialog();
                openedFile = saveFileDialog.FileName;
            }
            try { 
            using (StreamWriter writing = new StreamWriter(openedFile))
            {
                writing.Write(tbNotes.Text);
                textChanged = false;
                writing.Close();
            }
            }
            catch
            {
                //We need this to stop an excemption from hapening when the user presses cancel without selecting a file.
            }
        }
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the save dialog.
            saveFileDialog.ShowDialog();
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Show the open file dialog.
            openFileDialog.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //This is for when the user tries to close the program without saving any changes.
           textChanged = true;
        }

        private void Notepad_Closing(object sender, FormClosingEventArgs e)
        {
           //Here we handle the app close event, if the user has unsaved changes governed by the bool textChanged.
            if (e.CloseReason == CloseReason.UserClosing)
            {            
                if (textChanged == true)
                {
                    DialogResult Close_or_Not = MessageBox.Show("You have unsaved changes. Quit Anyway?", "Notepad", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                    if (Close_or_Not == DialogResult.No) { e.Cancel = true; }
                }
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
        loopWorker: //I know...

            while (Properties.Settings.Default.Settings_Changed == false) //If there aren't any settings changed, keep checking.
            {
                if(Properties.Settings.Default.Settings_Changed == true) { break; } //When they finally change, stop the loop.
            }
        //These vars are for checking which settings the user has changed. def* is the default value, while current* is the changed value.
            bool defWordWrap = false;
            bool defRight_to_Left = false;
            bool defRemember = false;
            bool currentWordWrap = Properties.Settings.Default.WordWrap;
            bool currentRight_to_Left = Properties.Settings.Default.Right_to_Left;
            bool currentRemember = Properties.Settings.Default.Remember;
            bool[] currentSettings = {currentWordWrap ,currentRight_to_Left, currentRemember};
            bool[] settings = { defWordWrap, defRight_to_Left, defRemember };
            string[] names = { "WordWrap", "Right to Left", "Remember" };

           for (int i=0; i<3; i++) //Checking the defaults with the current settings.
            {
                switch (settings[i])
                {
                    case false: //Since both settings are default to false, this should run first.
                        if (settings[i] != currentSettings[i])
                        {
                            switch (names[i]) //Checking the corresponding setting and changing the values as needed.
                            {
                                case "WordWrap":
                                   // Properties.Settings.Default.WordWrap = true;
                                    this.Invoke(new MethodInvoker(delegate { tbNotes.WordWrap = true; }));
                                    break;
                                case "Right to Left":
                                    //Properties.Settings.Default.Right_to_Left = true;
                                    this.Invoke(new MethodInvoker(delegate { tbNotes.RightToLeft = RightToLeft.Yes; }));
                                    break;
                                case "Remember":
                                   // Properties.Settings.Default.Remember = true;
                                    Properties.Settings.Default.Save();
                                    break;
                                default:
                                    break;
                            }
                        }
                        if (settings[i] == currentSettings[i]) //If there's a change and the defaults are now true. This is to reset them per user's needs.
                        {
                            switch (names[i]) //Checking the corresponding setting and changing the values as needed.
                            {
                                case "WordWrap":
                                   // Properties.Settings.Default.WordWrap = false;
                                    this.Invoke(new MethodInvoker(delegate { tbNotes.WordWrap = false; }));
                                    break;
                                case "Right to Left":
                                  //  Properties.Settings.Default.Right_to_Left = false;
                                    this.Invoke(new MethodInvoker(delegate { tbNotes.RightToLeft = RightToLeft.No; }));
                                    break;
                                case "Remember":
                                  //  Properties.Settings.Default.Remember = false;
                                    Properties.Settings.Default.Save();
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case true:
                      
                        break;
                    default:
                        break;
                }

            }
            Properties.Settings.Default.Settings_Changed = false; //Since now the new settings are the default, nothing is changed anymore.
            goto loopWorker; // ...
        }
        private void PreferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //This is to show the settings form.
            FormSettings fSettings = new FormSettings();
            fSettings.Show();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
     
        }
    }
}
