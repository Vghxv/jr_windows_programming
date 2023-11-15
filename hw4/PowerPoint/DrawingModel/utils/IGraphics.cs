using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public interface IGraphics
    {
        // clear all
        void ClearAll();

        // draw line
        void DrawLine(DoubleNumber firstDoubleNumber, DoubleNumber doubleNumber);

        // draw ellipse
        void DrawEllipse(DoubleNumber firstDoubleNumber, DoubleNumber doubleNumber);

        // draw rectangle
        void DrawRectangle(DoubleNumber firstDoubleNumber, DoubleNumber doubleNumber);

        // draw rec lint
        void DrawRectangleHandle(DoubleNumber firstDoubleNumber, DoubleNumber doubleNumber);

        // draw line lint
        void DrawLineHandle(DoubleNumber firstDoubleNumber, DoubleNumber doubleNumber);
    }
}
