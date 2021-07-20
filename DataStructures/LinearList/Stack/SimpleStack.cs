using System;

namespace LearnAlgorithm.DataStructures.LinearList.Stack
{
    /// <summary>
    /// 栈(简单版本)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SimpleStack<T>
    {
        private readonly int _maxSize = 20;
        private readonly T[] _datas;
        private int _top = -1;

        public SimpleStack()
        {
            _datas = new T[_maxSize];
        }

        public SimpleStack(int maxSize)
        {
            _maxSize = maxSize;
            _datas = new T[_maxSize];
        }
        
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
            // 栈满溢出
            if (_top == _maxSize - 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            _datas[++_top] = item;
            Length++;
        }

        /// <summary>
        /// 出栈
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            // 栈空溢出
            if (_top == -1)
            {
                throw new ArgumentOutOfRangeException();
            }

            var result = _datas[_top];
            _datas[_top] = default(T);
            _top--;
            Length--;

            return result;
        }
    }
}