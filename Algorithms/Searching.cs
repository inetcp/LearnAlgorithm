namespace LearnAlgorithm.Algorithms
{
    /// <summary>
    /// 查找
    /// </summary>
    public class Searching
    {
        /// <summary>
        /// 顺序查找
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int SequenceSearch(int[] nums, int value)
        {
            // 空数组返回-1
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }

            // 数组长度
            int length = nums.Length;

            // 从头到位遍历数组，找到后返回
            for (int i = 0; i < length; i++)
            {
                if (nums[i] == value)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// 二分查找（非递归版）
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int BinarySearchNonRecursion(int[] nums, int value)
        {
            // 空数组返回-1
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }

            // 数组长度
            int length = nums.Length;

            // 最低位指针(默认第一个元素)
            int low = 0;
            // 最高位指针(默认最后一个元素)
            int high = length - 1;

            // 最低位小于最高位时
            // 每次计算最低位和最高位中间的索引
            // 判断待查询的数字与中间位的数字大小
            // 相等则说明已查询到，直接返回
            // 大于则说明待查询的数字在中间位右边，设置最低位的指针为中间位+1
            // 小于则说明待查询的数字在中间位左边，设置最高位的指针位中间位-1
            while (low < high)
            {
                // 计算中间位索引
                int mid = low + (high - low) / 2;
                if (value == nums[mid])
                {
                    return mid;
                }
                else if (value > nums[mid])
                {
                    low = mid + 1;
                }
                else if (value < nums[mid])
                {
                    high = mid - 1;
                }
            }

            return -1;
        }

        /// <summary>
        /// 二分查找（递归版）
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int BinarySearchRecursion(int[] nums, int value)
        {
            // 空数组返回-1
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }

            // 数组长度
            int length = nums.Length;

            // 第一次查询范围为整个数组
            return BinarySearch(nums, value, 0, length - 1);
        }

        private static int BinarySearch(int[] nums, int value, int low, int high)
        {
            // 最低位大于最高位，查找结束并且未找到，返回-1
            if (low > high)
            {
                return -1;
            }

            // 计算中间位索引
            int mid = low + (high - low) / 2;

            if (value == nums[mid])
            {
                return mid;
            }
            else if (value > nums[mid])
            {
                return BinarySearch(nums, value, mid + 1, high);
            }
            else if (value < nums[mid])
            {
                return BinarySearch(nums, value, low, mid - 1);
            }

            return -1;
        }
    }
}