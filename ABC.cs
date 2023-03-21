using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace lw4_part2
{
    internal class ABC
    {
        private int A, B, C;
        public System.EventHandler observers;

        public void Close_Form()
        {
            Properties.Settings.Default.A = getValueA();
            Properties.Settings.Default.B = getValueB();
            Properties.Settings.Default.C = getValueC();
            Properties.Settings.Default.Save();
        }

        public void Load_Form()
        {
            setValueA(Properties.Settings.Default.A);
            setValueC(Properties.Settings.Default.C);
            setValueB(Properties.Settings.Default.B);
        }
        public int getValueA()
        {
            return A;
        }
        public int getValueB()
        {
            return B;
        }
        public int getValueC()
        {
            return C;
        }
        public void setValueA(int value)
        {
            if (value <= 100 && value >= 0)
            {
                A = value;
                C = A > C ? A : C;
                B = A > B ? A : B;
            }
            observers.Invoke(this, null);
        }
        public void setValueB(int value)
        {
            if (value <= 100 && value >= 0 &&  A <= value && value <=C)
                B = value;
            observers.Invoke(this, null);
        }
        public void setValueC(int value)
        {
            if (value <= 100 && value >= 0)
            {
                C = value;
                B = B > C ? C : B;
                A = A > C ? C : A;
            }
            observers.Invoke(this, null);
        }
    }
}
