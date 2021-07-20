using System;

namespace LearnAlgorithm.DataStructures.LinearList.Queue
{
    /// <summary>
    /// 循环队列
    /// </summary>
    public class CircularQueue<T>
    {
        private readonly int _maxSize = 20;
        private readonly T[] _datas;
        
        // 队列头指针
        private int _front;
        
        // 队列尾指针
        private int _rear;

        public CircularQueue()
        {
            _datas = new T[_maxSize];
        }

        public CircularQueue(int maxSize)
        {
            _maxSize = maxSize;
        }

        /// <summary>
        /// 队列长度
        /// </summary>
        public int Length => (_rear - _front + _maxSize) % _maxSize;

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="item"></param>
        public void EnQueue(T item)
        {
            // 队列已满（_rear与_front相差一位）
            // 因为_rear可能比_front大(_rear在_front左边)
            // 也可能比_front小(_rear在_front右边)
            // 所以计算队列满的方式 (_rear + 1) % _maxSize == _font
            // 取模的目的是为了处理_rear比_front小的情况
            if ((_rear + 1) % _maxSize == _front)
            {
                throw new ArgumentOutOfRangeException();
            }

            // 将元素添加到队列尾部
            _datas[_rear] = item;
            // 将_rear指针向后移动一位，如果到了队尾，则移动到数组头部
            _rear = (_rear + 1) % _maxSize;
        }

        /// <summary>
        /// 出队
        /// </summary>
        /// <returns></returns>
        public T DeQueue()
        {
            // 队列为空(_font与_rear相等)
            if (_front == _rear)
            {
                throw new ArgumentOutOfRangeException();
            }

            var result = _datas[_front];
            _datas[_front] = default(T);
            _front = (_front + 1) % _maxSize;

            return result;
        }
    }
}