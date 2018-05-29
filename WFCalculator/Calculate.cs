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
        private static string buff = "";
        private static double finalAns = 0;
        private static bool ansCalculated = false;

        public static string clearBuff()
        {
            if(!ansCalculated)
                finalAns = 0;

            ansCalculated = false;
            return "";
        }

        public static string calcExp()
        {
            try
            {
                buff = Form1.expr;
                if (buff == "")
                    return buff = "";
                finalAns = Convert.ToDouble(new DataTable().Compute(buff, null));
                ansCalculated = true;
                return finalAns.ToString();
            }
            catch (OverflowException o)
            {
                clearBuff();
                return "Value too large";
            }
            catch (Exception e)
            {
                clearBuff();
                return "Input error";
            }
        }

        public static string backSpace()
        {
            ansCalculated = false;

            buff = Form1.expr;

            if(!String.IsNullOrEmpty(buff))
                buff = buff.Remove(buff.Length - 1);

            return buff;
        }

        public static string Ans()
        {

            ansCalculated = false;
   
            return finalAns.ToString();
        }

        public static string pushBuff(string obj)
        {
            if (ansCalculated && Char.IsDigit(obj[0]))
                clearBuff();

            if (!String.IsNullOrEmpty(buff) && 
                    (Char.IsDigit(buff[buff.Length - 1]) || buff[buff.Length - 1] == ')') && obj == "(")
                obj = "*(";

            buff += obj;
            ansCalculated = false;
            return obj;
        }
    }
}
