using LearnAlgorithm.DataStructures.LinearList.Link;

namespace LearnAlgorithm.DataStructures.LinearList.Stack
{
    /// <summary>
    /// 栈(链表版)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkStack<T>
    {
        private LinkListNode<T> _top;
        
        /// <summary>
        /// 栈长度
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            if (_top == null)
            {
                _top = new LinkListNode<T>(item);
                Length++;
                return;
            }

            var newNode = new LinkListNode<T>(item, _top);
            _top = newNode;
            Length++;
        }

        /// <summary>
        /// 出栈
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (_top == null)
            {
                return default(T);
            }

            var result = _top.Data;
            _top = _top.Next;
            Length--;

            return result;
        }
    }
}