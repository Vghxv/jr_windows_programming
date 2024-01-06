using System;
using System.ComponentModel;
using System.Drawing;

namespace DrawingModel
{
    public class Shape : INotifyPropertyChanged
    {
        private Pair _firstPair;
        private Pair _secondPair;
        private string _nameChinese;
        private bool _isSelected;
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual string NameChinese
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
        [Browsable(false)]
        public virtual Pair FirstPair
        {
            set
            {
                if (!value.Equals(_firstPair))
                {
                    _firstPair = value;
                    OnPropertyChanged(nameof(FirstPair));
                }
            }
            get
            {
                return _firstPair;
            }
        }
        [Browsable(false)]
        public virtual Pair SecondPair
        {
            set
            {
                if (!value.Equals(_secondPair))
                {
                    _secondPair = value;
                    OnPropertyChanged(nameof(SecondPair));
                }
            }
            get
            {
                return _secondPair;
            }
        }
        public string Info
        {
            get
            {
                return $"({ _firstPair.GetInfo()}), ({_secondPair.GetInfo()})";
            }
        }
        [Browsable(false)]
        public virtual bool IsSelected
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
            _firstPair = new Pair();
            _secondPair = new Pair();
        }

        // get info
        public virtual string GetInfo()
        {
            return string.Empty;
        }

        // draw
        public virtual void Draw(IGraphics graphics)
        {
            return;
        }

        // on property changed
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // move
        public virtual void Move(Pair offset)
        {
            _firstPair += offset;
            _secondPair += offset;
        }

        // resize
        public virtual void Move(Pair offset1, Pair offset2)
        {
            _firstPair += offset1;  
            _secondPair += offset2;
        }

        // is in _shape
        public virtual bool IsInShape(float number1, float number2)
        {
            return false;
        }

        // arrange points to top left and bottom right
        public virtual void ArrangePairs()
        {
            var pairs = GetLocation();
            FirstPair = pairs.Item1;
            SecondPair = pairs.Item2;
        }

        // get location
        public virtual (Pair, Pair) GetLocation()
        {
            Pair newPair1 = new Pair(Math.Min(FirstPair.Number1, SecondPair.Number1), Math.Min(FirstPair.Number2, SecondPair.Number2));
            Pair newPair2 = new Pair(Math.Max(FirstPair.Number1, SecondPair.Number1), Math.Max(FirstPair.Number2, SecondPair.Number2));
            return (newPair1, newPair2);
        }

        // resize shape
        public virtual void Resize(Pair original, Pair target)
        {
            FirstPair = FirstPair * target / original;
            SecondPair = SecondPair * target / original;
        }
    }
}
