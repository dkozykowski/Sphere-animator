using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad2
{
    public static class SphereTriangulator
    {
        private static readonly float phiStart = 0;
        private static readonly float phiLength = (float)Math.PI;
        private static readonly float thetaStart = 0;
        private static readonly float thetaLength = (float)Math.PI;
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
                float v = (float)y / (float)heightSegments;
                for (int x = 0; x <= widthSegments; x++)
                {
                    float u = (float)x / (float)widthSegments;
                    float px = (float)(-radius * Math.Cos(phiStart + u * phiLength) * Math.Sin(thetaStart + v * thetaLength));
                    float py = (float)(radius * Math.Cos(thetaStart + v * thetaLength));
                    float pz = (float)(radius * Math.Sin(phiStart + u * phiLength) * Math.Sin(thetaStart + v * thetaLength));
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
