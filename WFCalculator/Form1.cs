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
        private int index = 0;

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
            _push("1");  
        }

        private void b2_Click(object sender, EventArgs e)
        {
            _push("2"); 
        }

        private void b3_Click(object sender, EventArgs e)
        {
            _push("3"); 
        }

        private void b4_Click(object sender, EventArgs e)
        {
            _push("4");
        }

        private void b5_Click(object sender, EventArgs e)
        {
            _push("5"); 
        }

        private void b6_Click(object sender, EventArgs e)
        {
            _push("6");
        }

        private void b7_Click(object sender, EventArgs e)
        {
            _push("7");
        }

        private void b8_Click(object sender, EventArgs e)
        {
            _push("8");
        }

        private void b9_Click(object sender, EventArgs e)
        {
            _push("9");
        }

        private void b0_Click(object sender, EventArgs e)
        {
            _push("0");
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            _push("+");
        }

        private void bSub_Click(object sender, EventArgs e)
        {
            _push("-");
        }

        private void bMul_Click(object sender, EventArgs e)
        {
            _push("*");
        }

        private void bDiv_Click(object sender, EventArgs e)
        {
            _push("/");
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
            if (displayBox.Text != "")
            {
                if (Char.IsDigit(displayBox.Text[displayBox.Text.Length - 1]) ||
                    displayBox.Text[displayBox.Text.Length - 1] == ')')
                {
                    _push("*(");
                }
                else
                    _push("(");
            }
            else
                _push("(");
        }

        private void bR_Par_Click(object sender, EventArgs e)
        {
            _push(")");
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            ansCalculated = false;
            expr = displayBox.Text;

            index = displayBox.SelectionStart;

            displayBox.Text = Calculate.backSpace(index);
            
            displayBox.Focus();

            if (index != 0)
                displayBox.SelectionStart = index - 1;           
        }

        private void bDec_Click(object sender, EventArgs e)
        {
            _push(".");
        }

        private void bAns_Click(object sender, EventArgs e)
        {
            _push(Calculate.Ans());
        }



       
        private void _push(string obj)
        {
            if (ansCalculated && Char.IsDigit(obj[0]))
                displayBox.Text = Calculate.clearBuff();

            ansCalculated = false;

            if (displayBox.Text != "")
            {
                if (Char.IsDigit(obj[0]) && displayBox.Text[displayBox.SelectionStart - 1] == ')')
                    R_Par_Helper();
            }

            if (displayBox.SelectionStart == displayBox.Text.Length)
            {
                displayBox.Text += obj;
                displayBox.SelectionStart = displayBox.Text.Length;
            }
            else
            {
                index = displayBox.SelectionStart;
                displayBox.Text = displayBox.Text.Insert(displayBox.SelectionStart, obj);
                if (obj == "*(")
                    displayBox.SelectionStart = index + 2;
                else
                    displayBox.SelectionStart = index + 1;
            }

            expr = displayBox.Text;
            displayBox.Focus();
        }

        private void R_Par_Helper()
        {   
            if (displayBox.SelectionStart == displayBox.Text.Length)
            {
                displayBox.Text += "*";
                displayBox.SelectionStart = displayBox.Text.Length;
            }
            else
            {
                index = displayBox.SelectionStart;
                displayBox.Text = displayBox.Text.Insert(displayBox.SelectionStart, "*");
                displayBox.SelectionStart = index + 1;
            }
        }



        private bool invalidCharEntered = false;
        private bool L_ParStroke = false;

        private void displayBox_KeyDown(object sender, KeyEventArgs e)
        {
            invalidCharEntered = false;
            L_ParStroke = false;

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


            if ( (e.KeyCode == Keys.Delete) ||
                 (ansCalculated && ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D7) ||
                 e.KeyCode == Keys.D8 && !e.Shift || e.KeyCode == Keys.D9 && !e.Shift ||
                 e.KeyCode == Keys.D0 && !e.Shift ||
                 (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))) )
            {
                bClear_Click(sender, e);
            }

            if (e.KeyCode == Keys.D9 && e.Shift)
            {
                L_ParStroke = true;
                bL_Par_Click(sender, e);
            }


            expr = displayBox.Text;

            if (expr != "")
            {
                if ((e.KeyCode == Keys.D1 && !e.Shift || e.KeyCode == Keys.D2 && !e.Shift ||
                     e.KeyCode == Keys.D3 && !e.Shift || e.KeyCode == Keys.D4 && !e.Shift ||
                     e.KeyCode == Keys.D5 && !e.Shift || e.KeyCode == Keys.D6 && !e.Shift ||
                     e.KeyCode == Keys.D7 && !e.Shift || e.KeyCode == Keys.D8 && !e.Shift || 
                     e.KeyCode == Keys.D9 && !e.Shift || e.KeyCode == Keys.D0 && !e.Shift ||
                     ((e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) && !e.Alt)) &&
                     displayBox.Text[displayBox.SelectionStart - 1] == ')')
                {
                    R_Par_Helper();
                    expr = displayBox.Text;
                    displayBox.Focus();
                }
            }

   
        }

        private void displayBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            expr = displayBox.Text;
            ansCalculated = false;

            if (invalidCharEntered)     // only allow nums & ops
                e.Handled = true;

            if (L_ParStroke)
                e.Handled = true;

            

            if ((e.KeyChar == 13 || e.KeyChar == 61))     // Enter or '=' calcs expr
            {
                expr = expr.TrimEnd('\r', '\n');
                bEqual_Click(sender, e);
            }


        }

        
    }
}
