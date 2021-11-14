using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad2
{
    public static class PolygonFiller
    {
        class AETNode
        {
            public int id;
            public float y, x;
            public float m;
            public AETNode(int id, float x, float y, float m)
            {
                this.id = id;
                this.x = x;
                this.y = y;
                this.m = m;
            }
        }
        public static void FillPentagonWithColor(List<Point> points,
                                                 Action<int, int, int> FillPixel, 
                                                 int color = -1)
        {
            List<int> sortOrder = Enumerable.Range(0, points.Count).ToList();

            // sort ascending relative to Point.y
            sortOrder.Sort((a, b) => points[a].y == points[b].y ? points[a].x.CompareTo(points[b].x) : points[a].y.CompareTo(points[b].y));  
            int n = points.Count;
            int index = 0;

            List<AETNode> AET = new List<AETNode>();
            int maxY = (int)Math.Round(points[sortOrder[n - 1]].y, 0);
            for (int y = (int)Math.Round(points[sortOrder[0]].y, 0); y <= maxY; y++)
            {
                while (index < n && y - 1 == (int)Math.Round(points[sortOrder[index]].y, 0))
                {
                    int prevIndex = sortOrder[index] - 1;
                    int currIndex = sortOrder[index];
                    int nextIndex = sortOrder[index] + 1;
                    if (prevIndex == -1) prevIndex = n - 1;
                    if (nextIndex == n) nextIndex = 0;

                    if (points[prevIndex].y >= points[currIndex].y)
                    {
                        float dx = points[currIndex].x - points[prevIndex].x;
                        float dy = points[currIndex].y - points[prevIndex].y;

                        if (points[prevIndex].y != points[currIndex].y)
                            AET.Add(new AETNode(prevIndex, points[currIndex].x, points[prevIndex].y, dx / dy));
                    }
                    else
                    {
                        AET.RemoveAll(node => node.id == prevIndex);
                    }

                    if (points[nextIndex].y >= points[currIndex].y)
                    {
                        float dx = points[currIndex].x - points[nextIndex].x;
                        float dy = points[currIndex].y - points[nextIndex].y;

                        if (points[nextIndex].y != points[currIndex].y)
                            AET.Add(new AETNode(currIndex, points[currIndex].x, points[nextIndex].y, dx / dy));
                    }
                    else
                    {
                        AET.RemoveAll(node => node.id == currIndex);
                    }

                    index++;
                }

                AET.Sort((a, b) => a.x.CompareTo(b.x));
                for (int i = 0; i < AET.Count; i += 2)
                {
                    int x = (int)Math.Round(AET[i].x, 0);
                    int max = (int)Math.Round(AET[i + 1].x, 0);
                    for (x = Math.Max(x, 0); x <= max; x++)
                    {
                        FillPixel(x, y, color);
                    }
                }

                foreach (AETNode node in AET) node.x += node.m;
            }
        }
    }
}
