using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    class Line : Shape
    {
        public Line(DoubleNumber firstDoubleNumber, DoubleNumber secondDoubleNumber)
        {
            this.NameChinese = LINE_CHINESE;
            this.Name = LINE;
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
