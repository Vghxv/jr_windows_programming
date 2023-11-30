using System.Drawing;
using static System.Math;

namespace DrawingModel
{
    public class FormsGraphicsAdaptor : IGraphics
    {
        Graphics _graphics;
        public FormsGraphicsAdaptor(Graphics graphics)
        {
            _graphics = graphics;
        }

        // clear all
        public void ClearAll()
        {
            // screen would clear when OnPaint trigger, no implementation needed
        }

        // draw line
        public void DrawLine(Pair pair1, Pair pair2)
        {
            _graphics.DrawLine(Pens.Black, pair1.Number1, 
            pair1.Number2, pair2.Number1, pair2.Number2);
        }

        // draw rectangle
        public void DrawRectangle(Pair pair1, Pair pair2)
        {
            Pair doubleNumber = (~(pair1 - pair2));
            _graphics.DrawRectangle(Pens.Black, 
            Min(pair1.Number1, pair2.Number1),
            Min(pair1.Number2,pair2.Number2), 
            doubleNumber.Number1,
            doubleNumber.Number2);
        }

        // draw ellipse
        public void DrawEllipse(Pair pair1, Pair pair2)
        {
            Pair doubleNumber = (~(pair1 - pair2));
            _graphics.DrawEllipse(Pens.Black,
            Min(pair1.Number1, pair2.Number1),
            Min(pair1.Number2, pair2.Number2),
            doubleNumber.Number1,
            doubleNumber.Number2);
        }

        // draw rectangle handle
        public void DrawRectangleHandle(Pair pair1, Pair pair2)
        {
            Pair offset = ~(pair1 - pair2);
            int offsetX = (int)offset.Number1;
            int offsetY = (int)offset.Number2;
            for (int i = 0; i < Constant.NINE ;  i++)
            {
                if (i ==  Constant.FOUR)
                    continue;
                float x = pair1.Number1 - Constant.HANDLE_SIZE + (i % (Constant.THREE) * (offsetX >> 1));
                float y = pair1.Number2 - Constant.HANDLE_SIZE + (i / (Constant.THREE) * (offsetY >> 1));
                _graphics.DrawEllipse(Pens.Red, x, y, Constant.HANDLE_SIZE << 1, Constant.HANDLE_SIZE << 1);
            }
        }

        // draw line handle
        public void DrawLineHandle(Pair pair1, Pair pair2)
        {
            Pair middleDoubleNumber = (pair1 + pair2) / 2;
            _graphics.DrawEllipse(Pens.Red, pair1.Number1 - Constant.HANDLE_SIZE, pair1.Number2 - Constant.HANDLE_SIZE, Constant.HANDLE_SIZE << 1, Constant.HANDLE_SIZE << 1);
            _graphics.DrawEllipse(Pens.Red, pair2.Number1 - Constant.HANDLE_SIZE, pair2.Number2 - Constant.HANDLE_SIZE, Constant.HANDLE_SIZE << 1, Constant.HANDLE_SIZE << 1);
            _graphics.DrawEllipse(Pens.Red, middleDoubleNumber.Number1 - Constant.HANDLE_SIZE, middleDoubleNumber.Number2 - Constant.HANDLE_SIZE, Constant.HANDLE_SIZE << 1, Constant.HANDLE_SIZE << 1);
        }
    }
}