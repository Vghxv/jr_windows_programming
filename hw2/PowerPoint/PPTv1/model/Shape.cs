using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Shape
    {
        public const string LINE_CHINESE = "線";
        public const string RECTANGLE_CHINESE = "矩形";
        public const string LINE = "Line";
        public const string RECTANGLE = "Rectangle";
        public const string LEFT_BRACKET = "(";
        public const string COMMA = ",";
        public const string RIGHT_BRACKET = ")";
        public Shape()
        {
            this.NameChinese = "";
            this.Name = "";
        }

        public string NameChinese 
        { 
            set; 
            get; 
        }

        public string Name
        {
            set;
            get;
        }

        // public virtual string GetInfo()
        public virtual string GetInfo()
        {
            return "";
        }

        //	public virtual string GetShapeName()
        public virtual string GetShapeNameChinese()
        {
            return NameChinese;
        }

        //	public virtual string GetShapeName()
        public virtual string GetShapeName()
        {
            return Name;
        }
    }
}
