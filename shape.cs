using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp
{
    public abstract class Shape
    {
        public Pen Pen { get; set; }
        public abstract void Draw(Graphics graphics);
    }

    public class LineShape : Shape
    {
        public int x, y;
        public int currentX, currentY;

        public LineShape(int currentX, int currentY,int x, int y)
        {
            this.currentX = currentX;
            this.currentY = currentY;
            this.x = x;
            this.y = y;
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawLine(Pens.Black, currentX, currentY, x, y);
        }
    }


    public class CircleShape : Shape
    {
        public int x, y, radius;

        public CircleShape(int x, int y, int radius)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawEllipse(Pens.Black, x - radius, y - radius, radius * 2, radius * 2);
        }
    }

    public class RectangleShape : Shape
    {
        public int width;
        public int height;
        public int x, y;

        public RectangleShape(int x, int y, int width, int height, Pen pen)
        {
            this.width = width;
            this.height = height;
            this.x = x;
            this.y = y;
        }

        public override void Draw(Graphics g)
        {
            g.DrawRectangle(Pens.Black, x, y, width, height);
        }
    }

}
