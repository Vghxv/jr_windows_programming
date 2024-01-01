namespace DrawingModel
{
    public class Ellipse : Shape
    {
        public Ellipse()
        {
            NameChinese = Constant.ELLIPSE_CHINESE;
        }
        
        public Ellipse(Pair firstPair, Pair secondPair)
        {
            NameChinese = Constant.ELLIPSE_CHINESE;
            FirstPair = firstPair;
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
            graphics.DrawEllipse(FirstPair, SecondPair);
            if (IsSelected)
            {
                var normalPairs = GetLocation(FirstPair, SecondPair);
                graphics.DrawRectangleHandle(normalPairs.Item1, normalPairs.Item2);
            }
        }

        // check is in _shape
        public override bool IsInShape(float number1, float number2)
        {
            Pair point = new Pair(number1, number2);
            Pair offset = new Pair(Constant.POINT_DELTA, Constant.POINT_DELTA);
            return FirstPair - offset < point && SecondPair + offset > point;
        }
    }
}
