using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lw7
{
    public class CShapeList
    {
        public List<CShape> list = new List<CShape>();
        public List<Treeview> observers = new List<Treeview>();
        public void addObserver(Treeview subj)
        {
            observers.PushBack(subj);
        }
        public void notify()
        {
            for (int i = 0; i < observers.GetCount(); ++i)
                observers[i].onSubjectChanged(list);
        }
        public void LoadShapes(StreamReader stream, CShapeFactory factory)
        {
            int count = Convert.ToInt32(stream.ReadLine());
            char code;
            CShape shape = null;
            for (int i = 0; i < count; ++i)
            {
                code = Convert.ToChar(stream.ReadLine());
                shape = factory.createShape(code);
                if (shape != null)
                {
                    shape.Load(stream, factory);
                    list.PushBack(shape);
                }
            }
        }
    }
    public abstract class CShapeFactory
    {
        public abstract CShape createShape(char code);
    }
}
