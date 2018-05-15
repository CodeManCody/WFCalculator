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
        }
    }
}
