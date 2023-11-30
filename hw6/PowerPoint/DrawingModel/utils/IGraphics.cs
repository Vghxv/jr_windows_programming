namespace DrawingModel
{
    public interface IGraphics
    {
        // clear all
        void ClearAll();

        // draw line
        void DrawLine(Pair pair1, Pair pair2);

        // draw ellipse
        void DrawEllipse(Pair pair1, Pair pair2);

        // draw rectangle
        void DrawRectangle(Pair pair1, Pair pair2);

        // draw rec lint
        void DrawRectangleHandle(Pair pair1, Pair pair2);

        // draw line lint
        void DrawLineHandle(Pair pair1, Pair pair2);
    }
}
