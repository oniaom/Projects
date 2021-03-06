﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        
        public string CurrentSize { 
            get 
            {
                Form1 first = (Form1)form1;
                return first.TextSize;
            }
            set { }
        }
        Form form1;
        public Form2(Form originalForm)
        {
            form1 = originalForm;
            Form1 first = (Form1)form1;
            InitializeComponent();
            textBox1.Text = CurrentSize;         
            string[] states = new string[4];
            states = first.currentStates;
            StringBuilder builder = new StringBuilder();       
            foreach (string prop in states)
            {
                builder.Append(prop + " ");
            }


            if (builder.ToString().Contains("Bold")) { checkBox1.Checked = true; }
            if (builder.ToString().Contains("Italic")) { checkBox2.Checked = true; }
            if (builder.ToString().Contains("Underline")) { checkBox3.Checked = true; }
            if (builder.ToString().Contains("Strikethrough")) { checkBox4.Checked = true; }




        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Form1 first = (Form1)form1;
            first.TextSize = textBox1.Text;
            //bool[] checkboxes = { checkBox1.Checked, checkBox2.Checked, checkBox3.Checked, checkBox4.Checked};
            //first.test(checkboxes);
            string[] properties = new string[4];
            if (checkBox1.Checked)
            {
                properties[0] = "Bold";
            }
            if (checkBox2.Checked)
            {
                properties[1] = "Italic";
            }
            if (checkBox3.Checked)
            {
                properties[2] = "Strikethrough";
            }
            if (checkBox4.Checked)
            {
                properties[3] = "Underline";
            }
            first.RtbProperties(properties);
            first.test = properties;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
