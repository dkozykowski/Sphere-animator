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
        private int M;

        private Point lightVersor;
        private Point VVector;

        private int heightSegments;
        private int widthSegments;

        private Color lightColor;
        private Color objectColor;

        private List<Triangle> triangles;
        private List<Point> vertices;

        private Bitmap backgroundBitmap;
        private Int32[] backgroundBits;
        private GCHandle backgroundBitsHandle;
        private int backgroundBitmapHeight;
        private int backgroundBitmapWidth;

        private Bitmap sourceImageBitmap;
        private Int32[] sourceImageBits;
        private GCHandle sourceImageBitsHandle;

        private Timer timer = null;
        private int tickCounter;

        public Form1()
        {
            lightColor = Color.FromArgb(255, 255, 255);
            objectColor = Color.BlanchedAlmond;
            backgroundBitmapHeight = backgroundBitmapWidth = 650;
            lightVersor = new Point(0, 0, 1);
            VVector = new Point(0, 0, 1);

            InitializeComponent();

            heightSegments = (int)heightSegmentsInput.Value;
            widthSegments = (int)widthSegmentsInput.Value;
            kd = (double)kdValueSlider.Value / 1000;
            ks = (double)ksValueSlider.Value / 1000;
            M = mValueSlider.Value;

            CreateBackgroundBitmap();
            RedoMesh();
            FillLightColorPickerBox();
            FillObjectColorPickerBox();
        }

        private int GetARGBColorToFill(int x, int y)
        {
            double _x, _y, _z, _radius;
            _radius = backgroundBitmapWidth / 2 + 5;
            _x = x - backgroundBitmapWidth / 2;
            _y = y - backgroundBitmapHeight / 2;
            _z = Math.Sqrt(_radius * _radius - _x * _x - _y * _y);
            Point normalVersor = new Point(_x, _y, _z);
            normalVersor.Normalise();

            Color objectColor = GetObjectColorAtPos(x, y);
            double R, G, B;
            double CosNL = Cos(normalVersor, lightVersor);
            Point RVector = 2 * CosNL * normalVersor - lightVersor;

            double VRcos = Math.Pow(Math.Max(0, Cos(VVector, RVector)), M);

            R = CosNL * kd * lightColor.R / 255 * objectColor.R / 255 + VRcos * ks * lightColor.R / 255 * objectColor.R / 255;
            G = CosNL * kd * lightColor.G / 255 * objectColor.G / 255 + VRcos * ks * lightColor.G / 255 * objectColor.G / 255;
            B = CosNL * kd * lightColor.B / 255 * objectColor.B / 255 + VRcos * ks * lightColor.B / 255 * objectColor.B / 255;

            R = Math.Min(1, Math.Max(0, R));
            G = Math.Min(1, Math.Max(0, G));
            B = Math.Min(1, Math.Max(0, B));

            return Color.FromArgb((int)Math.Round(R * 255, 0), (int)Math.Round(G * 255, 0), (int)Math.Round(B * 255, 0)).ToArgb();
        }

        private double Cos(Point a, Point b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }

        private Color GetObjectColorAtPos(int x, int y)
        {
            if (objectColorSolidRadioButton.Checked == true) return objectColor;
            else
            {
                return Color.FromArgb(sourceImageBits[x + y * backgroundBitmapWidth]);
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

            foreach (Triangle triangle in triangles)
            {
                PolygonFiller.FillPentagonWithColor(triangle.points, triangle.sortOrder, DrawPixel);
            }

            foreach (Triangle triangle in triangles)
            {
                triangle.Draw(graphics);
            }
            pictureBox1.Image = backgroundBitmap;
        }

        private void RedrawBackgroundBitmapParallel()
        {
            Graphics graphics = Graphics.FromImage(backgroundBitmap);
            graphics.Clear(Color.White);

            Parallel.ForEach(triangles, triangle =>
            {
                PolygonFiller.FillPentagonWithColor(triangle.points, triangle.sortOrder, DrawPixel);
            });

            foreach (Triangle triangle in triangles)
            {
                triangle.Draw(graphics);
            }
            pictureBox1.Image = backgroundBitmap;
        }

        private void DrawPixel(int x, int y)
        {
            if (x >= 0 && x < backgroundBitmapWidth && y >= 0 && y < backgroundBitmapHeight)
                backgroundBits[x + y * backgroundBitmapWidth] = GetARGBColorToFill(x, y);
        }

        private void CreateBackgroundBitmap()
        {
            backgroundBits = new Int32[backgroundBitmapHeight * backgroundBitmapWidth];
            backgroundBitsHandle = GCHandle.Alloc(backgroundBits, GCHandleType.Pinned);
            backgroundBitmap = new Bitmap(backgroundBitmapWidth, 
                                          backgroundBitmapHeight, 
                                          backgroundBitmapWidth * 4, 
                                          System.Drawing.Imaging.PixelFormat.Format32bppPArgb, 
                                          backgroundBitsHandle.AddrOfPinnedObject());
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
            M = mValueSlider.Value;
            Text = M.ToString();
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
            RedrawBackgroundBitmap();
        }

        private void objectColorPictureBox_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                objectColor = dialog.Color;
            }
            FillObjectColorPickerBox();
            RedrawBackgroundBitmap();
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
            SphereTriangulator.CreateMesh(ref triangles,
                                    ref vertices,
                                    widthSegments,
                                    heightSegments,
                                    backgroundBitmapWidth / 2);
            foreach (Point vertex in vertices)
            {
                vertex.x += backgroundBitmapWidth / 2;
                vertex.y += backgroundBitmapHeight / 2;
            }
            RedrawBackgroundBitmap();
        }

        private void constLightVersorButton_CheckedChanged(object sender, EventArgs e)
        {
            if (constLightVersorButton.Checked == true)
            {
                if (timer != null)
                {
                    timer.Stop();
                    timer.Dispose();
                }
                lightVersor = new Point(0, 0, 1);
                RedrawBackgroundBitmapParallel();
            }
            else
            {
                tickCounter = 0;
                timer = new Timer();
                timer.Interval = 75;
                timer.Tick += new EventHandler(UpdateLightVector);
                timer.Start();
            }
        }

        private void UpdateLightVector(Object myObject, EventArgs myEventArgs)
        {
            double MAX = 150;
            if (tickCounter == MAX) tickCounter = 0;
            double _x, _y, _z;
            _z = 0.2;
            _x = Math.Cos(tickCounter / MAX * Math.PI * 2);
            _y = Math.Sin(tickCounter / MAX * Math.PI * 2);

            lightVersor = new Point(_x, _y, _z);
            lightVersor.Normalise();

            RedrawBackgroundBitmapParallel();
            tickCounter++;
        }

        private void objectColorSolidRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (objectColorTextureRadioButton.Checked == true)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
                dialog.InitialDirectory = @"C:\";
                dialog.Title = "Please select an image file.";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Image sourceImage = new Bitmap(dialog.FileName);
                   
                    
                    sourceImageBits = new Int32[backgroundBitmapHeight * backgroundBitmapWidth];
                    sourceImageBitsHandle = GCHandle.Alloc(sourceImageBits, GCHandleType.Pinned);
                    sourceImageBitmap = new Bitmap(backgroundBitmapWidth,
                                                  backgroundBitmapHeight,
                                                  backgroundBitmapWidth * 4,
                                                  System.Drawing.Imaging.PixelFormat.Format32bppPArgb,
                                                  sourceImageBitsHandle.AddrOfPinnedObject());

                    Graphics graphics = Graphics.FromImage(sourceImageBitmap);
                    graphics.DrawImage(sourceImage, 0, 0, backgroundBitmapWidth, backgroundBitmapHeight);
                }
                else
                {
                    objectColorTextureRadioButton.Checked = false;
                    objectColorSolidRadioButton.Checked = true;
                }
            }
            RedrawBackgroundBitmap();
        }
    }
}
