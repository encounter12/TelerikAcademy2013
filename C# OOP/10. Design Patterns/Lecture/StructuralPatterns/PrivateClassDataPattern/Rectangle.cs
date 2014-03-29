namespace PrivateClassDataPattern
{
    public class Rectangle
    {
        private RectangleData rectangleData;

        public Rectangle(double width, double height)
        {
            rectangleData = new RectangleData(width, height);
        }

        public double Area()
        {
            return this.rectangleData.Width * this.rectangleData.Height;
        }
    }
}