using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad2
{
    public class Triangle
    {
        public List<Point> points;
        public Triangle(Point a, Point b, Point c)
        {
            points = new List<Point>();
            points.Add(a);
            points.Add(b);
            points.Add(c);
        }
        public bool IsValid()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int o = i + 1; o < 3; o++)
                {
                    if (points[i].Equals(points[o])) return false;
                }
            }
            return true;
        }
        public void Draw(Graphics graphics)
        {
            Pen pen = new Pen(Brushes.Black);
            graphics.DrawLine(pen, points[0], points[1]);
            graphics.DrawLine(pen, points[0], points[2]);
            graphics.DrawLine(pen, points[1], points[2]);
        }
    }
}
