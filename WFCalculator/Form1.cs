using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFCalculator
{
    public partial class Form1 : Form
    {
        private bool ansCalculated = false;

        public static string expr;



        public Form1()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyPress +=
                new KeyPressEventHandler(displayBox_KeyPress);
            displayBox.KeyPress +=
                new KeyPressEventHandler(displayBox_KeyPress);

            expr = displayBox.Text;
        }


        
        


        private void Form1_Load(object sender, EventArgs e)
        {
            bBack.Text = "\u2190";
            bSub.Text = "\u2212";
            bMul.Text = "\u00D7";
            bDiv.Text = "\u00F7";
            displayBox.SelectionAlignment = HorizontalAlignment.Right;
    }

        private void b1_Click(object sender, EventArgs e)
        {
            if (ansCalculated)
                displayBox.Text = Calculate.clearBuff();
            ansCalculated = false;
            displayBox.Text += "1";
            expr = displayBox.Text;
            displayBox.Focus();
            displayBox.SelectionStart = displayBox.Text.Length;
        }

        private void b2_Click(object sender, EventArgs e)
        {
            if (ansCalculated)
                displayBox.Text = Calculate.clearBuff();
            ansCalculated = false;
            displayBox.Text += "2";
            expr = displayBox.Text;
            displayBox.Focus();
            displayBox.SelectionStart = displayBox.Text.Length;
        }

        private void b3_Click(object sender, EventArgs e)
        {
            if (ansCalculated)
                displayBox.Text = Calculate.clearBuff();
            ansCalculated = false;
            displayBox.Text += "3";
            expr = displayBox.Text;
            displayBox.Focus();
            displayBox.SelectionStart = displayBox.Text.Length;
        }

        private void b4_Click(object sender, EventArgs e)
        {
            if (ansCalculated)
                displayBox.Text = Calculate.clearBuff();
            ansCalculated = false;
            displayBox.Text += "4";
            expr = displayBox.Text;
            displayBox.Focus();
            displayBox.SelectionStart = displayBox.Text.Length;
        }

        private void b5_Click(object sender, EventArgs e)
        {
            if (ansCalculated)
                displayBox.Text = Calculate.clearBuff();
            ansCalculated = false;
            displayBox.Text += "5";
            expr = displayBox.Text;
            displayBox.Focus();
            displayBox.SelectionStart = displayBox.Text.Length;
        }

        private void b6_Click(object sender, EventArgs e)
        {
            if (ansCalculated)
                displayBox.Text = Calculate.clearBuff();
            ansCalculated = false;
            displayBox.Text += "6";
            expr = displayBox.Text;
            displayBox.Focus();
            displayBox.SelectionStart = displayBox.Text.Length;
        }

        private void b7_Click(object sender, EventArgs e)
        {
            if (ansCalculated)
                displayBox.Text = Calculate.clearBuff();
            ansCalculated = false;
            displayBox.Text += "7";
            expr = displayBox.Text;
            displayBox.Focus();
            displayBox.SelectionStart = displayBox.Text.Length;
        }

        private void b8_Click(object sender, EventArgs e)
        {
            if (ansCalculated)
                displayBox.Text = Calculate.clearBuff();
            ansCalculated = false;
            displayBox.Text += "8";
            expr = displayBox.Text;
            displayBox.Focus();
            displayBox.SelectionStart = displayBox.Text.Length;
        }

        private void b9_Click(object sender, EventArgs e)
        {
            if (ansCalculated)
                displayBox.Text = Calculate.clearBuff();
            ansCalculated = false;
            displayBox.Text += "9";
            expr = displayBox.Text;
            displayBox.Focus();
            displayBox.SelectionStart = displayBox.Text.Length;
        }

        private void b0_Click(object sender, EventArgs e)
        {
            if (ansCalculated)
                displayBox.Text = Calculate.clearBuff();
            ansCalculated = false;
            displayBox.Text += "0";
            expr = displayBox.Text;
            displayBox.Focus();
            displayBox.SelectionStart = displayBox.Text.Length;
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            ansCalculated = false;
            displayBox.Text += "+";
            expr = displayBox.Text;
            displayBox.Focus();
            displayBox.SelectionStart = displayBox.Text.Length;
        }

        private void bSub_Click(object sender, EventArgs e)
        {
            ansCalculated = false;
            displayBox.Text += "-";
            expr = displayBox.Text;
            displayBox.Focus();
            displayBox.SelectionStart = displayBox.Text.Length;
        }

        private void bMul_Click(object sender, EventArgs e)
        {
            ansCalculated = false;
            displayBox.Text += "*";
            expr = displayBox.Text;
            displayBox.Focus();
            displayBox.SelectionStart = displayBox.Text.Length;
        }

        private void bDiv_Click(object sender, EventArgs e)
        {
            ansCalculated = false;
            displayBox.Text += "/";
            expr = displayBox.Text;
            displayBox.Focus();
            displayBox.SelectionStart = displayBox.Text.Length;
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            ansCalculated = false;
            displayBox.Text = Calculate.clearBuff();
            expr = displayBox.Text;
            displayBox.Focus();
            displayBox.SelectionStart = displayBox.Text.Length;
        }

        private void bEqual_Click(object sender, EventArgs e)
        {
            ansCalculated = true;
            displayBox.Text = Calculate.calcExp();
            expr = displayBox.Text;
            displayBox.Focus();
            displayBox.SelectionStart = displayBox.Text.Length;
        }

        private void bL_Par_Click(object sender, EventArgs e)
        {
            ansCalculated = false;

            if (Char.IsDigit(displayBox.Text[displayBox.Text.Length - 1]))
                displayBox.Text += "*(";
            else
                displayBox.Text += "(";

            expr = displayBox.Text;
            displayBox.Focus();
            displayBox.SelectionStart = displayBox.Text.Length;
        }

        private void bR_Par_Click(object sender, EventArgs e)
        {
            ansCalculated = false;
            displayBox.Text += ")";
            expr = displayBox.Text;
            displayBox.Focus();
            displayBox.SelectionStart = displayBox.Text.Length;
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            ansCalculated = false;
            displayBox.Text = Calculate.backSpace();
            expr = displayBox.Text;
            displayBox.Focus();
            displayBox.SelectionStart = displayBox.Text.Length;
        }

        private void bDec_Click(object sender, EventArgs e)
        {
            ansCalculated = false;
            displayBox.Text += ".";
            expr = displayBox.Text;
            displayBox.Focus();
            displayBox.SelectionStart = displayBox.Text.Length;
        }

        private void bAns_Click(object sender, EventArgs e)
        {
            ansCalculated = false;
            displayBox.Text += Calculate.Ans();
            expr = displayBox.Text;
            displayBox.Focus();
            displayBox.SelectionStart = displayBox.Text.Length;
        }



       


        private bool invalidCharEntered = false;

        private void displayBox_KeyDown(object sender, KeyEventArgs e)
        {
            invalidCharEntered = false;

              char test = Convert.ToChar(e.KeyCode);



            if (!(e.KeyCode == Keys.D1 && !e.Shift || e.KeyCode == Keys.D2 && !e.Shift ||
                  e.KeyCode == Keys.D3 && !e.Shift || e.KeyCode == Keys.D4 && !e.Shift ||
                  e.KeyCode == Keys.D5 && !e.Shift || e.KeyCode == Keys.D6 && !e.Shift ||
                  e.KeyCode == Keys.D7 && !e.Shift || e.KeyCode == Keys.D8 || e.KeyCode == Keys.D9 ||
                  e.KeyCode == Keys.D0 || e.KeyCode == Keys.OemMinus && !e.Shift ||
                  e.KeyCode == Keys.Oemplus && e.Shift || e.KeyCode == Keys.Back ||
                  e.KeyCode == Keys.OemPeriod && !e.Shift || e.KeyCode == Keys.OemQuestion && !e.Shift ||
                  (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) ||
                  e.KeyCode == Keys.Divide || e.KeyCode == Keys.Multiply || e.KeyCode == Keys.Subtract ||
                  e.KeyCode == Keys.Add || e.KeyCode == Keys.Decimal || e.KeyCode == Keys.Back ||
                  e.KeyCode == Keys.Delete) || e.Alt || e.KeyCode == Keys.Enter)
            {
                invalidCharEntered = true;
            }


           

            if (e.KeyCode == Keys.Delete)
            {
                Calculate.clearBuff();
                displayBox.Text = "";
            }

            if (ansCalculated && ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
               (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)))
            {
                Calculate.clearBuff();
                displayBox.Text = "";
                ansCalculated = false;

            }

           // if (e.KeyCode == Keys.Enter)
             //   displayBox.Text = "";
        }

        private void displayBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ansCalculated = false;

            if (invalidCharEntered)     // only allow nums & ops
                e.Handled = true;

            expr = displayBox.Text;

            if ((e.KeyChar == 13 || e.KeyChar == 61))     // Enter or '=' calcs expr
            {
                expr = expr.TrimEnd('\r', '\n');
                bEqual_Click(sender, e);
            }


        }

        
    }
}
