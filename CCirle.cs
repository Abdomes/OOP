using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lw_part1
{
    public class CCirle
    {
        private int x, y, R = 50;
        public bool isDedicated = false;
        public CCirle(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void DrawCirle(Graphics g)
        {
            if (isDedicated)
            {
                g.FillEllipse(Brushes.Green, (x - R), (y - R), 2 * R, 2 * R);
            }
            else
            {

                g.FillEllipse(Brushes.Red, (x - R), (y - R), 2 * R, 2 * R);
            }
        }

        public bool isChoose(int X, int Y)
        {
            return Math.Pow(x - X, 2) + Math.Pow(y - Y, 2) <= (R * R);
        }
    }
}
