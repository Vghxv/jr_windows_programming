using DrawingModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class Rectangle : Shape
    {
        public Rectangle()
        {
            this.NameChinese = Constant.RECTANGLE_CHINESE;
        }

        // asd
        public Rectangle(DoubleNumber firstDoubleNumber, DoubleNumber secondDoubleNumber)
        {
            this.NameChinese = Constant.RECTANGLE_CHINESE;
            this.FirstDoubleNumber = firstDoubleNumber;
            this.SecondDoubleNumber = secondDoubleNumber;
        }

        // public override string GetInfo()
        public override string GetInfo()
        {
            return $"({FirstDoubleNumber.GetInfo()}),({SecondDoubleNumber.GetInfo()})";
        }

        // asd
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(FirstDoubleNumber, SecondDoubleNumber);
            if (IsSelected)
            {
                graphics.DrawRectangleHandle(FirstDoubleNumber, SecondDoubleNumber);
            }
        }

        // asf
        public override bool IsInShape(float number1, float number2)
        {
            //if (number1 >= FirstDoubleNumber.Number1 && number1 <= SecondDoubleNumber.Number1 && number2 >= FirstDoubleNumber.Number2 && number2 <= SecondDoubleNumber.Number2)
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
