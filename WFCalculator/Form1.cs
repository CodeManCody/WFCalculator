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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bBack.Text = "\u2190";
            bSub.Text = "\u2212";
            bMul.Text = "\u00D7";
            bDiv.Text = "\u00F7";
            bSign.Text = "\u00B1";
            displayBox.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void b1_Click(object sender, EventArgs e)
        {
            displayBox.Text = Calculate.pushNum("1");
        }

        private void b2_Click(object sender, EventArgs e)
        {
            displayBox.Text = Calculate.pushNum("2");
        }

        private void b3_Click(object sender, EventArgs e)
        {
            displayBox.Text = Calculate.pushNum("3");
        }

        private void b4_Click(object sender, EventArgs e)
        {
            displayBox.Text = Calculate.pushNum("4");
        }

        private void b5_Click(object sender, EventArgs e)
        {
            displayBox.Text = Calculate.pushNum("5");
        }

        private void b6_Click(object sender, EventArgs e)
        {
            displayBox.Text = Calculate.pushNum("6");
        }

        private void b7_Click(object sender, EventArgs e)
        {
            displayBox.Text = Calculate.pushNum("7");
        }

        private void b8_Click(object sender, EventArgs e)
        {
            displayBox.Text = Calculate.pushNum("8");
        }

        private void b9_Click(object sender, EventArgs e)
        {
            displayBox.Text = Calculate.pushNum("9");
        }

        private void b0_Click(object sender, EventArgs e)
        {
            displayBox.Text = Calculate.pushNum("0");
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            displayBox.Text = Calculate.pushOp("+");
        }

        private void bSub_Click(object sender, EventArgs e)
        {
            displayBox.Text = Calculate.pushOp("-");
        }

        private void bMul_Click(object sender, EventArgs e)
        {
            displayBox.Text = Calculate.pushOp("*");
        }

        private void bDiv_Click(object sender, EventArgs e)
        {
            displayBox.Text = Calculate.pushOp("/");
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            displayBox.Text = Calculate.clearBuff();
        }

        private void bEqual_Click(object sender, EventArgs e)
        {
            displayBox.Text = Calculate.calcExp(displayBox.Text);
        }

        private void bL_Par_Click(object sender, EventArgs e)
        {
            displayBox.Text = Calculate.pushL_Par();
        }

        private void bR_Par_Click(object sender, EventArgs e)
        {
            displayBox.Text = Calculate.pushR_Par();
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            displayBox.Text = Calculate.backSpace();
        }
    }
}
