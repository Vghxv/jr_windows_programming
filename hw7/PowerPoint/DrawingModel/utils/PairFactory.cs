using System;
using System.Drawing;

namespace DrawingModel
{
    public class PairFactory
    {
        // get seed
        public static int GetSeed(long offset)
        {
            long ticks = DateTime.Now.Ticks + offset;
            return (int)(ticks & 0x7FFFFFFF);
        }

        // factory
        public static Pair CreatePair(float number1, float number2)
        {
            return new Pair(number1, number2);
        }

        // rand factory
        public static Pair CreateRandomPair(Pair boundX, Pair boundY, int seed)
        {
            Random random = new Random(GetSeed(seed));
            int firstInteger = random.Next((int)boundX.Number1, (int)boundX.Number2);
            random = new Random(GetSeed(seed * seed));
            int secondInteger = random.Next((int)boundY.Number1, (int)boundY.Number2);
            return new Pair(firstInteger, secondInteger);
        }
    }
}
