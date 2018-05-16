using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFCalculator
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            if(Environment.OSVersion.Version.Major >= 6)    // fix high DPI fuzziness
                SetProcessDPIAware();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]    // fix high DPI fuzziness
        private static extern bool SetProcessDPIAware();
    }
}

