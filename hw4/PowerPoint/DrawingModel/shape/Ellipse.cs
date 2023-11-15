using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class Ellipse : Shape
    {
        public Ellipse()
        {
            this.NameChinese = Constant.ELLIPSE_CHINESE;
        }
        
        public Ellipse(DoubleNumber firstDoubleNumber, DoubleNumber secondDoubleNumber)
        {
            this.NameChinese = Constant.ELLIPSE_CHINESE;
            this.FirstDoubleNumber = firstDoubleNumber;
            this.SecondDoubleNumber = secondDoubleNumber;
        }
        
        // asd
        public override string GetInfo()
        {
            return $"({FirstDoubleNumber.GetInfo()}),({SecondDoubleNumber.GetInfo()})";
        }

        // asd
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawEllipse(FirstDoubleNumber, SecondDoubleNumber);
            if (IsSelected)
            {
                graphics.DrawRectangleHandle(FirstDoubleNumber, SecondDoubleNumber);
            }
        }

        // asd
        public override bool IsInShape(float number1, float number2)
        {
            DoubleNumber doubleNumber = new DoubleNumber(number1, number2);
            if (FirstDoubleNumber <= doubleNumber && SecondDoubleNumber >= doubleNumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
