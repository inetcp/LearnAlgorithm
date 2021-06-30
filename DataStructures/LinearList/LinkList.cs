using System;

namespace LearnAlgorithm.DataStructures.LinearList
{
    /// <summary>
    /// 单链表结点
    /// </summary>
    /// <typeparam name="T">结点类型</typeparam>
    public class LinkListNode<T>
    {
        /// <summary>
        /// 数据域
        /// </summary>
        public T Data { get; set; }
        
        /// <summary>
        /// 指针域
        /// </summary>
        public LinkListNode<T> Next { get; set; }

        public LinkListNode(T data, LinkListNode<T> next)
        {
            Data = data;
            Next = next;
        }

        public LinkListNode(T data)
        {
            Data = data;
        }

        public LinkListNode(LinkListNode<T> next)
        {
            Next = next;
        }

        public LinkListNode()
        {
            Data = default(T);
            Next = null;
        }
    }

    /// <summary>
    /// 单链表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkList<T>
    {
        /// <summary>
        /// 头结点
        /// </summary>
        public LinkListNode<T> Head { get; private set; }

        /// <summary>
        /// 链表长度
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// 最后一个结点
        /// </summary>
        public LinkListNode<T> Last
        {
            get
            {
                var currentNode = Head;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }

                return currentNode;
            }
        }

        /// <summary>
        /// 追加一个元素
        /// </summary>
        /// <param name="data"></param>
        public void Append(T data)
        {
            var newNode = new LinkListNode<T>(data);
            if (Head == null)
            {
                Head = newNode;
                return;
            }

            this.Last.Next = newNode;
        }

        public LinkListNode<T> Get(int index)
        {
            // 判断index是否在当前范围内，不在范围内直接返回null
            if (index < 0 || index > Length - 1)
            {
                return null;
            }

            // 从头结点开始遍历，记录当前遍历的index
            // 直到找到对应index的结点，返回结点
            // 找不到就返回null
            var currentNode = Head;
            int currentIndex = 0;
            while (currentNode.Next != null && currentIndex < index)
            {
                currentNode = currentNode.Next;
                currentIndex++;
            }

            if (currentIndex == index)
            {
                return currentNode;
            }

            return null;
        }

        /// <summary>
        /// 后插
        /// </summary>
        /// <param name="index"></param>
        /// <param name="data"></param>
        public void InsertAfter(int index, T data)
        {
            // 判断index是否在当前范围内，不在范围内直接返回
            if (index < 0 || index > Length - 1)
            {
                return;
            }
            
            var currentNode = Get(index);
            if (currentNode == null)
            {
                return;
            }

            var newNode = new LinkListNode<T>(data, currentNode.Next);
            currentNode.Next = newNode;

            Length++;
        }

        /// <summary>
        /// 前插
        /// </summary>
        /// <param name="index"></param>
        /// <param name="data"></param>
        public void InsertBefore(int index, T data)
        {
            // 判断index是否在当前范围内，不在范围内直接返回
            if (index < 0 || index > Length - 1)
            {
                return;
            }
            
            if (index == 0)
            {
                var newHead = new LinkListNode<T>(data, Head);
                Head = newHead;
                Length++;
                return;
            }
            
            int prevIndex = index - 1;
            var prevNode = Get(prevIndex);
            if (prevNode == null)
            {
                return;
            }

            var newNode = new LinkListNode<T>(data, prevNode.Next);
            prevNode.Next = newNode;
            Length++;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index)
        {
            if (index < 0 || index > Length - 0)
            {
                return;
            }

            if (index == 0)
            {
                Head = Head.Next;
                Length--;
                return;
            }

            var prevIndex = index - 1;
            var prevNode = Get(prevIndex);
            if (prevNode == null)
            {
                return;
            }

            prevNode.Next = prevNode.Next.Next;
            Length--;
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Clear()
        {
            Head = null;
            Length = 0;
        }
    }
}