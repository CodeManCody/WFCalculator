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

        private string expr;



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
                displayBox.Text = "";
            ansCalculated = false;
            displayBox.Text += Calculate.pushBuff("1");
        }

        private void b2_Click(object sender, EventArgs e)
        {
            if (ansCalculated)
                displayBox.Text = "";
            ansCalculated = false;
            displayBox.Text += Calculate.pushBuff("2");
        }

        private void b3_Click(object sender, EventArgs e)
        {
            if (ansCalculated)
                displayBox.Text = "";
            ansCalculated = false;
            displayBox.Text += Calculate.pushBuff("3");
        }

        private void b4_Click(object sender, EventArgs e)
        {
            if (ansCalculated)
                displayBox.Text = "";
            ansCalculated = false;
            displayBox.Text += Calculate.pushBuff("4");
        }

        private void b5_Click(object sender, EventArgs e)
        {
            if (ansCalculated)
                displayBox.Text = "";
            ansCalculated = false;
            displayBox.Text += Calculate.pushBuff("5");
        }

        private void b6_Click(object sender, EventArgs e)
        {
            if (ansCalculated)
                displayBox.Text = "";
            ansCalculated = false;
            displayBox.Text += Calculate.pushBuff("6");
        }

        private void b7_Click(object sender, EventArgs e)
        {
            if (ansCalculated)
                displayBox.Text = "";
            ansCalculated = false;
            displayBox.Text += Calculate.pushBuff("7");
        }

        private void b8_Click(object sender, EventArgs e)
        {
            if (ansCalculated)
                displayBox.Text = "";
            ansCalculated = false;
            displayBox.Text += Calculate.pushBuff("8");
        }

        private void b9_Click(object sender, EventArgs e)
        {
            if (ansCalculated)
                displayBox.Text = "";
            ansCalculated = false;
            displayBox.Text += Calculate.pushBuff("9");
        }

        private void b0_Click(object sender, EventArgs e)
        {
            if (ansCalculated)
                displayBox.Text = "";
            ansCalculated = false;
            displayBox.Text += Calculate.pushBuff("0");
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            ansCalculated = false;
            displayBox.Text += Calculate.pushBuff("+");
        }

        private void bSub_Click(object sender, EventArgs e)
        {
            ansCalculated = false;
            displayBox.Text += Calculate.pushBuff("-");
        }

        private void bMul_Click(object sender, EventArgs e)
        {
            ansCalculated = false;
            displayBox.Text += Calculate.pushBuff("*");
        }

        private void bDiv_Click(object sender, EventArgs e)
        {
            ansCalculated = false;
            displayBox.Text += Calculate.pushBuff("/");
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            ansCalculated = false;
            displayBox.Text = Calculate.clearBuff();
        }

        private void bEqual_Click(object sender, EventArgs e)
        {
            ansCalculated = true;
            displayBox.Text = Calculate.calcExp();
        }

        private void bL_Par_Click(object sender, EventArgs e)
        {
            ansCalculated = false;
            displayBox.Text += Calculate.pushBuff("(");
        }

        private void bR_Par_Click(object sender, EventArgs e)
        {
            ansCalculated = false;
            displayBox.Text += Calculate.pushBuff(")");
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            ansCalculated = false;
            displayBox.Text = Calculate.backSpace();
        }

        private void bDec_Click(object sender, EventArgs e)
        {
            ansCalculated = false;
            displayBox.Text += Calculate.pushBuff(".");
        }

        private void bAns_Click(object sender, EventArgs e)
        {
            ansCalculated = false;
            displayBox.Text += Calculate.Ans();
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
                invalidCharEntered = true;

            if (e.KeyCode == Keys.Delete)
            {
                Calculate.clearBuff();
                displayBox.Text = "";
            }

            if ( ansCalculated && ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
               (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)))
            {
                Calculate.clearBuff();
                displayBox.Text = "";
                ansCalculated = false;

            }
        }

        private void displayBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ansCalculated = false;

            if (invalidCharEntered)     // only allow nums & ops
                e.Handled = true;

            expr = displayBox.Text;

            if ((e.KeyChar == 13 || e.KeyChar == 61))     // Enter or '=' calcs expr
            {
                Calculate.pushBuff(expr);
                displayBox.Text = Calculate.calcExp();
                ansCalculated = true;
                displayBox.SelectionStart = displayBox.Text.Length;
            }

        }

        
    }
}
