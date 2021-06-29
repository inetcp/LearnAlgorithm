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

        public int Length => _length;

        public LinkListNode<T> GetElement(int index)
        {
            // 判断索引是否在当前范围内，不在范围内直接返回错误
            if (index < 0 || index > _length - 1)
                throw new Exception("index 不在范围之内");
            
            // 声明结点p
            LinkListNode<T> currentNode = _node.Next;
            int currentCount = 0;
            while (currentNode != null && currentCount < index)
            {
                currentNode = currentNode.Next;
                ++currentCount;
            }

            if (currentNode == null || currentCount > index)
                throw new Exception("元素不存在");
            
            return currentNode;
        }

        public void Insert(int index, T data)
        {
            var currentNode = GetElement(index);
            if (currentNode == null)
                throw new Exception("元素不存在");

            var newNode = new LinkListNode<T> {Data = data, Next = currentNode.Next};
            currentNode.Next = newNode;

            _length++;
        }

        public void Remove(int index)
        {
            var currentNode = GetElement(index);
            if (currentNode == null)
                throw new Exception("元素不存在");

            var nextNode = currentNode.Next;

            _length--;

        }
    }
}