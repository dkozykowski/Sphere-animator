using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SphereAnimator
{
    public class Point
    {
        public float x, y, z;
        public Point(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public Point((int R, int G, int B) input)
        {
            x = ((float)input.R - 127) / 128;
            y = ((float)input.G - 127) / 128;
            z = ((float)input.B - 127) / 128;
        }
        public Point(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public bool Equals(Point b)
        {
            return (x == b.x && y == b.y);
        }
        public void Normalise()
        {
            float len = (float)Math.Sqrt(x * x + y * y + z * z);
            x /= len;
            y /= len;
            z /= len;
        }
        public float Len2D()
        {
            return x * x + y * y;
        }

        public static implicit operator System.Drawing.Point(Point p) => new System.Drawing.Point((int)Math.Round(p.x, 0), (int)Math.Round(p.y, 0));
        public static implicit operator (float x, float y)(Point p) => (p.x, p.y);
        public static implicit operator PointF(Point p) => new PointF((int)Math.Round(p.x, 0), (int)Math.Round(p.y, 0));

        public static Point operator -(Point a, Point b) => new Point(a.x - b.x, a.y - b.y, a.z - b.z);
        public static Point operator +(Point a, Point b) => new Point(a.x + b.x, a.y + b.y, a.z + b.z);
        public static Point operator *(Point a, float b) => new Point(a.x * b, a.y * b, a.z * b);
        public static Point operator *(float b, Point a) => a * b;
    }
}
