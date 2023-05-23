using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lw7
{
    internal class CGroup : CShape
    {
        public List<CShape> _shapes;
        public CGroup() => _shapes = new List<CShape>();
        public void addShape(CShape shape) {_shapes.PushBack(shape); setBoundaryPoints(); }
        public override void Move(int dx, int dy, Rectangle sizePctrBx)
        {
            if (arrowObservers.isMove == true)
                return;
            if (dy < 0 && !isOut("up", sizePctrBx) || dy > 0 && !isOut("down", sizePctrBx) ||
                dx > 0 && !isOut("right", sizePctrBx) || dx < 0 && !isOut("left", sizePctrBx)) {
                for (int i = 0; i < _shapes.GetCount(); ++i)
                    _shapes[i].Move(dx, dy, sizePctrBx);
                arrowObservers.notify(dx, dy, sizePctrBx, boundaryPoints);
                setBoundaryPoints();
            }
        }
        public override void setBoundaryPoints()
        {
            for (int i = 0; i < _shapes.GetCount(); ++i)
                _shapes[i].setBoundaryPoints();
            int minY, minX, maxY, maxX;
            minY = minX = 9999999; maxY = maxX = -1;
            for (int i = 0; i < _shapes.GetCount(); ++i)
            {
                minY = Math.Min(minY, _shapes[i].boundaryPoints[0].Y);
                minX = Math.Min(minX, _shapes[i].boundaryPoints[3].X);
                maxY = Math.Max(maxY, _shapes[i].boundaryPoints[1].Y);
                maxX = Math.Max(maxX, _shapes[i].boundaryPoints[2].X);
            }
            boundaryPoints[0].X = 0; boundaryPoints[0].Y = minY;
            boundaryPoints[1].X = 0; boundaryPoints[1].Y = maxY;
            boundaryPoints[2].X = maxX; boundaryPoints[2].Y = 0;
            boundaryPoints[3].X = minX; boundaryPoints[3].Y = 0;
            x = minX + (maxX - minX) / 2; y =  minY + (maxY - minY) / 2;
        }
        public override void Dedicated()
        {
            for (int i = 0; i < _shapes.GetCount(); ++i)
                _shapes[i].Dedicated();
            dedicated = true;
        }
        public override void unDedicated()
        {
            for (int i = 0; i < _shapes.GetCount(); ++i)
                _shapes[i].unDedicated();
            dedicated = false;
        }
        public override bool isDedicated() => dedicated ? true : false;
        public override void Draw(Graphics g)
        {
            for (int i = 0; i < _shapes.GetCount(); ++i)
                _shapes[i].Draw(g);
        }
        public override bool isChoose(int X, int Y)
        {
            for (int i = 0; i < _shapes.GetCount(); ++i)
                if (_shapes[i].isChoose(X, Y))
                    return true;
            return false;
        }
        public override bool isOut(string way, Rectangle sizePctrBx)
        {
            for (int i = 0; i < _shapes.GetCount(); ++i)
                if (_shapes[i].isOut(way, sizePctrBx))
                    return true;
            return false;
        }
        public override void changeSize(string sign, Rectangle sizePctrBx)
        {
            switch (sign)
            {
                case "+":
                    if (!isOut("up", sizePctrBx) && !isOut("down", sizePctrBx) && !isOut("left", sizePctrBx) && !isOut("right", sizePctrBx))
                        for (int i = 0; i < _shapes.GetCount(); ++i)
                            _shapes[i].changeSize(sign, sizePctrBx);
                    break;
                case "-":
                    for (int i = 0; i < _shapes.GetCount(); ++i)
                        _shapes[i].changeSize(sign, sizePctrBx);
                    break;
            }
            setBoundaryPoints();
        }
        public override void changeColor(Color color)
        {
            for (int i = 0; i < _shapes.GetCount(); ++i)
                _shapes[i].changeColor(color);
        }
        public override void Save(StreamWriter stream)
        {
            stream.WriteLine('G');
            stream.WriteLine(_shapes.GetCount());
            for (int i = 0; i < _shapes.GetCount(); ++i)
                _shapes[i].Save(stream);
        }
        public override void Load(StreamReader stream, CShapeFactory factory)
        {
            int count = Convert.ToInt32(stream.ReadLine());
            char code;
            CShape shape;
            for (int i = 0; i < count; ++i)
            {
                code = Convert.ToChar(stream.ReadLine());
                shape = factory.createShape(code);
                _shapes.PushBack(shape);
                if (shape is CShape)
                    shape.Load(stream, factory);
            }
        }
        public override string figureName() => "Group";
    }
}
