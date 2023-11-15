using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    class DoubleNumberFactory
    {
        // asd
        private static int GetSeed()
        {
            long ticks = DateTime.Now.Ticks;
            return (int)(ticks & 0x7FFFFFFF);
        }

        // public static Vector2d CreateVector2d(int number1, int number2)
        public static DoubleNumber CreateDoubleNumber(int number1, int number2)
        {
            return new DoubleNumber(number1, number2);
        }

        // create random vector with range number1 to number2
        public static DoubleNumber CreateRandomDoubleNumber(int minimumX, int maximumX, int minimumY, int maximumY)
        {
            Random random = new Random(GetSeed());
            int firstInteger = random.Next(minimumX, maximumX);
            int secondInteger = random.Next(minimumY, maximumY);
            return new DoubleNumber(firstInteger, secondInteger);
        }
    }
}
