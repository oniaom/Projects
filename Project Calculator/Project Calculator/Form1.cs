using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        public int First_Number;
        public bool inProgress = false;
        public string Calc_State;
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BNum1_Click(object sender, EventArgs e)
        {
            tbDisplay.AppendText("1");
        }

        private void BNum2_Click(object sender, EventArgs e)
        {
            tbDisplay.AppendText("2");
        }

        private void BNum3_Click(object sender, EventArgs e)
        {
            tbDisplay.AppendText("3");
        }

        private void BNum4_Click(object sender, EventArgs e)
        {
            tbDisplay.AppendText("4");
        }

        private void BNum5_Click(object sender, EventArgs e)
        {
            tbDisplay.AppendText("5");
        }

        private void BNum6_Click(object sender, EventArgs e)
        {
            tbDisplay.AppendText("6");
        }

        private void BNum7_Click(object sender, EventArgs e)
        {
            tbDisplay.AppendText("7");
        }

        private void BNum8_Click(object sender, EventArgs e)
        {
            tbDisplay.AppendText("8");
        }

        private void BNum9_Click(object sender, EventArgs e)
        {
            tbDisplay.AppendText("9");
        }

        private void BNum0_Click(object sender, EventArgs e)
        {
            tbDisplay.AppendText("0");
        }

        private void BMistake_Click(object sender, EventArgs e)
        {
            string Current = tbDisplay.Text;
           Current = Current.Substring(0, (tbDisplay.TextLength - 1));
           tbDisplay.Text = Current;
        }

        private void BPlus_Click(object sender, EventArgs e)
        {         
            if (inProgress == false)
            { 
            int CurrentNumber = int.Parse(tbDisplay.Text);
            First_Number = CurrentNumber;
            tbDisplay.Clear();
            inProgress = true;
            Calc_State = "+";
            }
            else
            {
                int total = First_Number + int.Parse(tbDisplay.Text);
                
                First_Number = total;
                inProgress = false;
                tbDisplay.Clear();
                Calc_State = "+";

            }


        }

        private void BMinus_Click(object sender, EventArgs e)
        {
            if (inProgress == false)
            {
                int CurrentNumber = int.Parse(tbDisplay.Text);
                First_Number = CurrentNumber;
                tbDisplay.Clear();
                inProgress = true;
                Calc_State = "-";
            }
            else
            {
                int total = First_Number - int.Parse(tbDisplay.Text);

                First_Number = total;
                inProgress = false;
                tbDisplay.Clear();
                Calc_State = "-";

            }
        }

  


        private void BTimes_Click(object sender, EventArgs e)
        {
            if (inProgress == false)
            {
                int CurrentNumber = int.Parse(tbDisplay.Text);
                First_Number = CurrentNumber;
                tbDisplay.Clear();
                inProgress = true;
                Calc_State = "*";
            }
            else
            {
                int total = First_Number * int.Parse(tbDisplay.Text);

                First_Number = total;
                inProgress = false;
                tbDisplay.Clear();
                Calc_State = "*";
            }
        }

        private void BDivide_Click(object sender, EventArgs e)
        {
            if (inProgress == false)
            {
                int CurrentNumber = int.Parse(tbDisplay.Text);
                First_Number = CurrentNumber;
                tbDisplay.Clear();
                inProgress = true;
                Calc_State = "/";
            }
            else
            {
                int total = First_Number / int.Parse(tbDisplay.Text);

                First_Number = total;
                inProgress = false;
                tbDisplay.Clear();
                Calc_State = "/";
            }

        }
        private void BCalculate_Click(object sender, EventArgs e)
        {
            int total = 0;
            string state= Calc_State;
            switch (state)
            {
                case "+":
                    total = First_Number + int.Parse(tbDisplay.Text);
                    tbDisplay.Text = total.ToString();
                    First_Number = total;
                    inProgress = false;
                    break;
                case "-":
                    total = First_Number - int.Parse(tbDisplay.Text);
                    tbDisplay.Text = total.ToString();
                    First_Number = total;
                    inProgress = false;
                    break;
                case "*":
                    total = First_Number * int.Parse(tbDisplay.Text);
                    tbDisplay.Text = total.ToString();
                    First_Number = total;
                    inProgress = false;
                    break;
                case "/":
                    total = First_Number / int.Parse(tbDisplay.Text);
                    tbDisplay.Text = total.ToString();
                    First_Number = total;
                    inProgress = false;
                    break;
                default:
                    tbDisplay.Text = "error";
                    break;
            }
            
        }


        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {



        }
 
        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
