namespace LearnAlgorithm.DataStructures.LinearList.Link
{
    /// <summary>
    /// 链表结点
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
}