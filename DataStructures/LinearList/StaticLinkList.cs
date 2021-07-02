using System;

namespace LearnAlgorithm.DataStructures.LinearList
{
    /// <summary>
    /// 静态链表节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct StaticLinkListNode<T>
    {
        /// <summary>
        /// 数据域
        /// </summary>
        public T Data { get; set; }
        
        /// <summary>
        /// 游标
        /// </summary>
        public int Cursor { get; set; }
        
        public StaticLinkListNode(int cursor) : this()
        {
            Cursor = cursor;
        }

        public StaticLinkListNode(T data, int cursor)
        {
            Data = data;
            Cursor = cursor;
        }
    }

    /// <summary>
    /// 静态链表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StaticLinkList<T>
    {
        private readonly int _maxSize = 22;
        private StaticLinkListNode<T>[] _datas;

        public StaticLinkList()
        {
            _datas = new StaticLinkListNode<T>[_maxSize];
            InitList();
        }

        public StaticLinkList(int maxSize)
        {
            // 2个元素作为保留位，分别是头节点和尾节点
            _maxSize = maxSize + 2;
            _datas = new StaticLinkListNode<T>[_maxSize];
            InitList();
        }

        /// <summary>
        /// 当前数量
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
                
                int currentNodeIndex = this.Get(index);
                return _datas[currentNodeIndex].Data;
            }

            set
            {
                // 判断index是否在当前范围内
                if (index < 0 || index > Length - 1)
                {
                    throw new ArgumentOutOfRangeException();
                }

                int currentNodeIndex = this.Get(index);
                _datas[currentNodeIndex].Data = value;
            }
        }

        private int Get(int index)
        {
            // 判断index是否在当前范围内
            if (index < 0 || index > Length - 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            
            // 尾节点上的游标对应第一个元素的index
            int currentIndex = _datas[_maxSize - 1].Cursor;
            int tempIndex = 0;
            
            // 从第一个元素开始找
            // 一旦遍历元素的游标为0（最后一个元素）
            // 或遍历到指定的index
            // 退出循环
            while (_datas[currentIndex].Cursor > 0 && tempIndex < index)
            {
                currentIndex = _datas[currentIndex].Cursor;
                tempIndex++;
            }

            // 找到对应的数据
            if (tempIndex == index)
            {
                return currentIndex;
            }

            return -1;
        }

        /// <summary>
        /// 初始化链表
        /// </summary>
        private void InitList()
        {
            // 对数组第一个和最后一个元素作特殊处理
            // 其中未被使用的数组元素定义为备用链表
            // 下标为0的元素的Cursor存放备用链表的第一个结点的下标
            // 最后一个元素的Cursor则存放第一个有数值元素的下标
            for (int i = 0; i < _maxSize - 1; i++)
            {
                _datas[i] = new StaticLinkListNode<T>(i + 1);
            }

            _datas[_maxSize - 1].Cursor = 0;
        }

        private int Malloc()
        {
            // 数组头节点存的cursor，就是空闲的下标
            int newNodeIndex = _datas[0].Cursor;
            if (newNodeIndex > 0)
            {
                // 更新头节点的游标
                _datas[0].Cursor = _datas[newNodeIndex].Cursor;
            }
            
            return newNodeIndex;
        }

        /// <summary>
        /// 追加一个元素
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            // 当前链表已满
            if (Length == _maxSize - 2)
            {
                return;
            }

            var newNodeIndex = Malloc();
            if (newNodeIndex == 0)
            {
                return;
            }
            
            // 设置当前节点数据
            _datas[newNodeIndex].Data = item;
            _datas[newNodeIndex].Cursor = 0;

            if (Length == 0)
            {
                // 当前Length为0，代表当前链表是空的，此次新增的是第一条数据
                // 将新数据的索引赋值给尾节点的游标上
                _datas[_maxSize - 1].Cursor = newNodeIndex;
            }
            else
            {
                // 当前Length>0，则找到当前最后一个节点
                // 设置当前最后一个节点的游标为新节点的索引
                int lastNodeIndex = Get(Length - 1);
                _datas[lastNodeIndex].Cursor = newNodeIndex;
            }

            Length++;
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, T item)
        {
            // 索引溢出
            if (index < 0 || index > Length - 1 || Length == _maxSize - 2)
            {
                return;
            }

            var newNodeIndex = Malloc();
            if (newNodeIndex == 0)
            {
                return;
            }
            
            // 插入新节点数据
            _datas[newNodeIndex].Data = item;

            // index为0，代表要拆入到头部
            // 将尾节点上的游标更新到新节点的游标上(作为新节点下一个节点)
            // 并将新节点的index更新到尾节点的游标上(新节点作为第一个节点)
            if (index == 0)
            {
                _datas[newNodeIndex].Cursor = _datas[_maxSize - 1].Cursor;
                _datas[_maxSize - 1].Cursor = newNodeIndex;
                Length++;
                return;
            }

            // 找到前继节点
            int prevIndex = index - 1;
            var prevNodeIndex = Get(prevIndex);
            
            // 将当前节点的index作为新节点的游标(当前节点作为新节点的下一个节点)
            // 将新节点的index作为前继节点的游标(新节点作为前继节点的下一个节点)
            _datas[newNodeIndex].Cursor = _datas[prevNodeIndex].Cursor;
            _datas[prevNodeIndex].Cursor = newNodeIndex;
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

            int currentNodeIndex;

            if (index == 0)
            {
                // 当前节点的index
                currentNodeIndex = _datas[_maxSize - 1].Cursor;
                // 将当前节点的下一个节点作为第一个节点
                _datas[_maxSize - 1].Cursor = _datas[currentNodeIndex].Cursor;
            }
            else
            {
                // 找到前继节点
                var prevIndex = index - 1;
                var prevNodeIndex = Get(prevIndex);
            
                // 当前节点index
                currentNodeIndex = _datas[prevNodeIndex].Cursor;
                // 将当前节点的下一个节点作为前继节点的下一个节点
                _datas[prevNodeIndex].Cursor = _datas[currentNodeIndex].Cursor;
            }
            
            // 将当前节点的数据清空
            _datas[currentNodeIndex].Data = default(T);
            // 将当前第一个空闲节点作为当的下一个节点
            _datas[currentNodeIndex].Cursor = _datas[0].Cursor;
            // 当前节点将被删除，说明已空闲，那么将当前节点作为头节点的第一个空闲节点
            _datas[0].Cursor = currentNodeIndex;

            Length--;
        }
    }
}