using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DrawingModel
{
    public class SlideBuffer
    {
        private Bitmap _bitmap;
        public event SlideChangedEventHandler _slideChanged;
        public delegate void SlideChangedEventHandler(EventArgs e);

        public Bitmap Bitmap
        {
            get 
            { 
                return _bitmap; 
            }
            set 
            {
                _bitmap = value;
            }
        }

        // nofity slide changed
        public void NotifySlideChanged()
        {
            if (_slideChanged != null) {
                _slideChanged(new EventArgs());
            }
        }
    }
}