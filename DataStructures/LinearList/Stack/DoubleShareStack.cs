using System;

namespace LearnAlgorithm.DataStructures.LinearList.Stack
{
    /// <summary>
    /// 两栈共享空间
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DoubleShareStack<T>
    {
        private readonly int _maxSize = 20;
        private readonly T[] _datas;
        private int _top1;
        private int _top2;

        public DoubleShareStack()
        {
            _datas = new T[_maxSize];
            _top1 = -1;
            _top2 = _maxSize;
        }

        public DoubleShareStack(int maxSize)
        {
            _maxSize = maxSize;
            _datas = new T[_maxSize];
            _top1 = -1;
            _top2 = _maxSize;
        }

        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="item"></param>
        /// <param name="stackNumber"></param>
        public void Push(T item, int stackNumber)
        {
            // 两个栈的指针相遇，代表栈满
            if (_top1 + 1 == _top2)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (stackNumber == 1)
            {
                // 栈1入栈, 栈1指针向右移动，元素追加到右边
                _datas[++_top1] = item;
            }
            else if (stackNumber == 2)
            {
                // 栈2入栈，栈2指针向左移动，元素追加到左边
                _datas[--_top2] = item;
            }
            else
            {
                throw new Exception("无效的栈编号");
            }
        }

        /// <summary>
        /// 出栈
        /// </summary>
        /// <param name="stackNumber"></param>
        /// <returns></returns>
        public T Pop(int stackNumber)
        {
            if (stackNumber == 1)
            {
                // 栈1为空
                if (_top1 == -1)
                {
                    throw new ArgumentOutOfRangeException();
                }
                
                var result = _datas[_top1];
                _datas[_top1] = default(T);
                
                // 栈1指针向左移动将栈顶元素出栈
                _top1--;

                return result;
            }
            else if (stackNumber == 2)
            {
                // 栈2为空
                if (_top2 == _maxSize)
                {
                    throw new ArgumentOutOfRangeException();
                }
                
                var result = _datas[_top2];
                _datas[_top2] = default(T);
                
                // 栈2指针向右移动将栈顶元素出栈
                _top2++;

                return result;
            }
            
            throw new Exception("无效的栈编号");
        }
    }
}