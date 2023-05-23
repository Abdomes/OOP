using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lw7
{
    public partial class frm : Form
    {
        bool isCTRL = false;
        public static CShapeList container = new CShapeList();
        CShapeFactory factory = new CMyShapeFactory();

        Treeview treeview;

        public frm()
        {
            InitializeComponent();
            treeview = new Treeview(treeView1);

            container.addObserver(treeview);
            treeview.addObserver(container.list);
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < container.list.GetCount(); i++)
                container.list[i].Draw(e.Graphics);
            for (int i = 0; i < container.list.GetCount(); i++)
                container.list[i].drawArrow(e.Graphics);
        }
        public static CShape first = null;
        public static int dedicatedCount = 0;
        private void pctreBx_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                bool isClicked = false;

                if (!isCTRL)
                    for (int i = 0; i < container.list.GetCount(); i++)
                        container.list[i].unDedicated();

                dedicatedCount = 0;
                for (int i = 0; i < container.list.GetCount(); i++)
                    if (container.list[i].isDedicated())
                        ++dedicatedCount;

                for (int i = 0; i < container.list.GetCount(); i++)
                {
                    if (container.list[i].isChoose(e.X, e.Y))
                    {
                        if (!container.list[i].isDedicated())
                            ++dedicatedCount;
                        if (dedicatedCount == 2)
                            first = container.list[i];
                        container.list[i].Dedicated();
                        frm.container.notify();
                        isClicked = true;
                    }
                }

                if (!isClicked)
                {
                    CShape shape = null;
                    if (ellipseToolStripMenuItem.Checked)
                        shape = new CEllipse(e.X, e.Y, colorDialog1.Color);
                    else if (circleToolStripMenuItem.Checked)
                        shape = new CCircle(e.X, e.Y, colorDialog1.Color);
                    else if (rectangleToolStripMenuItem.Checked)
                        shape = new CRectangle(e.X, e.Y, colorDialog1.Color);
                    else if (squareToolStripMenuItem.Checked)
                        shape = new CSquare(e.X, e.Y, colorDialog1.Color);
                    else if (triangleToolStripMenuItem.Checked)
                        shape = new CTriangle(e.X, e.Y, colorDialog1.Color);
                    CShape cloneShape = shape.Clone();
                    container.list.PushBack(cloneShape);
                }
            }
            pctreBx.Invalidate();
        }
        private void frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
                isCTRL = true;

            if (e.KeyCode == Keys.Delete)
            {
                for (int i = 0; i < container.list.GetCount(); ++i)
                    if (container.list[i].isDedicated())
                        container.list.RemoveAt(i--);
                if (container.list.GetCount() > 0)
                    container.list[container.list.GetCount() - 1].Dedicated();
                pctreBx.Invalidate();
            }

            if (isCTRL && (e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.OemMinus))
            {
                Rectangle sizePctrBx = new Rectangle(0, 0, pctreBx.Width, pctreBx.Height);
                for (int i = 0; i < container.list.GetCount(); ++i)
                    if (container.list[i].isDedicated())
                        if (e.KeyCode == Keys.Oemplus)
                            container.list[i].changeSize("+", sizePctrBx);
                        else if (e.KeyCode == Keys.OemMinus)
                            container.list[i].changeSize("-", sizePctrBx);
                pctreBx.Invalidate();
            }

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
            {
                Rectangle sizePctrBx = new Rectangle(0, 0, pctreBx.Width, pctreBx.Height);
                for (int i = 0; i < container.list.GetCount(); ++i)
                    if (container.list[i].isDedicated())
                    {
                        switch (e.KeyCode)
                        {
                            case Keys.Up:
                                container.list[i].Move(0, -CShape.step, sizePctrBx);
                                break;
                            case Keys.Down:
                                container.list[i].Move(0, CShape.step, sizePctrBx);
                                break;
                            case Keys.Right:
                                container.list[i].Move(CShape.step, 0, sizePctrBx);
                                break;
                            case Keys.Left:
                                container.list[i].Move(-CShape.step, 0, sizePctrBx);
                                break;
                        }
                    }
                pctreBx.Invalidate();
            }
        }
        private void frm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
                isCTRL = false;
        }
        private void changeToolStrip(ToolStripMenuItem toolsStripMenuItem)
        {
            shpToolStripMenuItem.DropDownItems.OfType<ToolStripMenuItem>().ToList().ForEach(item => { item.Checked = false; });
            toolsStripMenuItem.Checked = true;
        }
        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeToolStrip(ellipseToolStripMenuItem);
        }
        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeToolStrip(circleToolStripMenuItem);
        }
        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeToolStrip(rectangleToolStripMenuItem);
        }
        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeToolStrip(squareToolStripMenuItem);
        }
        private void triangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeToolStrip(triangleToolStripMenuItem);
        }
        private void colorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            for (int i = 0; i < container.list.GetCount(); ++i)
                container.list[i].changeColor(colorDialog1.Color);
            pctreBx.Invalidate();
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < container.list.GetCount(); ++i)
                container.list.RemoveAt(i--);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader stream = new StreamReader(openFileDialog1.FileName, false);
                container.LoadShapes(stream, factory);
                stream.Close();
            }
            pctreBx.Invalidate();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter stream = new StreamWriter(openFileDialog1.FileName, false);
                stream.WriteLine(container.list.GetCount());
                for (int i = 0; i < container.list.GetCount(); ++i)
                    container.list[i].Save(stream);
                stream.Close();
            }
            pctreBx.Invalidate();
        }
        private void btnGroup_Click(object sender, EventArgs e)
        {
            CGroup shapes = new CGroup();
            for (int i = 0; i < container.list.GetCount(); ++i)
                if (container.list[i].isDedicated())
                {
                    shapes.addShape(container.list[i]);
                    container.list.RemoveAt(i--);
                }
            container.list.PushBack(shapes);
            container.list[container.list.GetCount() - 1].Dedicated();
            container.notify();
            pctreBx.Invalidate();
        }
        private void btnUnGroup_Click(object sender, EventArgs e)
        {
            int originCount = container.list.GetCount(), count = -1;
            for (int i = 0; i < container.list.GetCount(); ++i)
            {
                ++count;
                if (count >= originCount)
                    break;
                if (container.list[i] is CGroup)
                    if (container.list[i].isDedicated())
                    {
                        CGroup shapes = (CGroup)container.list[i];
                        container.list.RemoveAt(i--);
                        for (int j = 0; j < shapes._shapes.GetCount(); ++j)
                            container.list.PushBack(shapes._shapes[j]);
                    }
            }
            container.notify();
            pctreBx.Invalidate();
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                if (!isCTRL)
                    for (int i = 0; i < treeview.treeView.Nodes.Count; ++i)
                        treeview.treeView.Nodes[i].BackColor = Color.White;
                TreeNode node = e.Node;
                while (node.Parent != null)
                    node = node.Parent;
                node.BackColor = Color.Gray;
                treeview.notify();
                pctreBx.Invalidate();
            }
        }
        private void btnArrow_Click(object sender, EventArgs e)
        {
            int dedicatedCount = 0;
            for (int i = 0; i < container.list.GetCount(); ++i)
                if (container.list[i].isDedicated())
                    ++dedicatedCount;
            int j = 0;
            if (dedicatedCount == 2)
            {
                for (int i = 0; i < container.list.GetCount(); ++i)
                    if (container.list[i].isDedicated() && container.list[i] == first)
                        j = i;
                for (int i = 0; i < container.list.GetCount(); ++i)
                    if (container.list[i].isDedicated() && container.list[i] != first)
                        container.list[j].arrowObservers.addObserver(container.list[i]);
                pctreBx.Invalidate();
            }
        }

        private void btnDelArrow_Click(object sender, EventArgs e)
        {
            int dedicateCount = 0;
            for (int i = 0; i < container.list.GetCount(); ++i)
                if (container.list[i].isDedicated())
                    ++dedicateCount;
            int j = 0;
            if (dedicateCount == 2)
            {
                for (int i = 0; i < container.list.GetCount(); ++i)
                    if (container.list[i].isDedicated() && container.list[i] == first)
                        j = i;
                for (int i = 0; i < container.list.GetCount(); ++i)
                    if (container.list[i].isDedicated() && container.list[i] != first)
                        container.list[j].arrowObservers.deleteObserver(container.list[i]);
                pctreBx.Invalidate();
            }
        }
    }
}