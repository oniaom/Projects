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
using System.Reflection;
using SearchDLL;

namespace Project_SearchTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            rtbNames.Text = @"Available names (Case Sensitive):
Oliver
Jake
Noah
James
Jack
Connor
Liam
John
Harry";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string sTypedText = tbQuery.Text;
            rtbNames.Clear();
            Search search = new Search();
            string[] test = search.Names(sTypedText);
            for (int i = 0; i < test.Length; i++)
            {
                rtbNames.AppendText(test[i] + Environment.NewLine);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

  

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
