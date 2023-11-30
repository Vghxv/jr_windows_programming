using System;
namespace DrawingModel
{
    public class Pair
    {
        public Pair(float number1, float number2)
        {
            Number1 = number1;
            Number2 = number2;
        }

        public Pair()
        {
            Number1 = -1;
            Number2 = -1;
        }
        public Pair(Pair newPair)
        {
            Number1 = newPair.Number1;
            Number2 = newPair.Number2;
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

        // minus
        public static Pair operator -(Pair doubleNumber1, Pair doubleNumber2)
        {
            return new Pair(doubleNumber1.Number1 - doubleNumber2.Number1, doubleNumber1.Number2 - doubleNumber2.Number2);
        }

        // plus
        public static Pair operator +(Pair doubleNumber1, Pair doubleNumber2)
        {
            return new Pair(doubleNumber1.Number1 + doubleNumber2.Number1, doubleNumber1.Number2 + doubleNumber2.Number2);
        }

        // divide by 2
        public static Pair operator /(Pair doubleNumber, int number)
        {
            return new Pair(doubleNumber.Number1 / number, doubleNumber.Number2 / number);
        }

        // >= operator
        public static bool operator >=(Pair doubleNumber1, Pair doubleNumber2)
        {
            return doubleNumber1.Number1 >= doubleNumber2.Number1 && doubleNumber1.Number2 >= doubleNumber2.Number2;
        }

        // <= operator
        public static bool operator <=(Pair doubleNumber1, Pair doubleNumber2)
        {
            return doubleNumber1.Number1 <= doubleNumber2.Number1 && doubleNumber1.Number2 <= doubleNumber2.Number2;
        }

        // >= operator
        public static bool operator >(Pair doubleNumber1, Pair doubleNumber2)
        {
            return doubleNumber1.Number1 > doubleNumber2.Number1 && doubleNumber1.Number2 > doubleNumber2.Number2;
        }

        // <= operator
        public static bool operator <(Pair doubleNumber1, Pair doubleNumber2)
        {
            return doubleNumber1.Number1 < doubleNumber2.Number1 && doubleNumber1.Number2 < doubleNumber2.Number2;
        }

        // ~ for abs
        public static Pair operator ~(Pair doubleNumber)
        {
            return new Pair(Math.Abs(doubleNumber.Number1), Math.Abs(doubleNumber.Number2));
        }
    }
}
