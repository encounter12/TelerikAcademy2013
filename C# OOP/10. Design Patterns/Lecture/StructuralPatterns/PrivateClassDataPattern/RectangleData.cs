namespace PrivateClassDataPattern
{
    internal class RectangleData
    {
        public double Width { get; private set; }

        public double Height { get; private set; }

        public RectangleData(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}