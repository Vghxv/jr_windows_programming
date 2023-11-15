using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawingModel
{
    public class DoubleNumber
    {
        // pair
        public DoubleNumber(float number1, float number2)
        {
            this.Number1 = number1;
            this.Number2 = number2;
        }
        public DoubleNumber() 
        {
            this.Number1 = -1;
            this.Number2 = -1;
        }
        public DoubleNumber(DoubleNumber doubleNumber)
        {
            this.Number1 = doubleNumber.Number1;
            this.Number2 = doubleNumber.Number2;
        }
        
        public float Number1
        {
            set;
            get;
        }
        public float Number2
        {
            set;
            get;
        }

        // public GetInfo() 
        public string GetInfo()
        {
            return $"{Number1},{Number2}";
        }

        // offset
        public void Offset(DoubleNumber doubleNumber)
        {
            Number1 += doubleNumber.Number1;
            Number2 += doubleNumber.Number2;
        }

        // minus
        public static DoubleNumber operator -(DoubleNumber doubleNumber1, DoubleNumber doubleNumber2)
        {
            return new DoubleNumber(doubleNumber1.Number1 - doubleNumber2.Number1, doubleNumber1.Number2 - doubleNumber2.Number2);
        }

        // plus
        public static DoubleNumber operator +(DoubleNumber doubleNumber1, DoubleNumber doubleNumber2)
        {
            return new DoubleNumber(doubleNumber1.Number1 + doubleNumber2.Number1, doubleNumber1.Number2 + doubleNumber2.Number2);
        }

        // divide by 2
        public static DoubleNumber operator /(DoubleNumber doubleNumber, int number)
        {
            return new DoubleNumber(doubleNumber.Number1 / number, doubleNumber.Number2 / number);
        }

        // < operator
        public static bool operator <(DoubleNumber doubleNumber1, DoubleNumber doubleNumber2)
        {
            if (doubleNumber1.Number1 < doubleNumber2.Number1 && doubleNumber1.Number2 < doubleNumber2.Number2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // > operator
        public static bool operator >(DoubleNumber doubleNumber1, DoubleNumber doubleNumber2)
        {
            if (doubleNumber1.Number1 > doubleNumber2.Number1 && doubleNumber1.Number2 > doubleNumber2.Number2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // >= operator
        public static bool operator >=(DoubleNumber doubleNumber1, DoubleNumber doubleNumber2)
        {
            if (doubleNumber1.Number1 >= doubleNumber2.Number1 && doubleNumber1.Number2 >= doubleNumber2.Number2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // <= operator
        public static bool operator <=(DoubleNumber doubleNumber1, DoubleNumber doubleNumber2)
        {
            if (doubleNumber1.Number1 <= doubleNumber2.Number1 && doubleNumber1.Number2 <= doubleNumber2.Number2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // ~ for abs
        public static DoubleNumber operator ~(DoubleNumber doubleNumber)
        {
            return new DoubleNumber(Math.Abs(doubleNumber.Number1), Math.Abs(doubleNumber.Number2));
        }
            
        // asd
        public static void ExchangeFirstNumber(DoubleNumber doubleNumber1, DoubleNumber doubleNumber2)
        {
            float temp = doubleNumber1.Number1;
            doubleNumber1.Number1 = doubleNumber1.Number1;
            doubleNumber1.Number1 = temp;
        }

        // asd
        public static void ExchangeSecondNumber(DoubleNumber doubleNumber1, DoubleNumber doubleNumber2)
        {
            float temp = doubleNumber1.Number2;
            doubleNumber1.Number2 = doubleNumber1.Number2;
            doubleNumber1.Number2 = temp;
        }
    }
}
