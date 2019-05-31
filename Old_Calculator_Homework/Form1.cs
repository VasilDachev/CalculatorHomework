using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Old_Calculator_Homework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double Result = 0;
        double MemoryNumber = 0;
        string operation = "";
        bool CheckOperation = false;
        bool MemoryCheck = false;

        private void btn_click(object sender, EventArgs e)
        {
            if ((tbShow.Text == "0") || (CheckOperation))
                tbShow.Clear();

            CheckOperation= false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!tbShow.Text.Contains("."))
                    tbShow.Text = tbShow.Text + button.Text;

            }
            else
                tbShow.Text = tbShow.Text + button.Text;
        }

        private void btn_operatorClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (Result != 0)
            {
                btnEquals.PerformClick();
                operation = button.Text;
                CheckOperation = true;
            }
            else
            {

                operation = button.Text;
                Result = Double.Parse(tbShow.Text);
                CheckOperation = true;
            }
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            tbShow.Text = "";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            tbShow.Text = "";
            Result = 0;
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+":
                    tbShow.Text = (Result + Double.Parse(tbShow.Text)).ToString();
                    break;
                case "-":
                    tbShow.Text = (Result - Double.Parse(tbShow.Text)).ToString();
                    break;
                case "*":
                    tbShow.Text = (Result * Double.Parse(tbShow.Text)).ToString();
                    break;
                case "/":
                    tbShow.Text = (Result / Double.Parse(tbShow.Text)).ToString();
                    break;
                default:
                    break;
            }
            Result = Double.Parse(tbShow.Text);
        }

        private void btnAddToMemory_Click(object sender, EventArgs e)
        {
            MemoryNumber = double.Parse(tbShow.Text);
            MemoryCheck = true;
            tbShow.Clear();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (MemoryCheck!=true)
            {
                MessageBox.Show("Empty memory!");
            }
            else
            {
                tbShow.Text = (MemoryNumber + Double.Parse(tbShow.Text)).ToString();
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (MemoryCheck != true)
                MessageBox.Show("Empty memory!");
            
            else
                tbShow.Text = (Double.Parse(tbShow.Text) - MemoryNumber).ToString();
            
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (MemoryCheck!=true)
                MessageBox.Show("Empty memory!");
            
            else
                MessageBox.Show("Stored number -> " + MemoryNumber);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (MemoryCheck!=true)
                MessageBox.Show("Already clear!");
            else
            {
                MemoryNumber = 0;
                MemoryCheck = false;
            }
        }
    }
}
