using System;
using System.ComponentModel;
using System.Drawing;

namespace DrawingModel
{
    public class Shape : INotifyPropertyChanged
    {
        private DoubleNumber _firstDoubleNumber;
        private DoubleNumber _secondDoubleNumber;
        private string _nameChinese;
        private bool _isSelected;
        public event PropertyChangedEventHandler PropertyChanged;

        public string NameChinese
        {
            set
            {
                if (_nameChinese != value)
                {
                    _nameChinese = value;
                    OnPropertyChanged(nameof(NameChinese));
                }
            }
            get
            {
                return _nameChinese;
            }
        }
        [System.ComponentModel.Browsable(false)]
        public DoubleNumber FirstDoubleNumber
        {
            set
            {
                if (!value.Equals(_firstDoubleNumber))
                {
                    _firstDoubleNumber = value;
                    OnPropertyChanged(nameof(FirstDoubleNumber));
                }
            }
            get
            {
                return _firstDoubleNumber;
            }
        }
        [System.ComponentModel.Browsable(false)]
        public DoubleNumber SecondDoubleNumber
        {
            set
            {
                if (!value.Equals(_secondDoubleNumber))
                {
                    _secondDoubleNumber = value;
                    OnPropertyChanged(nameof(SecondDoubleNumber));
                }
            }
            get
            {
                return _secondDoubleNumber;
            }
        }
        public string Info
        {
            get
            {
                return $"({ _firstDoubleNumber.GetInfo()}), ({_secondDoubleNumber.GetInfo()})";
            }
        }
        [System.ComponentModel.Browsable(false)]
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }   
        }
        
        public Shape()
        {
            this._firstDoubleNumber = new DoubleNumber();
            this._secondDoubleNumber = new DoubleNumber();
        }

        // asd
        public virtual string GetInfo()
        {
            return $"({_firstDoubleNumber.GetInfo()}),({_secondDoubleNumber.GetInfo()})";
        }

        // drawing
        public virtual void Draw(IGraphics graphics)
        {
            
        }

        //asd 
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // asd
        public void Move(DoubleNumber offset)
        {
            if (_isSelected){
                _firstDoubleNumber.Offset(offset);
                _secondDoubleNumber.Offset(offset);

            }
        }

        // asd
        public virtual bool IsInShape(float number1, float number2)
        {
            return false;
        }

        // re arrange 
        public void ArrangeDoubleNumbers()
        {
            if (FirstDoubleNumber.Number1 > SecondDoubleNumber.Number1)
            {
                DoubleNumber.ExchangeFirstNumber(FirstDoubleNumber, SecondDoubleNumber);
            }
            if (FirstDoubleNumber.Number2 > SecondDoubleNumber.Number2)
            {
                DoubleNumber.ExchangeSecondNumber(FirstDoubleNumber, SecondDoubleNumber);
            }
        }
    }
}
