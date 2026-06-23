namespace Shapes
{
    public class Rectangle : Shape
    {


        public double Height { get; private set; }
        public double Width { get; private set; }

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (Width + Height);
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }
    }
}
