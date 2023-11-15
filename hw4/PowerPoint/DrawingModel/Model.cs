using System;
namespace DrawingModel
{
    public class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler(object sender, EventArgs e);
        private Shapes _shapes;
        private Shape _hint;
        private ModelState _modelState;

        public Shapes ShapesManager
        {
            get
            {
                return _shapes;
            }
        }

        public Model() 
        { 
            _shapes = new Shapes();
            _modelState = new IdleState(this); ;
        }

        // asd
        public void SetState(ModelState state)
        {
            _modelState = state;
            NotifyModelChanged();
        }

        // asd
        public ModelState GetState() 
        {
            return _modelState;
        }

        // asd
        public void RemoveShape(int index)
        {
            _shapes.RemoveShape(index);
            NotifyModelChanged();
        }

        // sdf
        public void ClearShapes()
        {
            _shapes.ClearShapes();
            NotifyModelChanged();
        }

        // sdf
        public void SetShapeSelected(bool isSelected)
        {
            _shapes.SetShapeSelected(isSelected);
            NotifyModelChanged();
        }

        // asd
        public void GoPointerPressed(float number1, float number2)
        {
            _modelState.MouseDown(number1, number2);
        }

        // asd
        public void GoPointerMoved(float number1, float number2)
        {
            if (!(_modelState is IdleState))
            {
                _modelState.MouseMove(number1, number2);
                NotifyModelChanged();
            }
        }

        // asd
        public void GoPointerReleased(float number1, float number2)
        {
            _modelState.MouseUp(number1, number2);
            if (_modelState is DrawingState){
                SetState(new IdleState(this));
            }
            NotifyModelChanged();
        }

        // asd
        public void AddShape(string name)
        {
            DoubleNumber firstDoubleNumber = DoubleNumberFactory.CreateRandomDoubleNumber(
            Constant.MIN_X, Constant.MAX_X, Constant.MIN_Y, Constant.MAX_Y);
            DoubleNumber secondDoubleNumber = DoubleNumberFactory.CreateRandomDoubleNumber(
            (int)firstDoubleNumber.Number1, Constant.MAX_X, (int)firstDoubleNumber.Number2, Constant.MAX_Y);
            _shapes.AddShape(name, firstDoubleNumber, secondDoubleNumber);
            NotifyModelChanged();
        }

        //asd
        public void Draw(IGraphics graphics)
        {
            foreach (Shape shape in _shapes)
            {
                shape.Draw(graphics);
            }
            _modelState.Draw(graphics);
        }

        // asd
        public void NotifyModelChanged()
        {
            _modelChanged?.Invoke(null, null);
        }

        // asd
        public void SetHint(string name)
        {
            _hint = ShapeFactory.CreateShape(name);
        }

        // asd
        public void DrawHint(IGraphics graphics)
        {
            _hint.Draw(graphics);
        }

        // asd
        public void SetHintFirstPoint(float number1, float number2)
        {
            _hint.FirstDoubleNumber.Number1 = number1;
            _hint.FirstDoubleNumber.Number2 = number2;
        }

        // asd
        public void SetHintSecondPoint(float number1, float number2)
        {
            _hint.SecondDoubleNumber.Number1 = number1;
            _hint.SecondDoubleNumber.Number2 = number2;
        }

        // asd
        public void AddHintToShapes()
        {
            _shapes.AddShape(_hint);
        }
    }
}