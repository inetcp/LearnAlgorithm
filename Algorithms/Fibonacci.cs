namespace LearnAlgorithm.Algorithms
{
    public class Fibonacci
    {
        /// <summary>
        /// 斐波那契非递归版
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FibonacciNonRecursion(int n)
        {
            if (n < 3)
                return n == 0 ? 0 : 1;
            
            int first = 1;
            int second = 1;
            int result = 0;
            int i = 2;
            while (i < n)
            {
                result = first + second;
                first = second;
                second = result;
                i++;
            }

            return result;
        }

        /// <summary>
        /// 斐波那契递归版
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FibonacciWithRecursion(int n)
        {
            if (n < 3)
                return n == 0 ? 0 : 1;
            
            return FibonacciWithRecursion(n - 2) + FibonacciNonRecursion(n - 1);
        }
    }
}