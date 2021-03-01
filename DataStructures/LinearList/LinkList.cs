using System;

namespace LearnAlgorithm.DataStructures.LinearList
{
    public class LinkListNode<T>
    {
        public T Data { get; set; }
        
        public LinkListNode<T> Next { get; set; }
    }

    public class LinkList<T>
    {
        private LinkListNode<T> _node;
        private int _length;

        public T GetElement(int index)
        {
            if (index < 0 || index > _length - 1)
                throw new Exception("index 不在范围之内");

            int j = 0;        
            // 声明结点p
            LinkListNode<T> p = _node.Next;
            while (p != null && j < index)
            {
                p = p.Next;
                ++j;
            }

            if (p == null || j > index)
                throw new Exception("元素不存在");

            T result = p.Data;
            return result;
        }
    }
}