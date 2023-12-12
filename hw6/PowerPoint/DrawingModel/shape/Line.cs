using System;

namespace DrawingModel
{
    public class Line : Shape
    {
        public Line()
        {
            NameChinese = Constant.LINE_CHINESE;
        }   

        public Line(Pair firstpair, Pair secondPair)
        {
            NameChinese = Constant.LINE_CHINESE;
            FirstPair = firstpair;
            SecondPair = secondPair;
        }

        // get info
        public override string GetInfo()
        {
            return $"({FirstPair.GetInfo()}),({SecondPair.GetInfo()})";
        }

        // draw
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(FirstPair, SecondPair);
            if (IsSelected)
            {
                graphics.DrawLineHandle(FirstPair, SecondPair);
            }
        }

        // check is in _shape
        public override bool IsInShape(float number1, float number2)
        {
            Pair point = new Pair(number1, number2);
            var normalPairs = GetLocation(FirstPair, SecondPair);
            Pair topLeftPair = normalPairs.Item1;
            Pair bottonRightPair = normalPairs.Item2;
            return CalculateDistance(number1, number2) < Constant.LINE_SELECT_DISTANCE && IsInBox(point, topLeftPair, bottonRightPair);
        }

        // check is in box
        private bool IsInBox(Pair point, Pair topLeftPair, Pair bottonRightPair)
        {
            Pair offset = new Pair(Constant.POINT_DELTA, Constant.POINT_DELTA);
            return topLeftPair - offset < point && bottonRightPair + offset > point;
        }

        // caculate line-point distance
        private double CalculateDistance(float number1, float number2)
        {
            Pair pair = SecondPair - FirstPair;
            if (pair.Number1 == 0)
            {
                return 0;
            }
            double slope = pair.Number2 / pair.Number1;
            double intercept = FirstPair.Number2 - slope * FirstPair.Number1;
            return Math.Abs(slope * number1 - number2 + intercept) / Math.Sqrt(Math.Pow(slope, 2) + 1);
        }
    }
}
