using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : Shape
    {
        public double Width { get; private set; }
        public double Height { get; private set; }
        public Rectangle(double width,double height)
        {
            Width = width;
            Height = height;
        }
        public override double CalculateArea()
        {
            return Width * Height;
        }

        public override double CalculatePerimeter()
        {
            return (Width + Height) * 2;
        }
        


    }
}
