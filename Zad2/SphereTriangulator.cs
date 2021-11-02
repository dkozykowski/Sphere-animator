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
        public List<int> sortOrder;
        public Triangle(Point a, Point b, Point c)
        {
            points = new List<Point>();
            sortOrder = new List<int>() { 0, 1, 2 };
            points.Add(a);
            points.Add(b);
            points.Add(c);
            points.Sort((a, b) => a.y == b.y ? a.x.CompareTo(b.x) : a.y.CompareTo(b.y)); // sort ascending relative to Point.y 
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
    public static class SphereTriangulator
    {
        private static readonly double phiStart = 0;
        private static readonly double phiLength = Math.PI * 2;
        private static readonly double thetaStart = 0;
        private static readonly double thetaLength = Math.PI / 2;
        public static void CreateMesh(ref List<Triangle> triangles, 
                            ref List<Point> vertices, 
                            int heightSegments, 
                            int widthSegments, 
                            int radius)
        {
            List<List<Point>> _vertices; _vertices = new List<List<Point>>();

            GenerateVertices(radius, heightSegments, widthSegments, _vertices);
            CopyVertices(ref vertices, _vertices);
            GenerateTriangles(ref triangles, heightSegments, widthSegments, _vertices);
        }
        private static void CopyVertices(ref List<Point> vertices, List<List<Point>> _vertices)
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
        private static void GenerateVertices(int radius, int heightSegments, int widthSegments, List<List<Point>> _vertices)
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
        private static void GenerateTriangles(ref List<Triangle> triangles, int heightSegments, int widthSegments, List<List<Point>> _vertices)
        {
            triangles = new List<Triangle>();
            Triangle triangle;
            for (int y = 0; y < heightSegments; y++)
            {
                for (int x = 0; x < widthSegments; x++)
                {
                    Point vertexA = _vertices[y][x + 1];
                    Point vertexB = _vertices[y][x];
                    Point vertexC = _vertices[y + 1][x];
                    Point vertexD = _vertices[y + 1][x + 1];

                    triangle = new Triangle(vertexA, vertexB, vertexD);
                    if (triangle.IsValid())
                        triangles.Add(triangle);

                    if (y != heightSegments - 1 || thetaStart + thetaLength < Math.PI)
                    {
                        triangle = new Triangle(vertexB, vertexC, vertexD);
                        if (triangle.IsValid())
                            triangles.Add(triangle);
                    }
                        
                }
            }
        }
    }
}
