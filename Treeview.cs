using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lw7
{
    public class Treeview
    {
        public TreeView treeView;
        public List<List<CShape>> observers = new List<List<CShape>>();
        public Treeview(TreeView treeView)
        {
            this.treeView = treeView;
        }
        public void addObserver(List<CShape> o)
        {
            observers.PushBack(o);
        }
        public void notify()
        {
            for (int i = 0; i < observers.GetCount(); ++i)
                observers[i].onSubjectChanged(this);
        }

        public void onSubjectChanged(List<CShape> subj)
        {
            treeView.Nodes.Clear();
            for (int i = 0; i < subj.GetCount(); ++i)
            {
                TreeNode node = new TreeNode(subj[i].figureName());
                if (subj[i].isDedicated())
                {
                    node.BackColor = Color.Gray;
                    node.Expand();
                }
                if (subj[i] is CGroup)
                    processNode(node, subj[i]);
                treeView.Nodes.Add(node);
            }
        }

        public void processNode(TreeNode tr, CShape shape)
        {
            if (shape is CGroup)
            {
                List<CShape> tmp = (shape as CGroup)._shapes;
                for (int i = 0; i < tmp.GetCount(); ++i)
                {
                    TreeNode node = new TreeNode(tmp[i].figureName());
                    processNode(node, tmp[i]);
                    tr.Nodes.Add(node);
                }
            }
        }
    }
}
