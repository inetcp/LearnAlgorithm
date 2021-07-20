using System;
using System.Collections.Generic;

namespace LearnAlgorithm.DataStructures.Tree
{
    /// <summary>
    /// 树节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PTreeNode<T>
    {
        /// <summary>
        /// 数据域
        /// </summary>
        public T Data { get; set; }
        
        /// <summary>
        /// 双亲节点index
        /// </summary>
        public int ParentIndex { get; set; }

        public PTreeNode()
        {
        }

        public PTreeNode(T data, int parentIndex)
        {
            Data = data;
            ParentIndex = parentIndex;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            
            if (this == obj)
                return true;

            var objNode = (PTreeNode<T>) obj;
            if (this.Data.Equals(objNode.Data) && this.ParentIndex == objNode.ParentIndex)
            {
                return true;
            }
            
            return false;
        }
    }

    /// <summary>
    /// 树（双亲表示法）
    /// </summary>
    public class PTree<T>
    {
        private readonly int _treeSize = 100;
        private PTreeNode<T>[] _datas;

        public PTree(T rootData)
        {
            _datas = new PTreeNode<T>[_treeSize];
            _datas[0] = new PTreeNode<T>(rootData, -1);
            Count++;
        }

        public PTree(T rootData, int treeSize)
        {
            _treeSize = treeSize;
            _datas = new PTreeNode<T>[_treeSize];
            _datas[0] = new PTreeNode<T>(rootData, -1);
            Count++;
        }

        public int Count { get; private set; }

        /// <summary>
        /// 根节点
        /// </summary>
        public PTreeNode<T> Root => Count == 0 ? null : _datas[0];

        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="data"></param>
        /// <param name="parentNode"></param>
        /// <exception cref="Exception"></exception>
        public PTreeNode<T> AddNode(T data, PTreeNode<T> parentNode)
        {
            // 超出容量
            if (Count > _treeSize)
            {
                return null;
            }

            PTreeNode<T> result = null;

            for (int i = 0; i < _treeSize; i++)
            {
                if (_datas[i] == null)
                {
                    var parentIndex = this.GetNodeIndex(parentNode);
                    if (parentIndex == -1)
                    {
                        throw new Exception("无效的父节点");
                    }

                    result = new PTreeNode<T>(data, parentIndex);
                    _datas[i] = result;
                    Count++;
                    break;
                }
            }

            return result;
        }
        
        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="node"></param>
        public void RemoveNode(PTreeNode<T> node)
        {
            for (int i = 0; i < _treeSize; i++)
            {
                if (_datas[i].Equals(node))
                {
                    _datas[i] = null;
                    Count--;
                }
            }
        }

        /// <summary>
        /// 获取指定节点的父节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public PTreeNode<T> GetParent(PTreeNode<T> node)
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
        public int GetNodeIndex(PTreeNode<T> node)
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
        public List<PTreeNode<T>> GetChilds(PTreeNode<T> parentNode = null)
        {
            var list = new List<PTreeNode<T>>();

            for (int i = 0; i < _treeSize; i++)
            {
                var currentNode = _datas[i];
                if (currentNode == null)
                {
                    continue;
                }

                if (parentNode == null)
                {
                    list.Add(currentNode);
                }
                else
                {
                    var parentIndex = GetNodeIndex(parentNode);
                    if (currentNode.ParentIndex == parentIndex)
                    {
                        list.Add(currentNode);
                    }
                }
            }

            return list;
        }
    }
}