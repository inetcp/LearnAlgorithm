using LearnAlgorithm.DataStructures.LinearList.Link;

namespace LearnAlgorithm.DataStructures.LinearList.Queue
{
    /// <summary>
    /// 队列(链表版)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkQueue<T>
    {
        /// <summary>
        /// 队首指针
        /// </summary>
        private LinkListNode<T> _front;
        
        /// <summary>
        /// 队尾指针
        /// </summary>
        private LinkListNode<T> _rear;
        
        /// <summary>
        /// 队列长度
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// 入队
        /// </summary>
        public void EnQueue(T item)
        {
            if (Length == 0)
            {
                // 队列为空
                // 新创建的节点直接作为队首节点
                // 并将队尾指向队首
                _front = new LinkListNode<T>(item);
                _rear = _front;
                Length++;
                return;
            }

            // 将新节点添加当前队尾后面
            // 并将新节点做为新的队尾
            var newNode = new LinkListNode<T>(item);
            _rear.Next = newNode;
            _rear = newNode;
            Length++;
        }

        /// <summary>
        /// 出队
        /// </summary>
        /// <returns></returns>
        public T DeQueue()
        {
            if (Length == 0)
            {
                return default(T);
            }

            var result = _front.Data;
            if (Length == 1)
            {
                _front = null;
                _rear = null;
            }
            else
            {
                _front = _front.Next;
            }
            
            Length--;

            return result;
        }
    }
}