using System;

namespace LearnAlgorithm.DataStructures.LinearList
{
    /// <summary>
    /// 线性表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SequenceList<T>
    {
        private readonly int _maxSize = 20;
        private T[] _datas;
        private int _length;

        public SequenceList()
        {
            _datas = new T[_maxSize];
        }

        public SequenceList(int maxSize) : this()
        {
            _maxSize = maxSize;
        }

        public int Length => _length;

        public T GetElement(int index)
        {
            if (_length == 0 || index < 0 || index > _length - 1)
                throw new Exception("线性表为空或无效的序号");

            return _datas[index];
        }

        public void Add(T item)
        {
            if (_length == _maxSize)
                throw new Exception("线性表已满");

            _datas[_length] = item;
            _length++;
        }

        public void Insert(int index, T item)
        {
            int k;
            if (_length == _maxSize)
                throw new Exception("线性表已满");

            if (index < 0 || index > _length)
                throw new Exception("index 不在范围之内");

            // 若插入数据位置不在表尾
            if (index <= _length - 1)
            {
                // 将要插入位置后数据元素向后移动一位
                for (k = _length - 2; k >= index; k--)
                    _datas[k + 1] = _datas[k];
            }
            
            // 将新元素插入
            _datas[index] = item;
            _length++;
        }

        public T RemoveAt(int index)
        {
            int k;
            if (_length == 0)
                throw new Exception("线性表为空");

            if (index < 0 || index > _length - 1)
                throw new Exception("index 不在范围之内");

            T result = _datas[index];

            // 如果删除的不是最后的位置
            if (index < _length - 1)
            {
                // 将删除位置后继元素前移
                for (k = index + 1; k < _length; k++)
                    _datas[k - 1] = _datas[k];
            }

            _length--;
            return result;
        }
        
    }
}