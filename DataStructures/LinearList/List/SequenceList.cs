using System;

namespace LearnAlgorithm.DataStructures.LinearList.List
{
    /// <summary>
    /// 线性表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SequenceList<T>
    {
        private readonly int _maxSize = 20;
        private T[] _datas;

        public SequenceList()
        {
            _datas = new T[_maxSize];
        }

        public SequenceList(int maxSize)
        {
            _maxSize = maxSize;
            _datas = new T[_maxSize];
        }

        /// <summary>
        /// 当前数量
        /// </summary>
        public int Length { get; private set; }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > Length - 1)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return _datas[index];
            }
            
            set
            {
                if (index < 0 || index > Length - 1)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _datas[index] = value;
            }
        }
        
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            // 当前空间已满，直接退出
            if (Length == _maxSize)
            {
                return;
            }

            _datas[Length] = item;
            Length++;
        }

        /// <summary>
        /// 指定位置插入
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, T item)
        {
            // 当前空间已满，直接退出
            if (Length == _maxSize)
            {
                return;
            }

            // 索引溢出
            if (index < 0 || index > Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            // 若插入数据位置不在表尾
            if (index <= Length - 1)
            {
                // 将要插入位置后数据元素向后移动一位
                for (int i = Length - 2; i >= index; i--)
                {
                    _datas[i + 1] = _datas[i];
                }
            }
            
            // 将新元素插入
            _datas[index] = item;
            Length++;
        }

        /// <summary>
        /// 指定位置删除
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T RemoveAt(int index)
        {
            if (Length == 0)
            {
                return default(T);
            }

            // 索引溢出
            if (index < 0 || index > Length - 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            
            T result = _datas[index];

            // 如果删除的不是最后的位置
            if (index < Length - 1)
            {
                // 将删除位置后继元素前移
                for (int i = index + 1; i < Length; i++)
                {
                    _datas[i - 1] = _datas[i];
                    _datas[i] = default(T);
                }
            }

            Length--;
            return result;
        }

        public void Clear()
        {
            _datas = new T[_maxSize];
            Length = 0;
        }
    }
}