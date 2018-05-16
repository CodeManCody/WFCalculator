using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WFCalculator
{
    class Calculate
    {
        private static string numBuff = "";
        private static string currBuff = "";
        private static string calcBuff = "";
        private static bool rParWasClicked = false;
        private static bool ansCalculated = false;
        private static bool temp = false;
        private static double finalAns = 0;

        public static string clearBuff()
        {
            finalAns = 0;
            numBuff = "";
            calcBuff = "";
            return currBuff = "";
        }

        public static string pushNum(string num)
        {
            if (ansCalculated)
                currBuff = "";

            if (rParWasClicked)
                currBuff += "*";

            ansCalculated = false;
            rParWasClicked = false;
            numBuff += num;
            calcBuff = currBuff + numBuff;
            return calcBuff;
        }

        public static string pushOp(string op)
        {
            if (op == ")")
            {
                rParWasClicked = true;
                temp = rParWasClicked;
            }

            if ((op == "(" && !String.IsNullOrEmpty(numBuff)) || (op == "(" && temp))
            {
                currBuff += numBuff + "*" + op;
                temp = false;
            }
            else
                currBuff += numBuff + op;

            ansCalculated = false;
            rParWasClicked = false;
            calcBuff = currBuff;
            numBuff = "";
            return calcBuff;
        }

        public static string calcExp(string exp)
        {
            try
            {
                finalAns = Convert.ToDouble(new DataTable().Compute(calcBuff, null));
                ansCalculated = true;
                rParWasClicked = false;
                currBuff = finalAns.ToString();
                numBuff = "";
                return finalAns.ToString();
            }
            catch (Exception)
            {
                clearBuff();
                rParWasClicked = false;
                return "Input error";
            }
        }
        














    }
}
