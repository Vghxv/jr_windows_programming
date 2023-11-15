using System;

namespace DrawingModel
{
    class Line : Shape
    {
        public Line()
        {
            NameChinese = Constant.LINE_CHINESE;
        }   

        public Line(DoubleNumber firstDoubleNumber, DoubleNumber secondDoubleNumber)
        {
            NameChinese = Constant.LINE_CHINESE;
            FirstDoubleNumber = firstDoubleNumber;
            SecondDoubleNumber = secondDoubleNumber;
            
        }

        // asd
        public override string GetInfo()
        {
            return $"({FirstDoubleNumber.GetInfo()}),({SecondDoubleNumber.GetInfo()})";
        }

        // asd
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(FirstDoubleNumber, SecondDoubleNumber);
            if (IsSelected)
            {
                graphics.DrawLineHandle(FirstDoubleNumber, SecondDoubleNumber);
            }
        }

        // asd
        public override bool IsInShape(float number1, float number2)
        {
            if (CaculateDistance(number1, number2) < Constant.LINE_SELECT_DISTANCE)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // caculate line-point distance
        public double CaculateDistance(float number1, float number2)
        {
            DoubleNumber doubleNumber = SecondDoubleNumber - FirstDoubleNumber;
            double slope = doubleNumber.Number2 / doubleNumber.Number1;
            double intercept = FirstDoubleNumber.Number2 - slope * FirstDoubleNumber.Number1;
            return Math.Abs(slope * number1 - number2 + intercept) / Math.Sqrt(Math.Pow(slope, 2) + 1);
        }
    }
}
