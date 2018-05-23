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
            finalAns = 0;
            return buff = "";
        }

        

        

        public static string calcExp(string exp)
        {
            try
            {
                finalAns = Convert.ToDouble(new DataTable().Compute(buff, null));
                buff = finalAns.ToString();
                ansCalculated = true;

                return buff;
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

            if(!String.IsNullOrEmpty(buff))
                buff = buff.Remove(buff.Length - 1);

            return buff;
        }

        public static string Ans()
        {
            return finalAns.ToString();
        }

        public static string pushBuff(string obj)
        {
            if (ansCalculated && Char.IsDigit(obj[0]))
                clearBuff();

            if (!String.IsNullOrEmpty(buff) && Char.IsDigit(buff[buff.Length - 1]) && obj == "(")
                obj = "*(";

            buff += obj;
            ansCalculated = false;
            return obj;
        }
    }
}
