using System.Collections.Generic;
using System.Linq.Expressions;

namespace lw_part1
{
    public partial class frm : Form
    {
        bool isCTRL = false;
        List<CCirle> list = new List<CCirle>();
        
        public frm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].DrawCirle(e.Graphics);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!isCTRL)
                {
                    bool isClicked = false;
                    if (ctrlChckBx.Checked == false)
                    {
                        for (int i = 0; i < list.Count; i++)
                            list[i].isDedicated = false;
                    }
                    for (int i = 0; i < list.Count; i++)
                        list[i].isDedicated = false;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].isChoose(e.X, e.Y))
                        {
                            list[i].isDedicated = true;
                            isClicked = true;
                            if (!CrossChckBx.Checked)
                                break;
                        }
                    }
                    if (!isClicked)
                    {
                        list.Add(new CCirle(e.X, e.Y));
                        list[list.Count - 1].isDedicated = true;
                    }
                }
                else 
                {
                    if (ctrlChckBx.Checked == false)
                    {
                        for (int i = 0; i < list.Count; i++)
                            list[i].isDedicated = false;
                    }
                    bool isClicked = false;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].isChoose(e.X, e.Y))
                        {
                            list[i].isDedicated = true;
                            isClicked = true;
                            if (!CrossChckBx.Checked)
                                break;
                        }
                    }
                    if (!isClicked)
                    {
                        list.Add(new CCirle(e.X, e.Y));
                    }
                }
            }
            panel1.Invalidate();
        }

        private void frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                isCTRL = true;
            }
            if (e.KeyCode == Keys.Delete)
            {
                for (int i = 0; i < list.Count; ++i)
                {
                    if (list[i].isDedicated)
                    {
                        list.RemoveAt(i--);
                    }
                }
                if (list.Count > 0)
                    list[list.Count - 1].isDedicated = true;
                panel1.Invalidate();
            }
        }

        private void frm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                isCTRL = false;
            }
        }
    }
}
