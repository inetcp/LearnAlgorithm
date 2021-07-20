using System;

namespace LearnAlgorithm.DataStructures.LinearList.Link
{
    /// <summary>
    /// 循环单链表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CircularLinkList<T>
    {
        /// <summary>
        /// 尾结点
        /// </summary>
        public LinkListNode<T> Rear { get; private set; }

        /// <summary>
        /// 链表长度
        /// </summary>
        public int Length { get; private set; }

        public T this[int index]
        {
            get
            {
                // 判断index是否在当前范围内
                if (index < 0 || index > Length - 1)
                {
                    throw new ArgumentOutOfRangeException();
                }
                
                var currentNode = this.Get(index);
                return currentNode.Data;
            }

            set
            {
                // 判断index是否在当前范围内
                if (index < 0 || index > Length - 1)
                {
                    throw new ArgumentOutOfRangeException();
                }

                var currentNode = this.Get(index);
                currentNode.Data = value;
            }
        }

        private LinkListNode<T> Get(int index)
        {
            // 判断index是否在当前范围内
            if (index < 0 || index > Length - 1)
            {
                throw new ArgumentOutOfRangeException();
            }
                
            // 从头结点开始遍历，记录当前遍历的index
            // 直到找到对应index的结点，返回结点
            // 找不到就返回null
            var currentNode = Rear?.Next;
            int currentIndex = 0;
            while (currentNode?.Next != Rear?.Next && currentIndex < index)
            {
                currentNode = currentNode?.Next;
                currentIndex++;
            }

            if (currentIndex == index)
            {
                return currentNode;
            }

            return null;
        }

        /// <summary>
        /// 追加一个元素
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            var newNode = new LinkListNode<T>(data);
            
            // Length为0，代表当前链表是空的
            // 直接把新节点作为尾节点，并将尾节点的下一个节点指向自己
            if (Length == 0)
            {
                Rear = newNode;
                Rear.Next = Rear;
                Length++;
                return;
            }

            // 设置新节点的下一个节点为头节点
            // 设置当前尾节点的下一个节点为新节点
            // 将新节点设置为尾节点
            newNode.Next = Rear.Next;
            Rear.Next = newNode;
            Rear = newNode;
            Length++;
        }
        
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, T item)
        {
            // index溢出
            if (index < 0 || index > Length - 1)
            {
                return;
            }
            
            // index为0，代表要插入头部
            // 将新节点的Next指针指向当前头节点
            // 并将新节点直接作为头节点
            if (index == 0)
            {
                var newHead = new LinkListNode<T>(item, Rear.Next);
                Rear.Next = newHead;
                Length++;
                return;
            }
            
            // 找到前继节点
            int prevIndex = index - 1;
            var prevNode = Get(prevIndex);
            if (prevNode == null)
            {
                return;
            }

            // 找到指定index对应的节点(前继节点的Next指针指向的节点)
            // 将新节点的Next指针指向index对应节点的Next指针指向的节点
            // 前继节点的Next指针指向新节点，完成新节点的插入操作
            var newNode = new LinkListNode<T>(item, prevNode.Next);
            prevNode.Next = newNode;
            Length++;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            // index溢出
            if (index < 0 || index > Length - 0)
            {
                return;
            }

            // index为0，代表要删除首部
            // 将尾节点的下一个节点指向当前头节点的下一个节点
            if (index == 0)
            {
                Rear.Next = Rear.Next.Next;
                Length--;
                return;
            }
            
            // 找到前继节点
            var prevIndex = index - 1;
            var prevNode = Get(prevIndex);
            if (prevNode == null)
            {
                return;
            }

            if (index == Length - 1)
            {
                // 待删除的是尾节点
                // 则把前继节点设置为尾节点
                prevNode.Next = Rear.Next;
                Rear = prevNode;
            }
            else
            {
                // 将前继节点的Next指针指向index所对应节点的Next指针指向的节点
                prevNode.Next = prevNode.Next.Next;
            }
            
            Length--;
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Clear()
        {
            Rear = null;
            Length = 0;
        }
    }
}