using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static lw7.CShapeList;

namespace lw7
{
    public class CMyShapeFactory : CShapeFactory
    {
        public override CShape createShape(char code)
        {
            CShape shape = null;
            switch (code)
            {
                case 'E':
                    shape = new CEllipse(0, 0, Color.Black);
                    break;
                case 'C':
                    shape = new CCircle(0, 0, Color.Black);
                    break;
                case 'R':
                    shape = new CRectangle(0, 0, Color.Black);
                    break;
                case 'S':
                    shape = new CSquare(0, 0, Color.Black);
                    break;
                case 'T':
                    shape = new CTriangle(0, 0, Color.Black);
                    break;
                case 'G':
                    shape = new CGroup();
                    break;
            }
            return shape;
        }
    }
}
