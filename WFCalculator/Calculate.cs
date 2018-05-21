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
        private static bool numDeletedAfterOp = false;
        private static bool backClicked = false;
        private static double finalAns = 0;

        public static string clearBuff()
        {
            ansCalculated = false;
            rParWasClicked = false;
            numDeletedAfterOp = false;
            backClicked = false;
            finalAns = 0;
            numBuff = "";
            calcBuff = "";
            return currBuff = "";
        }

        public static string pushNum(string num)
        {
            if (backClicked && ansCalculated)
                numBuff = currBuff;

            if (ansCalculated)
                currBuff = "";

            if (rParWasClicked)
                currBuff += "*";

            if (numDeletedAfterOp)
                while (numBuff.Length != 0)
                    numBuff = numBuff.Remove(numBuff.Length - 1);

            numBuff += num;
            calcBuff = currBuff + numBuff;

            ansCalculated = false;
            rParWasClicked = false;
            numDeletedAfterOp = false;
            backClicked = false;

            return calcBuff;
        }

        public static string pushOp(string op)
        {
            if (backClicked)
                while (numBuff.Length != 0)
                    numBuff = numBuff.Remove(numBuff.Length - 1);

            currBuff += numBuff + op;
            calcBuff = currBuff;
            numBuff = "";

            ansCalculated = false;
            rParWasClicked = false;
            backClicked = false;

            return calcBuff;
        }

        public static string calcExp(string exp)
        {
            try
            {
                if (calcBuff == "")
                    return finalAns.ToString();

                /*
                if (backClicked)
                    return calcBuff;
                */

                object test = new DataTable().Compute(calcBuff, null);
                finalAns = Convert.ToDouble(new DataTable().Compute(calcBuff, null));
                currBuff = finalAns.ToString();
                numBuff = "";
                calcBuff = "";

                ansCalculated = true;
                rParWasClicked = false;
                backClicked = false;
                
                return finalAns.ToString();
            }
            catch (Exception e)
            {
                clearBuff();
                return "Input error";
            }
        }

        public static string pushL_Par()
        {
            if (backClicked)
                while (numBuff.Length != 0)
                    numBuff = numBuff.Remove(numBuff.Length - 1);

            if (!String.IsNullOrEmpty(numBuff) || ansCalculated || 
                    (backClicked && !String.IsNullOrEmpty(currBuff)))
                currBuff += numBuff + "*(";
            else
                currBuff += numBuff + "(";

            calcBuff = currBuff;
            numBuff = "";

            ansCalculated = false;
            rParWasClicked = false;
            backClicked = false;

            return calcBuff;
        }

        public static string pushR_Par()
        {
            currBuff += numBuff + ")";
            calcBuff = currBuff;
            numBuff = "";

            rParWasClicked = true;
            ansCalculated = false;
            backClicked = false;

            return calcBuff;
        }

        public static string backSpace()
        {
            backClicked = true;

            if (ansCalculated && !String.IsNullOrEmpty(currBuff))
            {
                currBuff = currBuff.Remove(currBuff.Length - 1);
                finalAns = Convert.ToDouble(currBuff);
                return currBuff;
            }

            else if (!String.IsNullOrEmpty(calcBuff) && 
                (Char.IsDigit(calcBuff[calcBuff.Length - 1]) || calcBuff[calcBuff.Length - 1] == '.'))
            {
                if(currBuff.Length == calcBuff.Length)
                    currBuff = currBuff.Remove(currBuff.Length - 1);

                numBuff = numBuff.Remove(numBuff.Length - 1);
                calcBuff = calcBuff.Remove(calcBuff.Length - 1);
                return calcBuff;
            }

            else if (!String.IsNullOrEmpty(calcBuff) && !Char.IsDigit(calcBuff[calcBuff.Length - 1]))
            {
                if (rParWasClicked)
                    rParWasClicked = false;

                calcBuff = calcBuff.Remove(calcBuff.Length - 1);
                currBuff = currBuff.Remove(currBuff.Length - 1);
                numBuff = currBuff;
                numDeletedAfterOp = true;
                return calcBuff;
            }

            ansCalculated = false;
            return calcBuff = "";
        }

        public static string Ans()
        {
            if (numBuff.Length != 0 || ansCalculated)
            {
                clearBuff();
                return "Input error";
            }

            ansCalculated = false;
            rParWasClicked = false;
            backClicked = false;

            return pushNum(finalAns.ToString());
        }
    }
}
