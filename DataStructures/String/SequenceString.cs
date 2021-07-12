using System;

namespace LearnAlgorithm.DataStructures.String
{
    /// <summary>
    /// 字符串(数组形式)
    /// </summary>
    public class SequenceString
    {
        private char[] _datas;

        public SequenceString(char[] datas)
        {
            _datas = datas;
        }

        public SequenceString(int length)
        {
            _datas = new char[length];
        }

        /// <summary>
        /// 字符串长度
        /// </summary>
        public int Length => _datas.Length;

        public char this[int index]
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
        /// 字符串比较
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int Compare(SequenceString str)
        {
            // 取两个字符串中最小的长度
            int len = Length <= str.Length
                ? Length
                : str.Length;

            // 从头到尾，分别比较两个字符，如果找到不相等的字符，则比较大小
            // 如果未找到不相等的字符，则说明其中一个字符包含另一个字符
            int i = 0;
            for (; i < len; i++)
            {
                // 当前字符串大于传入的字符串
                if (this[i] > str[i])
                {
                    return 1;
                }

                // 当前字符串小于传入的字符串
                if (this[i] < str[i])
                {
                    return -1;
                }
            }

            // 当前的字符串长度大于传入字符串的长度
            if (Length > str.Length)
            {
                return 1;
            }

            // 当前的字符串长度小于传入字符串的长度
            if (Length < str.Length)
            {
                return -1;
            }

            // 两个字符的完全一致
            return 0;
        }
 
        /// <summary>
        /// 字符串截取
        /// </summary>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public SequenceString SubString(int index, int length)
        {
            if (index < 0 || index > Length - 1
                          || length < 0 || length > (Length - index))
            {
                throw new ArgumentOutOfRangeException();
            }

            SequenceString newStr = new SequenceString(length);

            // 截取部分从index到 index+length部分
            // 生成新的字符串对象
            for (int i = 0; i < length; i++)
            {
                newStr[i] = this[index + i];
            }

            return newStr;
        }

        /// <summary>
        /// 字符串拼接
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public SequenceString Concat(SequenceString str)
        {
            int inputLength = str.Length;
            // 拼接后的字符串的长度为两个字符串长度之和
            SequenceString newStr = new SequenceString(Length + inputLength);

            // 复制当前字符串到新字符串
            for (int i = 0; i < Length; i++)
            {
                newStr[i] = this[i];
            }

            // 复制传入的字符串到新字符串
            for (int i = 0; i < inputLength; i++)
            {
                newStr[Length + i] = str[i];
            }

            return newStr;
        }

        /// <summary>
        /// 字符串插入
        /// </summary>
        /// <param name="index"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public SequenceString Insert(int index, SequenceString str)
        {
            if (index < 0 || index > Length - 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            
            // 插入后的字符串的长度为两个字符串长度之和
            int inputLength = str.Length;
            int newLength = Length + inputLength;
            SequenceString newStr = new SequenceString(newLength);

            // 复制当前字符串[0, index - 1]部分到新字符串[0, index - 1]部分
            for (int i = 0; i < index; i++)
            {
                newStr[i] = this[i];
            }

            // 复制输入字符串到新字符串[index, index + inputLength - 1]部分
            for (int i = 0; i < inputLength; i++)
            {
                newStr[index + i] = str[i];
            }

            // 复制当前字符串[index, length - 1]部分到新字符串[index + inputLength, newLength]部分
            for (int i = index; i < Length; i++)
            {
                newStr[inputLength + i] = this[i];
            }

            return newStr;
        }

        /// <summary>
        /// 删除指定索引字符串
        /// </summary>
        /// <param name="index"></param>
        /// <param name="delLength"></param>
        /// <returns></returns>
        public SequenceString Delete(int index, int delLength)
        {
            if (index < 0 || index > Length - 1
                          || delLength <= 0 || delLength > (Length - index))
            {
                throw new ArgumentOutOfRangeException();
            }

            // 删除后的字符串的长度为当前长度减去待删除的长度
            int newLength = Length - delLength;
            SequenceString newStr = new SequenceString(newLength);

            // 复制当前字符串[0, index]部分到新字符串[0, index]部分
            for (int i = 0; i < index; i++)
            {
                newStr[i] = this[i];
            }

            // 复制当前字符串[index + delLength, length]部分到新字符串[index, newLength]部分
            for (int i = index; i < Length - index - delLength; i++)
            {
                newStr[i] = this[i + delLength];
            }

            return newStr;
        }

        public int IndexOf(SequenceString str)
        {
            int inputLength = str.Length;
            
            // 待匹配的字符串大于当前字符串长度，返回-1
            if (inputLength > Length)
            {
                return -1;
            }

            // 主串和子串长度差
            int i = 0;
            int diff = Length - inputLength;
            while (i < diff)
            {
                // 从主串的指定索引处截取与字串一样长度的字符
                // 与子串进行比较，如果匹配，则当前i的值就是子串在主串中的对应位置
                SequenceString tmpStr = SubString(i, inputLength);
                if (str.Compare(tmpStr) == 0)
                {
                    return i;
                }

                i++;
            }

            // 如果没找到，就返回-1
            return -1;
        }
    }
}