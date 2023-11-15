using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    class Rectangle : Shape
    {
        public Rectangle(DoubleNumber firstDoubleNumber, DoubleNumber secondDoubleNumber)
        {
            this.NameChinese = RECTANGLE_CHINESE;
            this.Name = RECTANGLE;
            this._firstDoubleNumber = firstDoubleNumber;
            this._secondDoubleNumber = secondDoubleNumber;
        }

        // public override string GetShapeName()
        public override string GetShapeName()
        {
            return this.NameChinese;
        }

        // public override string GetInfo()
        public override string GetInfo()
        {
            return $"({_firstDoubleNumber.GetInfo()}),({_secondDoubleNumber.GetInfo()})";
        }

        private DoubleNumber _firstDoubleNumber;
        private DoubleNumber _secondDoubleNumber;
    }
}
