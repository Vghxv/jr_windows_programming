using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class DoubleNumberFactory
    {
        // get seed
        private static int GetSeed()
        {
            long ticks = DateTime.Now.Ticks;
            return (int)(ticks & 0x7FFFFFFF);
        }

        // factory
        public static DoubleNumber CreateDoubleNumber(float number1, float number2)
        {
            return new DoubleNumber(number1, number2);
        }

        // rand factory
        public static DoubleNumber CreateRandomDoubleNumber(int minimumX, int maximumX, int minimumY, int maximumY)
        {
            Random random = new Random(GetSeed());
            int firstInteger = random.Next(minimumX, maximumX);
            int secondInteger = random.Next(minimumY, maximumY);
            return new DoubleNumber(firstInteger, secondInteger);
        }
    }
}
