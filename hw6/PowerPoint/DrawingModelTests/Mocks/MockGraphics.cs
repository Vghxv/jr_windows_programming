using DrawingModel;

namespace DrawingModel.Tests
{
    public class MockGraphics : IGraphics
    {
        public bool DrawLineCalled 
        { 
            get; 
            private set; 
        }
        public bool DrawEllipseCalled 
        { 
            get; 
            private set; 
        }
        public bool DrawRectangleCalled 
        { 
            get; 
            private set; 
        }
        public bool DrawLineHandleCalled 
        { 
            get; 
            private set; 
        }
        public bool DrawRectangleHandleCalled 
        { 
            get; 
            private set; 
        }

        // ClearAll method to clear any tracking or state
        public void ClearAll()
        {
            // Implement as needed for your testing scenario
        }

        // Implementation of the DrawLine method from the IGraphics interface
        public void DrawLine(Pair pair1, Pair pair2)
        {
            DrawLineCalled = true;
        }

        // Implementation of the DrawEllipse method from the IGraphics interface
        public void DrawEllipse(Pair pair1, Pair pair2)
        {
            DrawEllipseCalled = true;
        }

        // Implementation of the DrawRectangle method from the IGraphics interface
        public void DrawRectangle(Pair pair1, Pair pair2)
        {
            DrawRectangleCalled = true;
        }

        // Implementation of the DrawRectangleHandle method from the IGraphics interface
        public void DrawRectangleHandle(Pair pair1, Pair pair2)
        {
            DrawRectangleHandleCalled = true;
        }

        // Implementation of the DrawLineHandle method from the IGraphics interface
        public void DrawLineHandle(Pair pair1, Pair pair2)
        {
            DrawLineHandleCalled = true;
        }
    }
}
