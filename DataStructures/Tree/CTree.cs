using System;
using System.Collections.Generic;

namespace LearnAlgorithm.DataStructures.Tree
{
    /// <summary>
    /// 树节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CTreeNode<T>
    {
        /// <summary>
        /// 数据域
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 双亲节点Index
        /// </summary>
        public int ParentIndex { get; set; }

        /// <summary>
        /// 孩子节点指针域
        /// </summary>
        public CTreeChildNode FirstChild { get; set; }

        public CTreeNode(T data, int parentIndex)
        {
            Data = data;
            ParentIndex = parentIndex;
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            
            if (this == obj)
                return true;

            var objNode = (CTreeNode<T>) obj;
            if (this.Data.Equals(objNode.Data) && this.ParentIndex == objNode.ParentIndex)
            {
                return true;
            }
            
            return false;
        }

        public void AddChildNode(int index)
        {
            if (FirstChild == null)
            {
                FirstChild = new CTreeChildNode(index);
            }
            else
            {
                var lastNode = FirstChild;
                while (lastNode.Next != null)
                {
                    lastNode = lastNode.Next;
                }

                lastNode.Next = new CTreeChildNode(index);
            }
        }
    }

    /// <summary>
    /// 孩子链表节点
    /// </summary>
    public class CTreeChildNode
    {
        /// <summary>
        /// 孩子节点Index 
        /// </summary>
        public int ChildIndex { get; set; }

        /// <summary>
        /// 下一个孩子节点
        /// </summary>
        public CTreeChildNode Next { get; set; }

        public CTreeChildNode()
        {
        }

        public CTreeChildNode(int childIndex)
        {
            this.ChildIndex = childIndex;
        }
    }

    /// <summary>
    /// 树（孩子表示法）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CTree<T>
    {
        private readonly int _treeSize = 100;
        private CTreeNode<T>[] _datas;

        public CTree(T rootData)
        {
            _datas = new CTreeNode<T>[_treeSize];
            _datas[0] = new CTreeNode<T>(rootData, -1);
            Count++;
        }

        public CTree(T rootData, int treeSize)
        {
            _treeSize = treeSize;
            _datas = new CTreeNode<T>[_treeSize];
            _datas[0] = new CTreeNode<T>(rootData, -1);
            Count++;
        }

        public int Count { get; private set; }
        
        /// <summary>
        /// 根节点
        /// </summary>
        public CTreeNode<T> Root => Count == 0 ? null : _datas[0];

        public CTreeNode<T> AddNode(T data, CTreeNode<T> parentNode)
        {
            // 超出容量
            if (Count > _treeSize)
            {
                return null;
            }
            
            var parentIndex = this.GetNodeIndex(parentNode);
            if (parentIndex == -1)
            {
                throw new Exception("无效的父节点");
            }

            CTreeNode<T> result = null;

            for (int i = 0; i < _treeSize; i++)
            {
                if (_datas[i] == null)
                {
                    result = new CTreeNode<T>(data, parentIndex);
                    _datas[i] = result;
                    parentNode.AddChildNode(i);
                    Count++;
                    break;
                }
            }

            return result;
        }
        
        /// <summary>
        /// 获取指定节点的父节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public CTreeNode<T> GetParent(CTreeNode<T> node)
        {
            if (node == null)
                return null;

            return _datas[node.ParentIndex];
        }
        
        /// <summary>
        /// 获取指定节点的Index
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int GetNodeIndex(CTreeNode<T> node)
        {
            for (int i = 0; i < _treeSize; i++)
            {
                if (_datas[i].Equals(node))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// 获取指定节点的子节点列表
        /// </summary>
        /// <param name="parentNode"></param>
        /// <returns></returns>
        public List<CTreeNode<T>> GetChilds(CTreeNode<T> parentNode = null)
        {
            var list = new List<CTreeNode<T>>();
            if (parentNode == null)
            {
                for (int i = 0; i < _treeSize; i++)
                {
                    if (_datas[i] != null)
                    {
                        list.Add(_datas[i]);
                    }
                }
            }
            else
            {
                var currentNode = parentNode.FirstChild;
                while (currentNode != null)
                {
                    list.Add(_datas[currentNode.ChildIndex]);
                    currentNode = currentNode.Next;
                }
            }

            return list;
        }
    }
}