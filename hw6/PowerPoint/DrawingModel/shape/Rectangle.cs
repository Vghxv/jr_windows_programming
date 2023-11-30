namespace DrawingModel
{
    public class Rectangle : Shape
    {
        public Rectangle()
        {
            NameChinese = Constant.RECTANGLE_CHINESE;
        }

        public Rectangle(Pair firstDoubleNumber, Pair secondDoubleNumber)
        {
            NameChinese = Constant.RECTANGLE_CHINESE;
            FirstPair = firstDoubleNumber;
            SecondPair = secondDoubleNumber;
        }

        // get info
        public override string GetInfo()
        {
            return $"({FirstPair.GetInfo()}),({SecondPair.GetInfo()})";
        }

        // draw
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(FirstPair, SecondPair);
            if (IsSelected)
            {
                graphics.DrawRectangleHandle(FirstPair, SecondPair);
            }
        }

        // check is in shape
        public override bool IsInShape(float number1, float number2)
        {
            Pair point = new Pair(number1, number2);
            Pair offset = new Pair(Constant.POINT_DELTA, Constant.POINT_DELTA);
            return FirstPair - offset <= point && SecondPair + offset >= point;
        }
        
    }
}
