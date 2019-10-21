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
        /*
        Initializing 3 Vars
        First_Number - Is the main number I'll be using to store the user's input
        inProgress - To see if the user pressed any calculation actions (+.-.*,/)
        Calc_State - To know which calculation action button the user pressed
        */
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
          //If the user made a mistake in the numbers, remove the last number present.          
           string Current = tbDisplay.Text;
           Current = Current.Substring(0, (tbDisplay.TextLength - 1));
           tbDisplay.Text = Current;
        }

        private void BPlus_Click(object sender, EventArgs e)
        {   
            /*
             Checks if the user pressed any calculation acions. 
             If not, save the current number to our First_Number int, and clear the display
             If yes, Add the number to the already existing previous number and update the var.
            */
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
            /*
            Checks if the user pressed any calculation acions. 
            If not, save the current number to our First_Number int, and clear the display
            If yes, Subtract the number to the already existing previous number and update the var.
           */
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
            /*
            Checks if the user pressed any calculation acions. 
            If not, save the current number to our First_Number int, and clear the display
            If yes, Multiply the number to the already existing previous number and update the var.
           */
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
            /*
            Checks if the user pressed any calculation acions. 
            If not, save the current number to our First_Number int, and clear the display
            If yes, Divide the number to the already existing previous number and update the var.
           */
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
            // Check which button the user pressed last, do the calculation and update the display.
            int total = 0;
            string state = Calc_State;
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
        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
