namespace DrawingModel
{
    public class Rectangle : Shape
    {
        public Rectangle()
        {
            NameChinese = Constant.RECTANGLE_CHINESE;
        }

        public Rectangle(Pair pair1, Pair pair2)
        {
            NameChinese = Constant.RECTANGLE_CHINESE;
            FirstPair = pair1;
            SecondPair = pair2;
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
                var normalPairs = GetLocation();
                graphics.DrawRectangleHandle(normalPairs.Item1, normalPairs.Item2);
            }
        }

        // check is in _shape
        public override bool IsInShape(float number1, float number2)
        {
            Pair point = new Pair(number1, number2);
            Pair offset = new Pair(Constant.POINT_DELTA, Constant.POINT_DELTA);
            return FirstPair - offset <= point && SecondPair + offset >= point;
        }
    }
}
