using System;
namespace DrawingModel
{
    public class PairFactory
    {
        // get seed
        private static int GetSeed()
        {
            long ticks = DateTime.Now.Ticks;
            return (int)(ticks & 0x7FFFFFFF);
        }

        // factory
        public static Pair CreateDoubleNumber(float number1, float number2)
        {
            return new Pair(number1, number2);
        }

        // rand factory
        public static Pair CreateRandomDoubleNumber(int minimumX, int maximumX, int minimumY, int maximumY)
        {
            Random random = new Random(GetSeed());
            int firstInteger = random.Next(minimumX, maximumX);
            int secondInteger = random.Next(minimumY, maximumY);
            return new Pair(firstInteger, secondInteger);
        }
    }
}
