using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Xml.Linq;

namespace lw7
{
    public abstract class CShape
    {
        protected int x, y, width, height;
        protected bool dedicated;

        static public int step = 5;
        protected Color color;
        public Point[] boundaryPoints = new Point[4];

        public ArrowObservers arrowObservers = new ArrowObservers();

        public int getX() => x;
        public int getY() => y;
        public CShape Clone()
        {
            return this.MemberwiseClone() as CShape;
        }
        public virtual void Dedicated() => dedicated = true;
        public virtual void unDedicated() => dedicated = false;
        public virtual bool isDedicated() => dedicated ? true : false;
        public virtual void Move(int dx, int dy, Rectangle sizePctrBx)
        {
            if (arrowObservers.isMove == true)
                return;
            if (dy < 0)
                y += !isOut("up", sizePctrBx) ? dy : -boundaryPoints[0].Y;
            if (dy > 0)
                y += !isOut("down", sizePctrBx) ? dy : (sizePctrBx.Height - boundaryPoints[1].Y);
            if (dx > 0)
                x += !isOut("right", sizePctrBx) ? dx : (sizePctrBx.Width - boundaryPoints[2].X);
            if (dx < 0)
                x += !isOut("left", sizePctrBx) ? dx : -boundaryPoints[3].X;
            setBoundaryPoints();
            arrowObservers.notify(dx, dy, sizePctrBx, boundaryPoints);
        }
        public abstract void Draw(Graphics g);
        public abstract bool isChoose(int X, int Y);
        public virtual void setBoundaryPoints() { }
        public virtual bool isOut(string way, Rectangle sizePctrBx)
        {
            switch (way)
            {
                case ("up"):
                    return boundaryPoints[0].Y - step < 0;
                case ("down"):
                    return boundaryPoints[1].Y + step > sizePctrBx.Height;
                case ("right"):
                    return boundaryPoints[2].X + step > sizePctrBx.Width;
                case ("left"):
                    return boundaryPoints[3].X - step < 0;
                default:
                    return true;
            }
        }
        public virtual void changeSize(string sign, Rectangle sizePctrBx)
        {
            switch (sign)
            {
                case "+":
                    int increase = 0;
                    if (!isOut("up", sizePctrBx) && !isOut("down", sizePctrBx) && !isOut("left", sizePctrBx) && !isOut("right", sizePctrBx))
                        increase = step;
                    else if (isOut("up", sizePctrBx))
                        increase = boundaryPoints[0].Y;
                    else if (isOut("down", sizePctrBx))
                        increase = sizePctrBx.Height - boundaryPoints[1].Y;
                    else if (isOut("right", sizePctrBx))
                        increase = sizePctrBx.Width - boundaryPoints[2].X;
                    else if (isOut("left", sizePctrBx))
                        increase = boundaryPoints[3].X;
                    width += increase; height += increase;
                    break;
                case "-":
                    if (width <= step * 2 || height <= step * 2)
                        return;
                    width -= step; height -= step;
                    break;
            }
            setBoundaryPoints();
        }
        public virtual void changeColor(Color color)
        {
            if (isDedicated())
                this.color = color;
        }
        public virtual void Load(StreamReader stream, CShapeFactory factory)
        {
            string str = stream.ReadLine();
            int[] data = new int[4];
            string tmp = "";
            int j = 0;
            for (int i = 0; i < str.Length; ++i)
                if ("0123456789".Contains(str[i]))
                    tmp += str[i];
                else
                {
                    data[j] = Convert.ToInt32(tmp);
                    tmp = "";
                    ++j;
                }
            color = Color.FromArgb(Convert.ToInt32(stream.ReadLine()));
            x = data[0]; y = data[1];
            width = data[2]; height = data[3];
            setBoundaryPoints();
        }
        public abstract void Save(StreamWriter stream);
        public abstract string figureName();
        public virtual void drawArrow(Graphics g)
        {
            arrowObservers.DrawArrow(x, y, g);
        }
    }
    public class CEllipse : CShape
    {
        public CEllipse(int x, int y, Color color, int width = 200, int heigth = 100)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = heigth;
            this.color = color;
            setBoundaryPoints();
        }
        public override void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(color), (x - width / 2), (y - height / 2), width, height); 
            if (isDedicated())
                g.DrawEllipse(new Pen(Color.Green, 2), (x - width / 2), (y - height / 2), width, height);
        }
        public override bool isChoose(int X, int Y)
        {
            long dx = (X - x), dy = (Y - y), a = height / 2, b = width / 2;
            return dx * dx * a * a +
                   dy * dy * b * b -
                   b * b * a * a <= 0;
        }
        public override void setBoundaryPoints()
        {
            boundaryPoints[0].X = x; boundaryPoints[0].Y = y - height / 2;
            boundaryPoints[1].X = x; boundaryPoints[1].Y = y + height / 2;
            boundaryPoints[2].X = x + width / 2; boundaryPoints[2].Y = y;
            boundaryPoints[3].X = x - width / 2; boundaryPoints[3].Y = y;
        }
        public override void Save(StreamWriter stream)
        {
            int[] data = new int[] { x, y, width, height };
            stream.WriteLine('E');
            for (int i = 0; i < data.Length; ++i)
            {
                stream.Write(data[i]);
                stream.Write(" ");
            }
            stream.WriteLine();
            stream.WriteLine(color.ToArgb());
        }
        public override string figureName() => "Ellipse";
    }
    public class CCircle : CEllipse
    {
        public CCircle(int x, int y, Color color, int width = 100, int heigth = 100) : base(x, y, color, width, heigth) { }
        public override void Save(StreamWriter stream)
        {
            int[] data = new int[] { x, y, width, height };
            stream.WriteLine('C');
            for (int i = 0; i < data.Length; ++i)
            {
                stream.Write(data[i]);
                stream.Write(" ");
            }
            stream.WriteLine();
            stream.WriteLine(color.ToArgb());
        }
        public override string figureName() => "Circle";
    }
    public class CRectangle : CShape
    {
        public CRectangle(int x, int y, Color color, int width = 200, int height = 100)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.color = color;
            setBoundaryPoints();
        }
        public override void Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(color), (x - width / 2), (y - height / 2), width, height);
            if (isDedicated())
                g.DrawRectangle(new Pen(Color.Green, 2), (x - width / 2), (y - height / 2), width, height);
        }
        public override bool isChoose(int X, int Y)
        {
            return X >= x - width / 2 && Y >= y - height / 2 && X <= x + width / 2 && Y <= y + height / 2; ;
        }
        public override void setBoundaryPoints()
        {
            boundaryPoints[0].X = x - width / 2; boundaryPoints[0].Y = y - height / 2;
            boundaryPoints[1].X = x + width / 2; boundaryPoints[1].Y = y + height / 2;
            boundaryPoints[2].X = x + width / 2; boundaryPoints[2].Y = y + height / 2;
            boundaryPoints[3].X = x - width / 2; boundaryPoints[3].Y = y - height / 2;
        }
        public override void Save(StreamWriter stream)
        {
            int[] data = new int[] { x, y, width, height };
            stream.WriteLine('R');
            for (int i = 0; i < data.Length; ++i)
            {
                stream.Write(data[i]);
                stream.Write(" ");
            }
            stream.WriteLine();
            stream.WriteLine(color.ToArgb());
        }
        public override string figureName() => "Rectangle";
    }
    public class CSquare : CRectangle
    {
        public CSquare(int x, int y, Color color, int width = 100, int height = 100) : base(x, y, color, width, height) { }
        public override void Save(StreamWriter stream)
        {
            int[] data = new int[] { x, y, width, height };
            stream.WriteLine('S');
            for (int i = 0; i < data.Length; ++i)
            {
                stream.Write(data[i]);
                stream.Write(" ");
            }
            stream.WriteLine();
            stream.WriteLine(color.ToArgb());
        }
        public override string figureName() => "Square";
    }
    public class CTriangle : CShape
    {
        public CTriangle(int x, int y, Color color, int width = 100, int height = 100)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.color = color;
            setBoundaryPoints();
        }
        public override void Draw(Graphics g)
        {
            g.FillPolygon(new SolidBrush(color), boundaryPoints);
            if (isDedicated())
                g.DrawPolygon(new Pen(Color.Green, 2), boundaryPoints);
        }
        public override bool isChoose(int X, int Y)
        {
            int a = (boundaryPoints[0].X - X) * (boundaryPoints[3].Y - boundaryPoints[0].Y) - (boundaryPoints[3].X - boundaryPoints[0].X) * (boundaryPoints[0].Y - Y);
            int b = (boundaryPoints[3].X - X) * (boundaryPoints[2].Y - boundaryPoints[3].Y) - (boundaryPoints[2].X - boundaryPoints[3].X) * (boundaryPoints[3].Y - Y);
            int c = (boundaryPoints[2].X - X) * (boundaryPoints[0].Y - boundaryPoints[2].Y) - (boundaryPoints[0].X - boundaryPoints[2].X) * (boundaryPoints[2].Y - Y);
            return (a >= 0 && b >= 0 && c >= 0) || (a <= 0 && b <= 0 && c <= 0);
        }
        public override void setBoundaryPoints()
        {
            boundaryPoints[0].X = x; boundaryPoints[0].Y = y - height / 2;
            boundaryPoints[1].X = x + width / 2; boundaryPoints[1].Y = y + height / 2;
            boundaryPoints[2].X = x + width / 2; boundaryPoints[2].Y = y + height / 2;
            boundaryPoints[3].X = x - width / 2; boundaryPoints[3].Y = y + height / 2;
        }
        public override void Save(StreamWriter stream)
        {
            int[] data = new int[] { x, y, width, height };
            stream.WriteLine('T');
            for (int i = 0; i < data.Length; ++i)
            {
                stream.Write(data[i]);
                stream.Write(" ");
            }
            stream.WriteLine();
            stream.WriteLine(color.ToArgb());
        }
        public override string figureName() => "Triangle";
    }
    
}