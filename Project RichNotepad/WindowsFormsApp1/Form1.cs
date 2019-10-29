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
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += RichNotepad_Closing;
            for(int i = 0; i<100; i++)
            {
                comboBox1.Items.Add(i);
            }
            comboBox1.SelectedIndex = 13;
            textBox1.Text = "13";
        }
        public bool textChanged = false;
        public string TextSize {
            get { return textBox1.Text; }
            set
            {
                textBox1.Text = value;
                richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, Convert.ToInt32(value));        

            }
        }
        public string[] test = new string[4];
        
        public string[] currentStates
        {
            get
            {
                return test;
            }
            set { }        
        }
        public void RtbProperties (string[] properties)
        {
            FontStyle a = FontStyle.Regular;
            FontStyle b = FontStyle.Regular;
            FontStyle c = FontStyle.Regular;
            FontStyle d = FontStyle.Regular;
            FontStyle[] styles = new FontStyle[4];
            StringBuilder builder = new StringBuilder();
            foreach(string prop in properties)
            {
                builder.Append(prop+" ");
            }                                                      
            char[] abb = { ' ' };
            string[] states = new string[4] ;
            string[] ab = builder.ToString().Split(abb,StringSplitOptions.RemoveEmptyEntries);
            for(int i=0; i<ab.Length; i++)
            {
                switch (ab[i])
                {
                    case "Bold":
                        a = FontStyle.Bold;
                        states.Append("Bold");
                        break;
                    case "Italic":
                        b = FontStyle.Italic;
                        states.Append("Italic");
                        break;
                    case "Underline":
                        c = FontStyle.Underline;
                        states.Append("Underline");
                        break;
                    case "Strikethrough":
                        d = FontStyle.Strikeout;
                        states.Append("Strikethrough");
                        break;
                    default:
                        break;
                }
            }
            
            test = states;

               richTextBox1.Font = new Font(richTextBox1.Font,a|b|c|d);
            
            
        }
        
        public string openedFile = "";
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            using (Stream openFile = openFileDialog1.OpenFile())
            {
                StreamReader readFile = new StreamReader(openFile);
                using (readFile)
                {
                    
                    openedFile = openFileDialog1.FileName.ToString();
                    string text = readFile.ReadToEnd();
                    richTextBox1.Rtf = text;
                }
                readFile.Close(); //Closing the file in case we need to quick save (otherwise we get a file is open error)
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            // Saving a file 

            using (StreamWriter writing = new StreamWriter(saveFileDialog1.FileName))
            {
                string tbText = richTextBox1.Rtf;
                writing.WriteLine(tbText);
                textChanged = false;
                writing.Close(); //Closing the file.
            }
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont.Bold)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Regular);
                richTextBox1.Focus();
            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Bold);
                richTextBox1.Focus();
            }
        }

        private void cbBullet_CheckedChanged(object sender, EventArgs e)
        {
            if(richTextBox1.SelectionBullet == true){ richTextBox1.SelectionBullet = false; richTextBox1.Focus(); }
            else { richTextBox1.SelectionBullet = true; richTextBox1.Focus(); }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {          
            try 
            { 
            comboBox1.SelectedIndex = int.Parse(textBox1.Text);
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, Convert.ToInt32(textBox1.Text));
              
            }
            catch (ArgumentOutOfRangeException)
            {
                int number = int.Parse((textBox1.Text));
                for(int i =0; i<=number; i++) { 
                comboBox1.Items.Add(i);
                }
                comboBox1.SelectedIndex = number;
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, number);
            }
            catch (FormatException)
            {
                textBox1.Text = "1";
                textBox1.SelectionLength = 1;
            }

        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.CurrentSize = TextSize;
            form2.Show();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            textChanged = true;
        }
        public void RichNotepad_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (textChanged)
                {
                    DialogResult Close_or_Not = MessageBox.Show("You have unsaved changes. Quit Anyway?", "Notepad", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (Close_or_Not == DialogResult.No) { e.Cancel = true; }
                }
            }
        }
    }
}
