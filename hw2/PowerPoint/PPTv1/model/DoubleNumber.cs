using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    class DoubleNumber
    {
        public DoubleNumber(int number1, int number2)
        {
            this.Number1 = number1;
            this.Number2 = number2;
        }
        public int Number1 
        { 
            set; 
            get; 
        }
        public int Number2 
        { 
            set; 
            get; 
        }

        // public GetInfo() 
        public string GetInfo()
        {
            return $"{Number1},{Number2}" ;
        }
    }
}
