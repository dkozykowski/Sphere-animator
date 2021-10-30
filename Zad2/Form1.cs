using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zad2
{
    public partial class Form1 : Form
    {
        private double kd;
        private double ks;
        private double M;

        private int heightSegments = 10;
        private int widthSegments = 10;

        private Color lightColor;
        private Color objectColor;

        private List<Triangle> triangles;
        private List<Point> vertices;

        private Bitmap backgroundBitmap;
        private Int32[] Bits;
        private int BackgroundBitmapHeight;
        private int BackgroundBitmapWidth;
        private GCHandle BitsHandle;

        class AETNode
        {
            public int id;
            public double y, x;
            public double m;
            public AETNode(int id, double x, double y, double m)
            {
                this.id = id;
                this.x = x;
                this.y = y;
                this.m = m;
            }
        }

        public Form1()
        {
            lightColor = Color.FromArgb(255, 255, 255);
            objectColor = Color.BlueViolet;
            BackgroundBitmapHeight = BackgroundBitmapWidth = 650;
            InitializeComponent();
            CreateBackgroundBitmap();
            RedoMesh();
            FillLightColorPickerBox();
            FillObjectColorPickerBox();
        }

        private void FillPentagonWithColor(List<Point> points, List<int> sortOrder)
        {
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
                        double dx = points[currIndex].x - points[prevIndex].x;
                        double dy = points[currIndex].y - points[prevIndex].y;

                        if (points[prevIndex].y != points[currIndex].y)
                            AET.Add(new AETNode(prevIndex, points[currIndex].x, points[prevIndex].y, dx / dy));
                    }
                    else
                    {
                        AET.RemoveAll(node => node.id == prevIndex);
                    }

                    if (points[nextIndex].y >= points[currIndex].y)
                    {
                        double dx = points[currIndex].x - points[nextIndex].x;
                        double dy = points[currIndex].y - points[nextIndex].y;

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
                        if (x >= 0 && x < BackgroundBitmapWidth && y >= 0 && y < BackgroundBitmapHeight)
                            Bits[x + y * BackgroundBitmapWidth] = Color.BlanchedAlmond.ToArgb();
                    }
                }

                foreach (AETNode node in AET) node.x += node.m;
            }
        }

        private void FillLightColorPickerBox()
        {
            Bitmap bitmap = new Bitmap(46, 32);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(lightColor);
            lightColorPictureBox.Image = bitmap;
        }

        private void FillObjectColorPickerBox()
        {
            Bitmap bitmap = new Bitmap(46, 32);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(objectColor);
            objectColorPictureBox.Image = bitmap;
        }

        private void RedrawBackgroundBitmap()
        {
            Graphics graphics = Graphics.FromImage(backgroundBitmap);
            graphics.Clear(Color.White);

            Parallel.ForEach(triangles, triangle =>
            {
                FillPentagonWithColor(triangle.points, triangle.sortOrder);
            });

            foreach (Triangle triangle in triangles)
            {
                triangle.Draw(graphics);
            }
            pictureBox1.Image = backgroundBitmap;
        }

        private void CreateBackgroundBitmap()
        {
            Bits = new Int32[BackgroundBitmapHeight * BackgroundBitmapWidth];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            backgroundBitmap = new Bitmap(BackgroundBitmapWidth, 
                                          BackgroundBitmapHeight, 
                                          BackgroundBitmapWidth * 4, 
                                          System.Drawing.Imaging.PixelFormat.Format32bppPArgb, 
                                          BitsHandle.AddrOfPinnedObject());
        }

        private void ksValueSlider_ValueChanged(object sender, EventArgs e)
        {
            ks = (double)ksValueSlider.Value / 1000;
            RedrawBackgroundBitmap();
        }

        private void kdValueSlider_ValueChanged(object sender, EventArgs e)
        {
            kd = (double)kdValueSlider.Value / 1000;
            RedrawBackgroundBitmap();
        }
        private void mValueSlider_ValueChanged(object sender, EventArgs e)
        {
            M = (double)mValueSlider.Value / 1000;
            RedrawBackgroundBitmap();
        }

        private void colorPictureBox_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                lightColor = dialog.Color;
            }
            FillLightColorPickerBox();
        }

        private void objectColorPictureBox_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                objectColor = dialog.Color;
            }
            FillObjectColorPickerBox();
        }

        private void widthSegmentsInput_ValueChanged(object sender, EventArgs e)
        {
            widthSegments = (int)widthSegmentsInput.Value;
            RedoMesh();
            RedrawBackgroundBitmap();
        }

        private void heightSegmentsInput_ValueChanged(object sender, EventArgs e)
        {
            heightSegments = (int)heightSegmentsInput.Value;
            RedoMesh();
            RedrawBackgroundBitmap();
        }

        private void RedoMesh()
        {
            Triangulator t = new Triangulator(ref triangles,
                                              ref vertices,
                                              widthSegments,
                                              heightSegments,
                                              BackgroundBitmapWidth / 2);
            foreach (Point vertex in vertices)
            {
                vertex.x += BackgroundBitmapWidth / 2;
                vertex.y += BackgroundBitmapHeight / 2;
            }
            RedrawBackgroundBitmap();
        }
    }
}
