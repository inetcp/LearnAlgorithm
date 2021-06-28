using System;
using System.Diagnostics;
using System.Linq;
using LearnAlgorithm.Algorithms;
using Xunit;
using Xunit.Abstractions;

namespace LearnAlgorithm.UnitTest.AlgorithmsTests
{
    public class SortingTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        private delegate void SortHandler(int[] nums);
        
        public SortingTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        private int[] GetRandomData(int maxValue)
        {
            return Enumerable.Range(1, maxValue).OrderBy(p => Guid.NewGuid()).ToArray();
        }

        private void Sort_Test(SortHandler sortHandler)
        {
            int[] testData = null;
            int[] expectedData = null;
            sortHandler(testData);
            Assert.Equal(expectedData, testData);

            testData = new int[0];
            expectedData = new int[0];
            sortHandler(testData);
            Assert.Equal(expectedData, testData);
            
            testData = new int[] { 1 };
            expectedData = new int[] { 1 };
            sortHandler(testData);
            Assert.Equal(expectedData, testData);
            
            testData = new int[] { 2, 1 };
            expectedData = new int[] { 1, 2 };
            sortHandler(testData);
            Assert.Equal(expectedData, testData);
            
            testData = new int[] { 2, 1, 3 };
            expectedData = new int[] { 1, 2, 3 };
            sortHandler(testData);
            Assert.Equal(expectedData, testData);
            
            testData = new int[] { 4, 1, 3, 2 };
            expectedData = new int[] { 1, 2, 3, 4 };
            sortHandler(testData);
            Assert.Equal(expectedData, testData);
            
            testData = new int[] { 8, 1, 4, 1, 3, 2 };
            expectedData = new int[] { 1, 1, 2, 3, 4, 8 };
            sortHandler(testData);
            Assert.Equal(expectedData, testData);

            testData = GetRandomData(10000);
            expectedData = testData.OrderBy(p => p).ToArray();
            sortHandler(testData);
            Assert.Equal(expectedData, testData);
        }

        private void SortExecutionTimeTest(Stopwatch sw, int[] randomData, SortHandler sortHandler, string sortHandlerName)
        {
            var testData = (int[]) randomData.Clone();
            sw.Restart();
            sortHandler(testData);
            sw.Stop();
            _testOutputHelper.WriteLine((sortHandlerName + "耗时: ").PadRight(20, ' ') + sw.Elapsed);
        }

        [Fact]
        public void SortExecutionTime_Test()
        {
            int maxCount = 50;
            int[] randomData = GetRandomData(maxCount);

            _testOutputHelper.WriteLine("样本数据，大小为：" + maxCount);

            var sw = new Stopwatch();
            SortExecutionTimeTest(sw, randomData, Sorting.BubbleSort, "冒泡排序");
            SortExecutionTimeTest(sw, randomData, Sorting.SelectionSort, "选择排序");
            SortExecutionTimeTest(sw, randomData, Sorting.InsertionSort, "插入排序");
            SortExecutionTimeTest(sw, randomData, Sorting.ShellSort, "希尔排序");
            SortExecutionTimeTest(sw, randomData, Sorting.MergeSortRecursion, "归并排序(递归版)");
            SortExecutionTimeTest(sw, randomData, Sorting.MergeSortNonRecursion, "归并排序(非递归版)");
            SortExecutionTimeTest(sw, randomData, Sorting.QuickSort, "快速排序");
            SortExecutionTimeTest(sw, randomData, Sorting.HeapSort, "堆排序");
            SortExecutionTimeTest(sw, randomData, Sorting.CountingSort, "计数排序");
            SortExecutionTimeTest(sw, randomData, Sorting.BucketSort, "桶排序");
        }
        

        [Fact]
        public void BubbleSort_Test()
        {
            Sort_Test(Sorting.BubbleSort);
        }
        
        [Fact]
        public void SelectionSort_Test()
        {
            Sort_Test(Sorting.SelectionSort);
        }
        
        [Fact]
        public void InsertionSort_Test()
        {
            Sort_Test(Sorting.InsertionSort);
        }
        
        [Fact]
        public void ShellSort_Test()
        {
            Sort_Test(Sorting.ShellSort);
        }
        
        [Fact]
        public void MergeSortRecursion_Test()
        {
            Sort_Test(Sorting.MergeSortRecursion);
        }
        
        [Fact]
        public void MergeSortNonRecursion_Test()
        {
            Sort_Test(Sorting.MergeSortNonRecursion);
        }
        
        [Fact]
        public void QuickSort_Test()
        {
            Sort_Test(Sorting.QuickSort);
        }
        
        [Fact]
        public void HeapSort_Test()
        {
            Sort_Test(Sorting.HeapSort);
        }
        
        [Fact]
        public void CountingSort_Test()
        {
            Sort_Test(Sorting.CountingSort);
        }
        
        [Fact]
        public void BucketSort_Test()
        {
            Sort_Test(Sorting.BucketSort);
        }
    }
}