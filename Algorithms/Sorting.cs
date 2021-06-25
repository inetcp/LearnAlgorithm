namespace LearnAlgorithm.Algorithms
{
    /// <summary>
    /// 排序
    /// </summary>
    public class Sorting
    {
        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="nums"></param>
        public static void BubbleSort(int[] nums)
        {
            // 空数组直接退出
            if (nums == null || nums.Length == 0)
            {
                return;
            }

            // 数组长度
            int length = nums.Length;

            // 外层循环，每次循环将此循环最大值置换到尾部
            for (int i = 0; i < length - 1; i++)
            {
                // 是否发生置换，默认为false
                bool hasSwap = false;

                // 内层循环
                for (int j = 0; j < length - i - 1; j++)
                {
                    // 相邻的两个元素判断
                    // 如果前一个元素大于后一个元素，则置换两个值
                    if (nums[j] > nums[j + 1])
                    {
                        int tmp = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = tmp;

                        // 产生置换，设置为true
                        hasSwap = true;
                    }
                }

                // 本轮循环是否发生了置换，如果没有发生置换，则代表数组已经是有序的，跳出循环
                if (!hasSwap)
                {
                    break;
                }
            }
            
        }

        /// <summary>
        /// 选择排序
        /// </summary>
        /// <param name="nums"></param>
        public static void SelectionSort(int[] nums)
        {
            // 空数组直接退出
            if (nums == null || nums.Length == 0)
            {
                return;
            }

            // 数组长度
            int length = nums.Length;

            // 外层循环，每次循环将此循环最小值置换到头部
            for (int i = 0; i < length - 1; i++)
            {
                // 默认每次循环的第一个值为最小值索引
                int minIndex = i;
                
                // 内层循环，找到此循环中最小值的索引
                for (int j = i + 1; j < length; j++)
                {
                    // 用内层循环的每一个值与当前的最小值进行比较
                    // 如果小则更新最小值索引
                    if (nums[j] < nums[minIndex])
                    {
                        minIndex = j;
                    }
                }

                // 将最小值与此循环第一个值进行置换
                int tmp = nums[i];
                nums[i] = nums[minIndex];
                nums[minIndex] = tmp;
            }
        }

        /// <summary>
        /// 插入排序
        /// </summary>
        /// <param name="nums"></param>
        public static void InsertionSort(int[] nums)
        {
            // 空数组直接退出
            if (nums == null || nums.Length == 0)
            {
                return;
            }

            // 数组长度
            int length = nums.Length;

            // 将数组分为两部分，左半部分为已排序部分，右半部分为未排序部分
            // 默认第一个元素为左半部分已排序部分，剩下的为右半部分未排序部分
            // 外层循环遍历右半部分
            for (int i = 1; i < length; i++)
            {
                // 当前待插入的值
                int current = nums[i];
                
                // 内层循环遍历左半部分，从右向左遍历
                // 每次遍历判断当前待插入的值是否小于当前值
                // 如果小于当前值，则当前值向后移动一位
                int j = i - 1;
                while (j >= 0 && nums[j] > current)
                {
                    nums[j + 1] = nums[j];
                    j--;
                }

                // 循环结束，找到合适的插入数据的位置，将待插入的值插入
                nums[j + 1] = current;
            }
        }

        /// <summary>
        /// 希尔排序
        /// </summary>
        /// <param name="nums"></param>
        public static void ShellSort(int[] nums)
        {
            // 空数组直接退出
            if (nums == null || nums.Length == 0)
            {
                return;
            }
            
            // 数组长度
            int length = nums.Length;

            // 将数组每次增量/2的方式，分成多个序列
            for (int step = length / 2; step > 0; step /= 2)
            {
                // 对相同序列的数值采用插入排序的方式处理
                for (int i = step; i < length; i++)
                {
                    int current = nums[i];
                    int j = i - step;

                    while (j >= 0 && nums[j] > current)
                    {
                        nums[j + step] = nums[j];
                        j -= step;
                    }

                    nums[j + step] = current;
                }
            }
        }
        
        /// <summary>
        /// 归并排序（非递归版）
        /// </summary>
        /// <param name="nums"></param>
        public static void MergeSortNonRecursion(int[] nums)
        {
            // 空数组直接退出
            if (nums == null || nums.Length == 0)
            {
                return;
            }
            
            // 数组长度
            int length = nums.Length;
            // 相同大小的辅助数组
            int[] tmpArr = new int[length];
            
            // 从增量为1开始，一次归并，增量变为原来的两倍
            for (int step = 1; step < length; step *= 2)
            {
                // 遍历切分出来的多个子序列
                for (int i = 0; i <= length - step - 1; i += step * 2)
                {
                    int left = i;
                    int mid = i + step - 1;
                    int right = i + step * 2 - 1;

                    // 最后一个序列的right值超过数组的总大小，以数组最后一个元素为准
                    if (right > length - 1)
                    {
                        right = length - 1;
                    }

                    Merge(nums, left, mid, right, tmpArr);
                }
            }
        }

        /// <summary>
        /// 归并排序（递归版）
        /// </summary>
        /// <param name="nums"></param>  
        public static void MergeSortRecursion(int[] nums)
        {
            // 空数组直接退出
            if (nums == null || nums.Length == 0)
            {
                return;
            }

            // 相同大小的辅助数组
            int[] tmpArr = new int[nums.Length];
            MergeSortRecursion(nums, 0, nums.Length - 1, tmpArr);
        }

        private static void MergeSortRecursion(int[] nums, int left, int right, int[] tmpArr)
        {
            // 当前区间只剩一个元素，或者没有元素则直接返回
            if (left >= right)
            {
                return;
            }

            // 计算中点
            int mid = left + (right - left) / 2;
            
            // 左边归并排序，使左子序列有序
            MergeSortRecursion(nums, left, mid, tmpArr);
            // 右边归并排序，使右子序列有序
            MergeSortRecursion(nums, mid + 1, right, tmpArr);
            
            // 合并左右两个序列
            Merge(nums, left, mid, right, tmpArr);
        }

        private static void Merge(int[] nums, int left, int mid, int right, int[] tmpArr)
        {
            // 左序列指针
            int lPoint = left;
            // 右序列指针
            int rPoint = mid + 1;
            // 辅助数组指针
            int k = 0;

            // 左右序列的两个指针在当前范围内
            while (lPoint <= mid && rPoint <= right)
            {
                // 左序列的值小于右序列的值，则把左序列的值写入辅助数组，同时左序列指针右移
                // 否则就把右序列的值写入辅助数组，同时右序列右移
                if (nums[lPoint] <= nums[rPoint])
                {
                    tmpArr[k++] = nums[lPoint++];
                }
                else
                {
                    tmpArr[k++] = nums[rPoint++];
                }
            }
            
            // 右序列已写完，则把左序列剩下的元素写入辅助数组
            while(lPoint <= mid)
            {
                tmpArr[k++] = nums[lPoint++];
            }

            // 左序列已写完，则把右序列剩下的元素写入辅助数组
            while (rPoint <= right)
            {
                tmpArr[k++] = nums[rPoint++];
            }

            // 将辅助数组的元素拷贝回原数组
            k = 0;
            while (left <= right)
            {
                nums[left++] = tmpArr[k++];
            }
        }

        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="nums"></param>
        public static void QuickSort(int[] nums)
        {
            // 空数组直接退出
            if (nums == null || nums.Length == 0)
            {
                return;
            }

            // 数值的长度
            int length = nums.Length;
            QuickSort(nums, 0, length - 1);
        }

        private static void QuickSort(int[] nums, int left, int right)
        {
            // 当左右两个指针重叠的时候，直接返回
            if (left >= right)
            {
                return;
            }

            // 找出基准
            int partitionIndex = Partition(nums, left, right);
            // 对基准左边的序列进行排序
            QuickSort(nums, left, partitionIndex - 1);
            // 对基准右边的序列进行排序
            QuickSort(nums, partitionIndex + 1, right);
        }

        private static int Partition(int[] nums, int left, int right)
        {
            // 第一条数据作为基准数据
            int pivot = nums[left];
            // 左指针
            int lPoint = left;
            // 右指针
            int rPoint = right;

            // 找出序列中的第一个数作为基准
            // 将数据分为两个区域，比基准小的放在左边区域，比基准大的放在右边区域
            while (lPoint != rPoint)
            {
                // 右指针向前移动，只到找到小于基准的数值停下来
                while (nums[rPoint] >= pivot && lPoint < rPoint)
                {
                    rPoint--;
                }

                // 左指针向后移动，只到找到大于基准的数值停下来
                while (nums[lPoint] <= pivot && lPoint < rPoint)
                {
                    lPoint++;
                }

                // 如果左右指针没有重叠，则置换两个指针对应的值
                if (lPoint < rPoint)
                {
                    int tmp = nums[lPoint];
                    nums[lPoint] = nums[rPoint]; 
                    nums[rPoint] = tmp;
                }
            }

            // 左右指针重叠后，重叠的位置就是基准数据的位置
            // 将基准数据和重叠点的数据进行置换
            nums[left] = nums[lPoint];
            nums[lPoint] = pivot;

            return lPoint;
        }

        /// <summary>
        /// 堆排序
        /// </summary>
        /// <param name="nums"></param>
        public static void HeapSort(int[] nums)
        {
            // 空数组直接退出
            if (nums == null || nums.Length == 0)
            {
                return;
            }
            
            // 数组的长度
            int length = nums.Length;

            // 构建大顶堆
            // 第一个非叶子结点：length / 2 - 1
            // 构建大顶堆的方式为从第一个非叶子结点从下至上，从右至左调整
            for (int i = length / 2 - 1; i >= 0; i--)
            {
                HeapAdjust(nums, i, length);
            }
            
            // 调整大顶堆结果，将堆顶元素与末尾元素进行交换
            // 这样最大值就排列到尾部，然后对剩下部分重新进行堆调整
            for (int i = length - 1; i > 0; i--)
            {
                // 将最大值置换到尾部
                int tmp = nums[0];
                nums[0] = nums[i];
                nums[i] = tmp;
                
                // 对剩下部分重新进行堆调整
                HeapAdjust(nums, 0, i);
            }
            
        }

        /// <summary>
        /// 调整大顶堆
        /// 大顶堆：arr[i] >= arr[2i+1] && arr[i] >= arr[2i+2]
        /// 小顶堆：arr[i] <= arr[2i+1] && arr[i] <= arr[2i+2]  
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="currentNodeIndex"></param>
        /// <param name="length"></param>
        private static void HeapAdjust(int[] nums, int currentNodeIndex, int length)
        {
            int currentNode = nums[currentNodeIndex];

            // 从当前结点的左子结点开始
            for (int i = currentNodeIndex * 2 + 1; i < length; i = i * 2 + 1)
            {
                // 如果存在右结点，并且左子结点的数据小于右子节点的数据，将指针指向右结点
                if (i + 1 < length && nums[i] < nums[i + 1])
                {
                    i++;
                }

                // 如果子节点的数据大于当前结点的数据，将子节点的数据置换给当前结点
                if (nums[i] > currentNode)
                {
                    nums[currentNodeIndex] = nums[i];
                    currentNodeIndex = i;
                }
                else
                {
                    break;
                }
            }

            nums[currentNodeIndex] = currentNode;
        }

        /// <summary>
        /// 计数排序
        /// </summary>
        /// <param name="nums"></param>
        public static void CountingSort(int[] nums)
        {
            // 空数组直接退出
            if (nums == null || nums.Length == 0)
            {
                return;
            }
            
            // 数组的长度
            int length = nums.Length;

            // 数组最小值，默认数组第一个元素
            int minValue = nums[0];
            // 数组最大值，默认数组第一个元素
            int maxValue = nums[0];

            for (int i = 0; i < length; i++)
            {
                // 找出数组中的最小值
                if (nums[i] < minValue)
                {
                    minValue = nums[i];
                }

                // 找出数组中的最大值
                if (nums[i] > maxValue)
                {
                    maxValue = nums[i];
                }
            }

            // 构建计数桶的大小，为数组最大值与最小值之差+1
            int[] bucket = new int[maxValue - minValue + 1];

            // 对数组中的每个数字进行计数，相同的数字会统计到一起
            for (int i = 0; i < length; i++)
            {
                // 数组中的数字与桶中的下标不是直接对应的
                // 而是用数组中的数字与最小值的偏移量找到对应桶的下标
                bucket[nums[i] - minValue]++;
            }

            // 原数组下标
            int k = 0;
            
            // 将桶中排好序的数据回写回原数组
            // 外层循环遍历桶的每一条数据
            for (int i = 0; i < bucket.Length; i++)
            {
                // 内层循环遍历计数数量
                for (int j = 0; j < bucket[i]; j++)
                {
                    // 原数组的索引是桶当前索引+计数索引
                    // 对应的数据则是最小数据+桶当前索引（偏移量）
                    nums[k] = minValue + i;
                    k++;
                }
            }
        }
    }
}