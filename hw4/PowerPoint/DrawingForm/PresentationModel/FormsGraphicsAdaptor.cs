using System.Drawing;
using DrawingModel;
using static System.Math;


namespace DrawingForm
{
    class FormsGraphicsAdaptor : IGraphics
    {
        Graphics _graphics;
        public FormsGraphicsAdaptor(Graphics graphics)
        {
            this._graphics = graphics;
        }

        // asd
        public void ClearAll()
        {
            // screen would clear when OnPaint trigger, no implementation needed
        }

        // draw line
        public void DrawLine(DoubleNumber firstDoubleNumber, DoubleNumber secondDoubleNumber)
        {
            _graphics.DrawLine(Pens.Black, firstDoubleNumber.Number1, 
            firstDoubleNumber.Number2, secondDoubleNumber.Number1, secondDoubleNumber.Number2);
        }

        // draw rectangle
        public void DrawRectangle(DoubleNumber firstDoubleNumber, DoubleNumber secondDoubleNumber)
        {
            DoubleNumber doubleNumber = (~(firstDoubleNumber - secondDoubleNumber));
            _graphics.DrawRectangle(Pens.Black, 
            Min(firstDoubleNumber.Number1, secondDoubleNumber.Number1),
            Min(firstDoubleNumber.Number2,secondDoubleNumber.Number2), 
            doubleNumber.Number1,
            doubleNumber.Number2);
        }

        // draw ellipse
        public void DrawEllipse(DoubleNumber firstDoubleNumber, DoubleNumber secondDoubleNumber)
        {
            DoubleNumber doubleNumber = (~(firstDoubleNumber - secondDoubleNumber));
            _graphics.DrawEllipse(Pens.Black,
            Min(firstDoubleNumber.Number1, secondDoubleNumber.Number1),
            Min(firstDoubleNumber.Number2, secondDoubleNumber.Number2),
            doubleNumber.Number1,
            doubleNumber.Number2);
        }

        // asd
        public void DrawRectangleHandle(DoubleNumber firstDoubleNumber, DoubleNumber secondDoubleNumber)
        {
            DoubleNumber offset = ~(firstDoubleNumber - secondDoubleNumber);
            for (int i = 0; i < Constant.NINE ;  i++)
            {
                if (i ==  Constant.FOUR)
                    continue;
                float x = firstDoubleNumber.Number1 - (Constant.HANDLE_SIZE >> 1) + (i % (Constant.THREE) * (offset.Number1 / 2));
                float y = firstDoubleNumber.Number2 - (Constant.HANDLE_SIZE >> 1) + (i / (Constant.THREE) * (offset.Number2 / 2));
                _graphics.DrawEllipse(Pens.Red, x, y, Constant.HANDLE_SIZE, Constant.HANDLE_SIZE);
            }
        }

        //a asd
        public void DrawLineHandle(DoubleNumber firstDoubleNumber, DoubleNumber secondDoubleNumber)
        {
            for (DoubleNumber i = firstDoubleNumber; i <= secondDoubleNumber; i += (secondDoubleNumber - firstDoubleNumber) / 2)
            {
                float x = i.Number1 - (Constant.HANDLE_SIZE >> 1);
                float y = i.Number2 - (Constant.HANDLE_SIZE >> 1);
                _graphics.DrawEllipse(Pens.Red, x, y, Constant.HANDLE_SIZE, Constant.HANDLE_SIZE);
            }
                

        }
    }
}