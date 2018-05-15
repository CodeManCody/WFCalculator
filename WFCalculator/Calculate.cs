using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFCalculator
{
    class Calculate
    {
        private static string numBuff = "";
        private static string displayBuff = "";
        private static string calcBuff = "";
        private static bool rParWasClicked = false;

        public static string pushBuff(string num)
        {
            if (rParWasClicked)
                displayBuff += "*";

            rParWasClicked = false;
            numBuff += num;
            calcBuff = displayBuff + numBuff;
            return calcBuff;
        }
        














    }
}
