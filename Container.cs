using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lw7
{
    public class Node<T>
    {
        public T data;
        public Node<T> pNext;

        public Node(T data, Node<T> pNext = null)
        {
            this.data = data;
            this.pNext = pNext;
        }
    }

    public class List<T>
    {
        private Node<T> root;
        private int count;

        public List()
        {
            count = 0;
            root = null;
        }
        public void PushBack(T data)
        {
            if (root == null)
                root = new Node<T>(data);
            else
            {
                Node<T> tmp = root;
                while (tmp.pNext != null)
                    tmp = tmp.pNext;
                tmp.pNext = new Node<T>(data);
            }
            ++count;
            frm.container.notify();
        }
        public void PushFront(T data)
        {
            if (root == null)
                root = new Node<T>(data);
            else
            {
                Node<T> tmp = new Node<T>(data);
                tmp.pNext = root;
                root = tmp;
            }
            ++count;
            frm.container.notify();
        }
        public void PopBack()
        {
            RemoveAt(count - 1);
            frm.container.notify();
        }
        public void PopFront()
        {
            Node<T> tmp = root;
            root = root.pNext;
            tmp = null;
            --count;
            frm.container.notify();
        }
        public void InsertAt(T data, int index)
        {
            if (index == 0)
                PushFront(data);
            else
            {
                Node<T> tmp = root;
                for (int i = 0; i < index - 1; ++i)
                    tmp = tmp.pNext;
                Node<T> newNode = new Node<T>(data);
                newNode.pNext = tmp.pNext;
                tmp.pNext = newNode;
                ++count;
            }
            frm.container.notify();
        }
        public void RemoveAt(int index)
        {
            if (index == 0)
                PopFront();
            else
            {
                Node<T> tmp = root;
                for (int i = 0; i < index - 1; ++i)
                    tmp = tmp.pNext;
                Node<T> deleteNode = tmp.pNext;
                tmp.pNext = tmp.pNext.pNext;
                deleteNode = null;
                --count;
            }
            frm.container.notify();
        }
        public void Clear()
        {
            while (count != 0)
                PopFront();
        }
        public T this[int index]
        {
            get
            {
                int tmpCount = 0;
                Node<T> tmp = root;
                while (tmp != null)
                {
                    if (tmpCount == index)
                        return tmp.data;
                    tmp = tmp.pNext;
                    ++tmpCount;
                }
                return default(T);
            }
            set
            {
                int tmpCount = 0;
                Node<T> tmp = root;
                while (tmp != null)
                {
                    if (tmpCount == index)
                        tmp.data = value;
                    tmp = tmp.pNext;
                    ++tmpCount;
                }
            }
        }
        public int GetCount()
        {
            return count;
        }
        public void onSubjectChanged(Treeview subj)
        {
            for (int i = 0; i < frm.container.list.GetCount(); ++i)
            {
                frm.container.list[i].unDedicated();
                frm.dedicatedCount = 0;
            }
            for (int i = 0; i < frm.container.list.GetCount(); ++i)
            {
                if (subj.treeView.Nodes[i].BackColor == Color.Gray)
                {
                    frm.container.list[i].Dedicated();
                    ++frm.dedicatedCount;
                    if (frm.dedicatedCount == 2)
                        frm.first = frm.container.list[i];
                }
            }
        }
    }
}
