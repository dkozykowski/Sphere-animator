using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zad2
{
    public partial class Form1 : Form
    {
        private float kd;
        private float ks;
        private int M;
        private float K;

        private Point lightVersor;
        private Point VVector;

        private int heightSegments;
        private int widthSegments;

        private (int R, int G, int B) lightColor;
        private (int R, int G, int B) objectColor;

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

        private Bitmap normalMapBitmap;
        private Int32[] normalMapBits;
        private GCHandle normalMapBitsHandle;

        private Timer timer;
        private int tickCounter;

        private bool isSomePointBeeingMoved;
        private Point pointToMove;

        bool useSolidColor;
        bool useNormalMap;
        private readonly string DEFAULT_NORMAL_MAP_PATH = "..\\..\\..\\normal_maps\\brick_wall_harsh.png";
        private readonly string DEFAULT_BACKGROUND_PATH = "..\\..\\..\\background_images\\brick_wall.png";

        public Form1()
        {
            lightColor = (255, 255, 255);
            objectColor = (255, 235, 205);
            backgroundBitmapHeight = backgroundBitmapWidth = 650;
            lightVersor = new Point(0, 0, 1);
            VVector = new Point(0, 0, 1);
            pointToMove = null;
            isSomePointBeeingMoved = false;

            InitializeComponent();

            useSolidColor = objectColorSolidRadioButton.Checked;
            useNormalMap = useNormalMapCheckbox.Checked;
            heightSegments = (int)heightSegmentsInput.Value;
            widthSegments = (int)widthSegmentsInput.Value;
            kd = (float)kdValueSlider.Value / 1000;
            ks = (float)ksValueSlider.Value / 1000;
            K = (float)kValueSlider.Value / 100;
            M = mValueSlider.Value;

            LoadNormalMapFromPath(DEFAULT_NORMAL_MAP_PATH);
            LoadBackgroundFromPath(DEFAULT_BACKGROUND_PATH);
            CreateBackgroundBitmap();
            RedoMesh();
            FillLightColorPickerBox();
            FillObjectColorPickerBox();
            CreateTimer();
        }

        private void CreateTimer()
        {
            timer = new Timer();
            timer.Interval = 40;
            timer.Tick += new EventHandler(UpdateLightVector);
            timer.Start();
        }

        private float Pow(float a, int b)
        {
            if (b == 0) return 1;
            else if ((b & 1) == 0)
            {
                float c = Pow(a, b / 2);
                return c * c;
            }
            else return a * Pow(a, b - 1);
        }

        private int GetARGBColorToFill(int x, int y)
        {
            Point normalVersor = GetNormalVersor(x, y);

            (int R, int G, int B) objectColor = GetObjectColorAtPos(x, y);
            float R, G, B;
            float CosNL = Cos(normalVersor, lightVersor);
            Point RVector = 2 * CosNL * normalVersor - lightVersor;

            float VRcos = Pow(Math.Max(0, Cos(VVector, RVector)), M);

            R = CosNL * kd * lightColor.R / 255 * objectColor.R / 255 + VRcos * ks * lightColor.R / 255 * objectColor.R / 255;
            G = CosNL * kd * lightColor.G / 255 * objectColor.G / 255 + VRcos * ks * lightColor.G / 255 * objectColor.G / 255;
            B = CosNL * kd * lightColor.B / 255 * objectColor.B / 255 + VRcos * ks * lightColor.B / 255 * objectColor.B / 255;

            R = Math.Min(1, Math.Max(0, R));
            G = Math.Min(1, Math.Max(0, G));
            B = Math.Min(1, Math.Max(0, B));

            return RGBToInt((int)Math.Round(R * 255, 0), (int)Math.Round(G * 255, 0), (int)Math.Round(B * 255, 0));
        }

        private static int RGBToInt(int R, int G, int B)
        {
            return (255 << 24) + (R << 16) + (G << 8) + B;
        }

        private static (int, int, int) IntToRGB(int color)
        {
            int R, G, B;
            R = (color & 0xff0000) >> 16;
            G = (color & 0xff00) >> 8;
            B = (color & 0xff);
            return (R, G, B);
        }

        private int GetARGBInterpolatedColorToFill(Triangle triangle)
        {
            int R = 0, G = 0, B = 0;
            for (int i = 0; i < 3; i++)
            {
                int _x = (int)Math.Round(triangle.points[i].x, 0);
                _x = Math.Max(0, Math.Min(_x, backgroundBitmapWidth - 1));

                int _y = (int)Math.Round(triangle.points[i].y, 0);
                _y = Math.Max(0, Math.Min(_y, backgroundBitmapWidth - 1));

                int _R, _G, _B;
                (_R, _G, _B) = IntToRGB(GetARGBColorToFill(_x, _y));
                R += _R;
                G += _G;
                B += _B;
            }


            return RGBToInt(R / 3, G / 3, B / 3);
        }

        private Point GetNormalVersor(int x, int y)
        {
            float _x, _y, _z, _radius;
            _radius = backgroundBitmapWidth / 2 + 5;
            _x = x - backgroundBitmapWidth / 2;
            _y = y - backgroundBitmapHeight / 2;
            _z = (float)Math.Sqrt(_radius * _radius - _x * _x - _y * _y);
            Point normalVersor = new Point(_x, _y, _z);
            normalVersor.Normalise();

            if (useNormalMap)
            {
                Point textureVersor = new Point(IntToRGB(normalMapBits[x + y * backgroundBitmapWidth]));
                textureVersor.Normalise();
                normalVersor = K * normalVersor - (K - 1) * textureVersor;
            }
            return normalVersor;
        }

        private float Cos(Point a, Point b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }

        private (int, int, int) GetObjectColorAtPos(int x, int y)
        {
            if (useSolidColor) return objectColor;
            else
            {
                return IntToRGB(sourceImageBits[x + y * backgroundBitmapWidth]);
            }
        }

        private void FillLightColorPickerBox()
        {
            Bitmap bitmap = new Bitmap(46, 32);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.FromArgb(lightColor.R, lightColor.G, lightColor.B));
            lightColorPictureBox.Image = bitmap;
        }

        private void FillObjectColorPickerBox()
        {
            Bitmap bitmap = new Bitmap(46, 32);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.FromArgb(objectColor.R, objectColor.G, objectColor.B));
            objectColorPictureBox.Image = bitmap;
        }

        private void RedrawBackgroundBitmap(bool useParallelism = true)
        {

            Graphics graphics = Graphics.FromImage(backgroundBitmap);

            if (useParallelism)
            {
                Parallel.ForEach(triangles, triangle =>
                {
                    if (exactFillColorButton.Checked)
                        PolygonFiller.FillPentagonWithColor(triangle.points, DrawPixel);
                    else
                    {
                        int color = GetARGBInterpolatedColorToFill(triangle);
                        PolygonFiller.FillPentagonWithColor(triangle.points, DrawPixel, color);
                    }
                });
            }
            else
            {
                foreach (Triangle triangle in triangles)
                {
                    if (exactFillColorButton.Checked)
                        PolygonFiller.FillPentagonWithColor(triangle.points, DrawPixel);
                    else
                    {
                        int color = GetARGBInterpolatedColorToFill(triangle);
                        PolygonFiller.FillPentagonWithColor(triangle.points, DrawPixel, color);
                    }
                }
            }

            foreach (Triangle triangle in triangles)
            {
                triangle.Draw(graphics);
            }
            pictureBox1.Image = backgroundBitmap;
        }

        private void DrawPixel(int x, int y, int color = -1)
        {
            if (x >= 0 && x < backgroundBitmapWidth && y >= 0 && y < backgroundBitmapHeight)
            {
                if (color == -1) color = GetARGBColorToFill(x, y);

                backgroundBits[x + y * backgroundBitmapWidth] = color;
            }
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

        private void KsValueSlider_ValueChanged(object sender, EventArgs e)
        {
            ks = (float)ksValueSlider.Value / 1000;
            RedrawBackgroundBitmap(useParallelism: false);
        }

        private void KdValueSlider_ValueChanged(object sender, EventArgs e)
        {
            kd = (float)kdValueSlider.Value / 1000;
            RedrawBackgroundBitmap(useParallelism: false);
        }
        private void MValueSlider_ValueChanged(object sender, EventArgs e)
        {
            M = mValueSlider.Value;
            RedrawBackgroundBitmap(useParallelism: false);
        }

        private void KValueSlider_ValueChanged(object sender, EventArgs e)
        {
            K = (float)kValueSlider.Value / 100;
            RedrawBackgroundBitmap(useParallelism: false);
        }

        private void ColorPictureBox_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                lightColor = (dialog.Color.R, dialog.Color.G, dialog.Color.B);
            }
            FillLightColorPickerBox();
            RedrawBackgroundBitmap(useParallelism: false);
        }

        private void ObjectColorPictureBox_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                objectColor = (dialog.Color.R, dialog.Color.G, dialog.Color.B);
            }
            FillObjectColorPickerBox();
            RedrawBackgroundBitmap(useParallelism: false);
        }

        private void WidthSegmentsInput_ValueChanged(object sender, EventArgs e)
        {
            widthSegments = (int)widthSegmentsInput.Value;
            RedoMesh();
        }

        private void HeightSegmentsInput_ValueChanged(object sender, EventArgs e)
        {
            heightSegments = (int)heightSegmentsInput.Value;
            RedoMesh();
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

        private void ConstLightVersorButton_CheckedChanged(object sender, EventArgs e)
        {
            if (constLightVersorButton.Checked == true)
            {
                if (timer != null)
                {
                    timer.Stop();
                    timer.Dispose();
                }
                lightVersor = new Point(0, 0, 1);
                RedrawBackgroundBitmap(useParallelism: false);
            }
            else
            {
                tickCounter = 0;
                timer = new Timer();
                timer.Interval = 20;
                timer.Tick += new EventHandler(UpdateLightVector);
                timer.Start();
            }
        }

        private void UpdateLightVector(Object myObject, EventArgs myEventArgs)
        {
            float MAX = 240;
            if (tickCounter == MAX) tickCounter = 0;
            float _x, _y, _z;
            _z = 0.2F;
            _x = (float)Math.Cos(tickCounter / MAX * Math.PI * 2);
            _y = (float)Math.Sin(tickCounter / MAX * Math.PI * 2);

            lightVersor = new Point(_x, _y, _z);
            lightVersor.Normalise();

            RedrawBackgroundBitmap();
            tickCounter++;
        }

        private void ObjectColorSolidRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            useSolidColor = objectColorSolidRadioButton.Checked;
            RedrawBackgroundBitmap(useParallelism: false);
        }

        private void LoadBackgroundFromPath(string path)
        {
            Image sourceImage = new Bitmap(path);


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


        private void LoadNormalMappingButton_Click(object sender, EventArgs e)
        {
            StopTimer();
            WasNormalMappingChoosen();
            ContinueTimer();
            RedrawBackgroundBitmap(useParallelism: false);
        }
        private void UseNormalMapCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (useNormalMapCheckbox.Checked)
            {
                if (normalMapBitmap == null)
                {
                    if (!WasNormalMappingChoosen())
                    {
                        useNormalMapCheckbox.Checked = false;
                        useNormalMap = false;
                    }
                    else useNormalMap = true;
                }
                else useNormalMap = true;
            }
            else useNormalMap = false;
            RedrawBackgroundBitmap(useParallelism: false);
        }

        private bool WasNormalMappingChoosen()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            dialog.InitialDirectory = Path.GetFullPath("..\\..\\..\\normal_maps");
            dialog.Title = "Please select a normal map file.";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadNormalMapFromPath(dialog.FileName);
                return true;
            }
            else return false;
        }

        private void LoadNormalMapFromPath(string path)
        {
            Image normalMap = new Bitmap(path);


            normalMapBits = new Int32[backgroundBitmapHeight * backgroundBitmapWidth];
            normalMapBitsHandle = GCHandle.Alloc(normalMapBits, GCHandleType.Pinned);
            normalMapBitmap = new Bitmap(backgroundBitmapWidth,
                                          backgroundBitmapHeight,
                                          backgroundBitmapWidth * 4,
                                          System.Drawing.Imaging.PixelFormat.Format32bppPArgb,
                                          normalMapBitsHandle.AddrOfPinnedObject());

            Graphics graphics = Graphics.FromImage(normalMapBitmap);
            graphics.DrawImage(normalMap, 0, 0, backgroundBitmapWidth, backgroundBitmapHeight);
        }

        private void StopTimer()
        {
            if (timer != null) timer.Stop();
        }
        private void ContinueTimer()
        {
            if (timer != null && animatedLightVersorButton.Checked) timer.Start();
        }

        private void ExactFillColorButton_CheckedChanged(object sender, EventArgs e)
        {
            RedrawBackgroundBitmap(useParallelism: false);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Point mousePos = new Point(e.X, e.Y, 0);
            foreach(Triangle triangle in triangles)
            {
                foreach(Point point in triangle.points)
                {
                    if ((point - mousePos).Len2D() < 25)
                    {
                        pointToMove = point;
                        isSomePointBeeingMoved = true;
                        return;
                    }
                }
            }
        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isSomePointBeeingMoved || pointToMove == null) return;
            pointToMove.x = e.X;
            pointToMove.y = e.Y;
            
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isSomePointBeeingMoved)
            {
                isSomePointBeeingMoved = false;
                pointToMove = null;
            }
            else return;
            RedrawBackgroundBitmap(useParallelism: false);
        }

        private void loadTextureButton_Click(object sender, EventArgs e)
        {
            StopTimer();
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            dialog.InitialDirectory = Path.GetFullPath("..\\..\\..\\background_images");
            dialog.Title = "Please select an image file.";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadBackgroundFromPath(dialog.FileName);
            }
            ContinueTimer();
        }
    }
}
