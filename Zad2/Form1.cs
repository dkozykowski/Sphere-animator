using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        Bitmap backgroundBitmap;

        public Form1()
        {
            lightColor = Color.FromArgb(255, 255, 255);
            objectColor = Color.BlueViolet;
            InitializeComponent();
            RedoMesh();
            FillLightColorPickerBox();
            FillObjectColorPickerBox();
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

        private void Redraw()
        {

        }

        private void ksValueSlider_ValueChanged(object sender, EventArgs e)
        {
            ks = (double)ksValueSlider.Value / 1000;
            Redraw();
        }

        private void kdValueSlider_ValueChanged(object sender, EventArgs e)
        {
            kd = (double)kdValueSlider.Value / 1000;
            Redraw();
        }
        private void mValueSlider_ValueChanged(object sender, EventArgs e)
        {
            M = (double)mValueSlider.Value / 1000;
            Redraw();
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
            Redraw();
        }

        private void heightSegmentsInput_ValueChanged(object sender, EventArgs e)
        {
            heightSegments = (int)heightSegmentsInput.Value;
            RedoMesh();
            Redraw();
        }

        private void RedoMesh()
        {
            backgroundBitmap = new Bitmap(650, 650);
            Graphics graphics = Graphics.FromImage(backgroundBitmap);
            graphics.Clear(Color.White);
            Triangulator t = new Triangulator(ref triangles,
                                              ref vertices, 
                                              widthSegments, 
                                              heightSegments, 
                                              650 / 2);

            foreach (Point vertex in vertices)
            {
                vertex.x += 650 / 2;
                vertex.y += 650 / 2;
            }
            foreach (Triangle triangle in triangles)
            {
                triangle.Draw(graphics);
            }
            pictureBox1.Image = backgroundBitmap;
        }
    }
}
