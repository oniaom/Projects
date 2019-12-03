using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Program_Downloader
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (string selection in checkedListBox1.CheckedItems)
            {
                if (selection == "Windows 10") { System.Diagnostics.Process.Start("https://www.nvidia.com/Download/driverResults.aspx/155056/en-us"); }
                else if (selection == "Windows 8.1" | selection =="Windows 8.0") { System.Diagnostics.Process.Start("https://www.nvidia.com/Download/driverResults.aspx/155054/en-us"); }         
            }
        }
    }
}
