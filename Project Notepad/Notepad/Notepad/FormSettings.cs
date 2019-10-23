using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
            //This is to check settings already checked if the user closed this window before but applied settings.
            if (checkedListBox.Items.Contains("WordWrap"))
            {
                if(Properties.Settings.Default.WordWrap == true)
                {
                    checkedListBox.SetItemChecked(0,true);
                }
            }
            if (checkedListBox.Items.Contains("Right to Left"))
            {
                if (Properties.Settings.Default.Right_to_Left == true)
                {
                    checkedListBox.SetItemChecked(1, true);
                }
            }
            if (checkedListBox.Items.Contains("Remember Settings Until Unchecked"))
            {
                if (Properties.Settings.Default.Remember == true)
                {
                    checkedListBox.SetItemChecked(2, true);
                }
            }
        }

        private void CheckedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void CheckedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Since my c# version is below 8 i can't use switches for this. This is to change the settings according to the user's selection.
            if(checkedListBox.CheckedItems.Contains("WordWrap") == true)
            {
                Properties.Settings.Default.WordWrap = true;
            }
            if (checkedListBox.CheckedItems.Contains("WordWrap") != true)
            {
                Properties.Settings.Default.WordWrap = false;
            }
            if (checkedListBox.CheckedItems.Contains("Right to Left") == true)
            {
                Properties.Settings.Default.Right_to_Left = true;
            }
            if (checkedListBox.CheckedItems.Contains("Right to Left") != true)
            {
                Properties.Settings.Default.Right_to_Left = false;
            }
            if (checkedListBox.CheckedItems.Contains("Remember Settings Until Unchecked") == true)
            {
                Properties.Settings.Default.Remember = true;
            }
            if (checkedListBox.CheckedItems.Contains("Remember Settings Until Unchecked") != true)
            {
                Properties.Settings.Default.Remember = false;
            }

            Properties.Settings.Default.Settings_Changed = true;


        }
 
        }
    }

