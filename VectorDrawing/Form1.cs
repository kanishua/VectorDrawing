using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VectorDrawing
{
    public partial class Form1 : Form
    {
        private bool _isCliked;

        public Form1()
        {
            InitializeComponent();
            SetSize();
        }
        private class ArrayPoints
        {
            private int index = 0;
            private Point[] points;
            public  ArrayPoints(int size)
            {
                points = new Point[size];
            }
            public void SetPoint(int x, int y)
            {
                if(index>=points.Length)
                {
                    index = 0;
                }
                points[index] = new Point(x, y);
                index++;
            }
            
            public void Reset()
            {
                index = 0;
            }

            public int GetCountPoints()
            {
                return index;
            }

            public Point[] GetPoints()
            {
                return points;
            }

        }       

        private ArrayPoints arrayPoints = new ArrayPoints(2);
        Bitmap map = new Bitmap(800, 500);
        Graphics graphics;
        Pen pen = new Pen(Color.Black, 3f);

        private void SetSize()
        {
            Rectangle rectangle = Screen.PrimaryScreen.Bounds;
            map = new Bitmap(rectangle.Width, rectangle.Height);
            graphics = Graphics.FromImage(map);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }
         private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            if (openDllDialog.ShowDialog() == DialogResult.OK)
            {
                //load file
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _isCliked = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _isCliked = false;
            arrayPoints.Reset();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(!_isCliked)
            {
                return;
            }
            arrayPoints.SetPoint(e.X, e.Y);
            if (arrayPoints.GetCountPoints() >= 2)
            {
                graphics.DrawLines(pen, arrayPoints.GetPoints());
                pictureBox1.Image = map;
                arrayPoints.SetPoint(e.X, e.Y);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pen.Color = ((Button)sender).BackColor;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pen.Color = colorDialog1.Color;
                ((Button)sender).BackColor = colorDialog1.Color;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
    }
}