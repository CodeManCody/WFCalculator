﻿using System;
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

        public static string backSpace(int index)
        {
            ansCalculated = false;

            buff = Form1.expr;

            if (String.IsNullOrEmpty(buff))
                return buff;

            if (index == 0)
                return buff;
            else if (index == buff.Length)
                return buff = buff.Remove(buff.Length - 1);
            else
                return buff = buff.Remove(index - 1, 1);
            
        }

        public static string Ans()
        {

            ansCalculated = false;
   
            return finalAns.ToString();
        }

       
    }
}
