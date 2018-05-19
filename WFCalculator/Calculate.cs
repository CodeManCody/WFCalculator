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
        private static double finalAns = 0;

        public static string clearBuff()
        {
            ansCalculated = false;
            rParWasClicked = false;
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
            ansCalculated = false;
            rParWasClicked = false;
            currBuff += numBuff + op;
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
                calcBuff = "";
                return finalAns.ToString();
            }
            catch (Exception)
            {
                clearBuff();
                rParWasClicked = false;
                return "Input error";
            }
        }

        public static string pushL_Par()
        {
            ansCalculated = false;
            rParWasClicked = false;

            if (!String.IsNullOrEmpty(numBuff))
                currBuff += numBuff + "*(";
            else
                currBuff += numBuff + "(";

            calcBuff = currBuff;
            numBuff = "";
            return calcBuff;
        }

        public static string pushR_Par()
        {
            ansCalculated = false;
            rParWasClicked = true;
            currBuff += numBuff + ")";
            calcBuff = currBuff;
            numBuff = "";
            return calcBuff;
        }

        public static string backSpace()
        {
            if (ansCalculated && !String.IsNullOrEmpty(currBuff))
            {
                currBuff = currBuff.Remove(currBuff.Length - 1);
                return currBuff;
            }

            else if (!String.IsNullOrEmpty(calcBuff) && Char.IsDigit(calcBuff[calcBuff.Length - 1]))
            {
                numBuff = numBuff.Remove(numBuff.Length - 1);
                calcBuff = currBuff + numBuff;
                return calcBuff;
            }

            else if (!String.IsNullOrEmpty(calcBuff) && !Char.IsDigit(calcBuff[calcBuff.Length - 1]))
            {
                if (rParWasClicked)
                    rParWasClicked = false;

                calcBuff = calcBuff.Remove(calcBuff.Length - 1);
                currBuff = currBuff.Remove(currBuff.Length - 1);
                return calcBuff;
            }

            return "";
        }
        














    }
}
