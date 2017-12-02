using System;

namespace MathForms.Models
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        private double Length
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                this.length = value;
            }
        }

        private double Width
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        private double Height
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        public double GetVolume()
        {
            return this.length * this.width * this.height;
        }

        public double GetSurface()
        {
            return 2 * width * height + 2 * length * height;
        }

        public double GetArea()
        {
            return 2 * length * width + 2 * length * height + 2 * width * height;
        }
    }
}
