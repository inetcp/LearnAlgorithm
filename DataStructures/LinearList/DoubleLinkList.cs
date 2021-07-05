using System;

namespace LearnAlgorithm.DataStructures.LinearList
{
    /// <summary>
    /// 双向链表节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DoubleLinkListNode<T> 
    {
        /// <summary>
        /// 数据域
        /// </summary>
        public T Data { get; set; }
        
        /// <summary>
        /// Prev指针域
        /// </summary>
        public DoubleLinkListNode<T> Prev { get; set; }
        
        /// <summary>
        /// Next指针域
        /// </summary>
        public DoubleLinkListNode<T> Next { get; set; }

        public DoubleLinkListNode(T data, DoubleLinkListNode<T> prev, DoubleLinkListNode<T> next)
        {
            Data = data;
            Prev = prev;
            Next = next;
        }

        public DoubleLinkListNode(T data)
        {
            Data = data;
        }

        public DoubleLinkListNode(DoubleLinkListNode<T> prev, DoubleLinkListNode<T> next)
        {
            Prev = prev;
            Next = next;
        }

        public DoubleLinkListNode()
        {
        }
    }

    /// <summary>
    /// 循环双向链表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DoubleLinkList<T>
    {
        /// <summary>
        /// 头结点
        /// </summary>
        public DoubleLinkListNode<T> Head { get; private set; }

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

        private DoubleLinkListNode<T> Get(int index)
        {
            // 判断index是否在当前范围内
            if (index < 0 || index > Length - 1)
            {
                throw new ArgumentOutOfRangeException();
            }
                
            // 从头结点开始遍历，记录当前遍历的index
            // 直到找到对应index的结点，返回结点
            // 找不到就返回null
            var currentNode = Head;
            int currentIndex = 0;
            while (currentNode.Next != Head && currentIndex < index)
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
            var newNode = new DoubleLinkListNode<T>(data);
            
            // Length为0，代表当前链表是空的
            // 直接把新节点作为尾节点，并将尾节点的下一个节点指向自己
            if (Length == 0)
            {
                Head = newNode;
                Head.Prev = Head;
                Head.Next = Head;
                Length++;
                return;
            }

            // 尾节点
            var rear = Head.Prev;
            // 将当前节点作为尾节点的下一个节点
            rear.Next = newNode;
            
            // 将尾节点作为新节点的上一个节点
            newNode.Prev = rear;
            // 将头节点作为新节点的下一个节点
            newNode.Next = Head;

            // 将新节点作为头节点的上一个节点（新的尾节点）
            Head.Prev = newNode;

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
            if (index == 0)
            {
                // 创建新节点
                // 新节点的上一个节点为尾节点(Head.Prev)
                // 新节点的下一个节点为当前的头节点(Head)
                var newHead = new DoubleLinkListNode<T>(item, Head.Prev, Head);
                
                // 设置尾节点的下一个节点为新节点
                Head.Prev.Next = newHead;
                // 设置当前的头节点的上一个节点为新节点
                Head.Prev = newHead;

                // 将新节点设置为新的头节点
                Head = newHead;
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
            
            // 创建新节点
            // 新节点的上一个节点为当前节点上一个节点
            // 新节点的下一个节点为当前节点
            var newNode = new DoubleLinkListNode<T>(item, prevNode, prevNode.Next);

            // 设置当前节点(prevNode.Next)的上一个节点为新节点
            prevNode.Next.Prev = newNode;
            // 设置当前节点上一个节点的下一个节点为新节点(新节点替代当前节点)
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
            if (index == 0)
            {
                // 设置尾节点(Head.Prev)的下一个节点为当前头节点的下一个节点
                Head.Prev.Next = Head.Next;
                // 设置当前头节点的下一个节点的上一个节点为尾节点(Head.Prev)
                Head.Next.Prev = Head.Prev;

                // 将当前头节点的下一个节点设置为新的头节点
                Head = Head.Next;
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
                // 切断尾节点的上一个节点指向
                Head.Prev.Prev = null;
                // 切断为节点的下一个节点指向
                Head.Prev.Next = null;
                
                // 将前继节点作为新的尾节点
                // 前继节点的下一个节点为头节点
                prevNode.Next = Head;
                // 头节点的上一个节点为前继节点
                Head.Prev = prevNode;
            }
            else
            {
                // 当前节点
                var currentNode = prevNode.Next;
                // 前继节点的下一个节点为当前节点的下一个节点
                prevNode.Next = currentNode.Next;
                // 当前节点的下一个节点的上一个节点为前继节点
                currentNode.Next.Prev = prevNode;

                // 切断当前节点的上一个节点指向
                currentNode.Prev = null;
                // 切断当前节点下一个节点指向
                currentNode.Next = null;
            }
            
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