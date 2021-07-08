using System;
using System.Collections.Generic;

namespace LearnAlgorithm.Algorithms
{
    /// <summary>
    /// 四则运算（栈的应用）
    /// </summary>
    public class Arithmetic
    {
        /// <summary>
        /// 计算表达式结果
        /// </summary>
        /// <param name="expression">表达式</param>
        /// <returns></returns>
        public int Calculate(string expression)
        {
            string newExpression = Convert(expression);

            int i = 0;
            int len = newExpression.Length;
            string strDigit = string.Empty;
            Stack<string> stack = new Stack<string>();
            while (i <= len - 1)
            {
                char c = newExpression[i];
                if (c == ' ')
                {
                    i++;
                    continue;
                }

                if (char.IsNumber(c))
                {
                    strDigit += c;
                    bool isNextCharNumber = i + 1 <= len - 1 && char.IsNumber(newExpression[i + 1]);
                    if (isNextCharNumber)
                    {
                        i++;
                        continue;
                    }
                    else
                    {
                        stack.Push(strDigit);
                        strDigit = string.Empty;
                    }
                }
                else
                {
                    string num1 = stack.Pop();
                    string num2 = stack.Pop();
                    string calcNum = string.Empty;

                    switch (c)
                    {
                        case '+':
                            calcNum = int.Parse(num2) + int.Parse(num1) + "";
                            break;
                        case '-':
                            calcNum = int.Parse(num2) - int.Parse(num1) + "";
                            break;
                        case '*':
                            calcNum = int.Parse(num2) * int.Parse(num1) + "";
                            break;
                        case '/':
                            calcNum = int.Parse(num2) / int.Parse(num1) + "";
                            break;
                    }
                    
                    stack.Push(calcNum);
                }

                i++;
            }

            string strResult = stack.Pop();
            int result = int.Parse(strResult);
            return result;
        }

        /// <summary>
        /// 将中缀表达式转换为后缀表达式
        /// </summary>
        /// <param name="expression">中缀表达式</param>
        /// <returns></returns>
        public string Convert(string expression)
        {
            // 空字符直接退出
            if (string.IsNullOrWhiteSpace(expression))
            {
                throw new ArgumentNullException();
            }

            // 定义转换后的表达式数组（因为要输出空格，所以以当前字符串长度的2倍新建数组）
            var result = new List<string>(expression.Length * 2);
            // 定义有效的操作符map, value为操作符优先级(越大优先级越高，括号特殊处理为0)
            var dicOperator = new Dictionary<char, int>()
            {
                { '+', 1 },
                { '-', 1 },
                { '*', 2 },
                { '/', 2 },
                { '(', 0 },
                { ')', 0 }
            };
            // 定义栈
            var stack = new Stack<char>();
            int i = 0;
            int len = expression.Length;
            // 定义数字字符串，用于处理多位数的情况
            string strDigit = string.Empty;
            
            while (i <= len - 1)
            {
                char c = expression[i];
                
                // 空格则进入下一次循环
                if (c == ' ')
                {
                    i++;
                    continue;
                }
                
                // 非数字或有效的运算符，直接退出
                bool isNumber = char.IsNumber(c);
                if (!isNumber && !dicOperator.ContainsKey(c))
                {
                    throw new Exception("表达式中存在无效的字符");
                }


                if (isNumber)
                {
                    // 如果当前字符是数字，则判断下一位字符是否是数字
                    // 如果没有下一位，或下一位字符不是数字，则把当前累计的数字字符串添加输出列表中，并清空数字字符串
                    
                    strDigit += c;
                    bool isNextCharNumber = i + 1 <= len - 1 && char.IsNumber(expression[i + 1]);
                    if (isNextCharNumber)
                    {
                        i++;
                        continue;
                    }
                    else
                    {
                        result.Add(strDigit);
                        strDigit = string.Empty;
                    }
                }
                else
                {
                    switch (c)
                    {
                        case '+':
                        case '-':
                            if (stack.Count == 0)
                            {
                                // 空栈直接入栈
                                stack.Push(c);
                            }
                            else
                            {
                                // 当前符号运算优先级小于等于栈顶元素元素优先级
                                // 则栈中所有元素出栈，然后当前元素入栈
                                // 否则当前元素直接入栈
                                if (dicOperator[c] <= dicOperator[stack.Peek()] && dicOperator[stack.Peek()] != 0)
                                {
                                    while (stack.Count > 0)
                                    {
                                        result.Add(stack.Pop().ToString());
                                    }
                                }
                                stack.Push(c);
                            }

                            break;
                        case '(':
                            stack.Push(c);
                            break;
                        case ')':
                            // 是否匹配到左括号
                            bool isFindLeftParenthesis = false;
                            while (stack.Count > 0)
                            {
                                // 遇到左括号，左括号出栈后退出
                                // 否则将符号出栈放入输出结果里面
                                if (stack.Peek() == '(')
                                {
                                    isFindLeftParenthesis = true;
                                    stack.Pop();
                                    break;
                                }
                                else
                                {
                                    result.Add(stack.Pop().ToString());
                                }
                            }

                            if (!isFindLeftParenthesis)
                            {
                                throw new Exception("存在未闭合的括号");
                            }

                            break;
                        case '*':
                        case '/':
                            if (stack.Count == 0)
                            {
                                // 空栈直接入栈
                                stack.Push(c);
                            }
                            else
                            {
                                // 当前符号运算优先级小于等于栈顶元素元素优先级
                                // 栈顶元素先出栈，当前符号在入栈
                                // 否则直接入栈
                                if (dicOperator[c] <= dicOperator[stack.Peek()] && dicOperator[stack.Peek()] != 0)
                                {
                                    result.Add(stack.Pop().ToString());
                                }
                                stack.Push(c);
                            }

                            break;
                    }
                }

                i++;
            }

            // 将所有元素出栈
            while (stack.Count > 0)
            {
                result.Add(stack.Pop().ToString());
            }
            
            return string.Join(' ', result);
        }
    }
}