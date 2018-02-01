using System;
using System.CodeDom;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace MyPhotoshop
{
    public struct Pixel
    {
        public Pixel(double r, double g, double b)
        {
            _r = _g = _b = 0;
            this.R = r;
            this.G = g;
            this.B = b;
        }

        private static double Check(double value)
        {
            if (value < 0 || value > 1) throw new ArgumentException();
            return value;
        }

        internal static double Trim(double value)
        {
            if (value > 1) return value = 1;
            if (value < 0) return value = 0;
            return value;
        }

        private double _r;

        public double R
        {
            get => _r;
            set => _r = Check(value);
        }

        private double _g;

        public double G
        {
            get => _g;
            set => _g = Check(value);
        }

        private double _b;

        public double B
        {
            get => _b;
            set => _b = Check(value);
        }

        public static Pixel operator *(Pixel pixel, double value)
        {
            return new Pixel(
                Pixel.Trim(pixel.R * value),
                Pixel.Trim(pixel.G * value),
                Pixel.Trim(pixel.B * value)
            );
        }
        
        public static Pixel operator *(double value, Pixel pixel)
        {
            return new Pixel(
                Pixel.Trim(pixel.R * value),
                Pixel.Trim(pixel.G * value),
                Pixel.Trim(pixel.B * value)
            );
        }
    }
}