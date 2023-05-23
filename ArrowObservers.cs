using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lw7
{
    public class ArrowObservers
    {
        public bool isMove = false;
        public List<CShape> observer = new List<CShape>();
        public virtual void addObserver(CShape subj)
        {
            for (int i = 0; i < observer.GetCount(); ++i)
                if (observer[i] == subj)
                    return;
            observer.PushBack(subj);
        }
        public virtual void deleteObserver(CShape shape)
        {
            for (int i = 0; i < observer.GetCount(); ++i)
                if (observer[i] == shape)
                {
                    observer.RemoveAt(i);
                    break;
                }
        }
        public virtual void notify(int dx, int dy, Rectangle sizePctrBx, Point[] boundaryPoints)
        {
            isMove = true;
            if ((dy < 0 && boundaryPoints[0].Y > 4) || (dy > 0 && boundaryPoints[1].Y < sizePctrBx.Height - 3) ||
                (dx > 0 && boundaryPoints[2].X < sizePctrBx.Width - 3) || (dx < 0 && boundaryPoints[3].X > 4))
                for (int i = 0; i < observer.GetCount(); ++i)
                    observer[i].Move(dx, dy, sizePctrBx);
            isMove = false;
        }
        public virtual void DrawArrow(int X, int Y, Graphics g)
        {
            Pen pen = new Pen(Color.Red, 3);
            pen.CustomEndCap = new AdjustableArrowCap(6, 6);
            for (int i = 0; i < observer.GetCount(); ++i)
                g.DrawLine(pen, X, Y, observer[i].getX(), observer[i].getY());
        }
    }
}
