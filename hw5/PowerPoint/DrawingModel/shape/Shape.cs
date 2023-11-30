using System;
using System.ComponentModel;

namespace DrawingModel
{
    public class Shape : INotifyPropertyChanged
    {
        private Pair _firstPair;
        private Pair _secondPair;
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
        public Pair FirstPair
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
        [System.ComponentModel.Browsable(false)]
        public Pair SecondPair
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
        public void Move(Pair offset)
        {
            _firstPair += offset;
            _secondPair += offset;
        }

        // is in shape
        public virtual bool IsInShape(float number1, float number2)
        {
            return false;
        }

        // arrange points to top left and bottom right
        public void ArrangePairs()
        {
            var pairs = GetLocation(FirstPair, SecondPair);
            FirstPair = pairs.Item1;
            SecondPair = pairs.Item2;
        }

        // get location
        public (Pair, Pair) GetLocation(Pair pair1, Pair pair2)
        {
            Pair newPair1 = new Pair(Math.Min(pair1.Number1, pair2.Number1), Math.Min(pair1.Number2, pair2.Number2));
            Pair newPair2 = new Pair(Math.Max(pair1.Number1, pair2.Number1), Math.Max(pair1.Number2, pair2.Number2));
            return (newPair1, newPair2);
        }

        // get location by shape
        public (Pair, Pair) GetLocation()
        {
            Pair newPair1 = new Pair(Math.Min(FirstPair.Number1, SecondPair.Number1), Math.Min(FirstPair.Number2, SecondPair.Number2));
            Pair newPair2 = new Pair(Math.Max(FirstPair.Number1, SecondPair.Number1), Math.Max(FirstPair.Number2, SecondPair.Number2));
            return (newPair1, newPair2);
        }
    }
}
