using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_SorterDLL;

namespace Project_SorterAPP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<int> lNumbers = new List<int>();
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BAdd_Click(object sender, EventArgs e)
        {
            lNumbers.Add(int.Parse(tbNumbers.Text));
            lView.Text = tbNumbers.Text;
            tbNumbers.Clear();
        }

        private void BSort_Click(object sender, EventArgs e)
        {
            int[] iSortedNumbers = Sorter.Sort(lNumbers.ToArray());
            foreach (int iNumber in iSortedNumbers)
            {
                tbNumbers.AppendText(iNumber.ToString()+ ",");
            }
            string sTextboxNumbers = tbNumbers.Text;
            sTextboxNumbers = sTextboxNumbers.Substring(0, sTextboxNumbers.Length - 1);
            tbNumbers.Text = sTextboxNumbers + ".";
            lView.ResetText();
        }
    }
}
