using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad2
{
    public class Point
    {
        public int x, y, z;
        public Point(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public Point(double x, double y, double z)
        {
            this.x = (int)Math.Round(x, 0);
            this.y = (int)Math.Round(y, 0);
            this.z = (int)Math.Round(z, 0);
        }
        public static implicit operator System.Drawing.Point(Point p) => new System.Drawing.Point(p.x, p.y);
    }
    public class Triangle
    {
        public Point a, b, c;
        public Triangle(Point a, Point b, Point c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public void Draw(Graphics graphics)
        {
            Pen pen = new Pen(Brushes.Black);
            graphics.DrawLine(pen, a, b);
            graphics.DrawLine(pen, a, c);
            graphics.DrawLine(pen, b, c);
        }
    }
    public class Triangulator
    {
        private List<List<Point>> _vertices;
        private readonly double phiStart = 0;
        private readonly double phiLength = Math.PI * 2;
        private readonly double thetaStart = 0;
        private readonly double thetaLength = Math.PI / 2;
        public Triangulator(ref List<Triangle> triangles, 
                            ref List<Point> vertices, 
                            int heightSegments, 
                            int widthSegments, 
                            int radius)
        {
            _vertices = new List<List<Point>>();

            GenerateVertices(radius, heightSegments, widthSegments);
            CopyVertices(ref vertices);
            GenerateTriangles(ref triangles, heightSegments, widthSegments);
        }
        private void CopyVertices(ref List<Point> vertices)
        {
            vertices = new List<Point>();
            foreach (List<Point> verticesList in _vertices)
            {
                foreach (Point vertex in verticesList)
                {
                    vertices.Add(vertex);
                }
            }
        }
        private void GenerateVertices(int radius, int heightSegments, int widthSegments)
        {
            for (int y = 0; y <= heightSegments; y++)
            {
                List<Point> verticesRow = new List<Point>();
                double v = (double)y / (double)heightSegments;
                for (int x = 0; x <= widthSegments; x++)
                {
                    double u = (double)x / (double)widthSegments;
                    double px = (double)(-radius * Math.Cos(phiStart + u * phiLength) * Math.Sin(thetaStart + v * thetaLength));
                    double pz = (double)(radius * Math.Cos(thetaStart + v * thetaLength));
                    double py = (double)(radius * Math.Sin(phiStart + u * phiLength) * Math.Sin(thetaStart + v * thetaLength));
                    verticesRow.Add(new Point(px, py, pz));
                }
                _vertices.Add(verticesRow);
            }
        }
        private void GenerateTriangles(ref List<Triangle> triangles, int heightSegments, int widthSegments)
        {
            triangles = new List<Triangle>();
            for (int y = 0; y < heightSegments; y++)
            {
                for (int x = 0; x < widthSegments; x++)
                {
                    Point vertexA = _vertices[y][x + 1];
                    Point vertexB = _vertices[y][x];
                    Point vertexC = _vertices[y + 1][x];
                    Point vertexD = _vertices[y + 1][x + 1];

                    triangles.Add(new Triangle(vertexA, vertexB, vertexD));

                    if (y != heightSegments - 1 || thetaStart + thetaLength < Math.PI)
                        triangles.Add(new Triangle(vertexB, vertexC, vertexD));
                }
            }
        }
    }
}
