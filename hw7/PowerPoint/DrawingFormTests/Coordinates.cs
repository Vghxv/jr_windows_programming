namespace DrawingForm.Tests
{
    public struct Coordinates
    {
        public float x1 { get; set; }
        public float y1 { get; set; }
        public float x2 { get; set; }
        public float y2 { get; set; }

        public Coordinates(float x1, float y1, float x2, float y2)
        {
            this.x1 = x1; this.y1 = y1; this.x2 = x2; this.y2 = y2;
        }

        public string FormatToString()
        {
            return $"({x1.ToString("F2")},{y1.ToString("F2")}), ({x2.ToString("F2")},{y2.ToString("F2")})";
        }
    }
}