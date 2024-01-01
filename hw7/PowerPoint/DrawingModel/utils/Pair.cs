using System;
using System.Drawing;
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
        public Pair(Size size)
        {
            Number1 = size.Width;
            Number2 = size.Height;
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
            return $"{Number1.ToString("F2")},{Number2.ToString("F2")}";
        }

        // base tostring
        public override string ToString()
        {
            return base.ToString();
        }

        // base equals
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        // base get hashcode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static Pair operator -(Pair pair)
        {
            return new Pair(-pair.Number1, -pair.Number2);
        }

        // minus
        public static Pair operator -(Pair pair1, Pair pair2)
        {
            return new Pair(pair1.Number1 - pair2.Number1, pair1.Number2 - pair2.Number2);
        }

        // plus
        public static Pair operator +(Pair pair1, Pair pair2)
        {
            return new Pair(pair1.Number1 + pair2.Number1, pair1.Number2 + pair2.Number2);
        }

        // multiply by number
        public static Pair operator *(Pair pair, int number)
        {
            return new Pair(pair.Number1 * number, pair.Number2 * number);
        }

        // divide by number
        public static Pair operator /(Pair pair, int number)
        {
            return new Pair((float)(pair.Number1 / number), (float)(pair.Number2 / number));
        }

        // multiply by pair
        public static Pair operator *(Pair pair, Pair otherPair)
        {
            return new Pair(pair.Number1 * otherPair.Number1, pair.Number2 * otherPair.Number2);
        }

        // divide by pair
        public static Pair operator /(Pair pair, Pair otherPair)
        {
            return new Pair((float)(pair.Number1 / otherPair.Number1), (float)(pair.Number2 / otherPair.Number2));
        }

        // >= operator
        public static bool operator >=(Pair pair1, Pair pair2)
        {
            return pair1.Number1 >= pair2.Number1 && pair1.Number2 >= pair2.Number2;
        }

        // <= operator
        public static bool operator <=(Pair pair1, Pair pair2)
        {
            return pair1.Number1 <= pair2.Number1 && pair1.Number2 <= pair2.Number2;
        }

        // >= operator
        public static bool operator >(Pair pair1, Pair pair2)
        {
            return pair1.Number1 > pair2.Number1 && pair1.Number2 > pair2.Number2;
        }

        // <= operator
        public static bool operator <(Pair pair1, Pair pair2)
        {
            return pair1.Number1 < pair2.Number1 && pair1.Number2 < pair2.Number2;
        }

        // ~ for abs
        public static Pair operator ~(Pair pair)
        {
            return new Pair(Math.Abs(pair.Number1), Math.Abs(pair.Number2));
        }

        // for ==
        public static bool operator ==(Pair pair1, Pair pair2)
        {
            return Math.Abs(pair1.Number1 - pair2.Number1) < Constant.FLOAT_DELTA && Math.Abs(pair1.Number2 - pair2.Number2) < Constant.FLOAT_DELTA;
        }

        // for !=
        public static bool operator !=(Pair pair1, Pair pair2)
        {
            return !(pair1 == pair2);
        }
    }
}
