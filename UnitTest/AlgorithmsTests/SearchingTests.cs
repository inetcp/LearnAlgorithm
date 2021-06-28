using System;
using System.Diagnostics;
using System.Linq;
using LearnAlgorithm.Algorithms;
using Xunit;
using Xunit.Abstractions;

namespace LearnAlgorithm.UnitTest.AlgorithmsTests
{
    public class SearchingTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        private delegate int SearchHandler(int[] nums, int value);

        public SearchingTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        
        private int[] GetRandomData(int maxValue)
        {
            return Enumerable.Range(1, maxValue).OrderBy(p => Guid.NewGuid()).ToArray();
        }

        private void Search_Test(SearchHandler searchHandler)
        {
            Assert.Equal(-1, searchHandler(null, 1));
            Assert.Equal(2, searchHandler(new []{ 4, 1, 3, 2 }, 3));
            Assert.Equal(3, searchHandler(new []{ 4, 1, 3, 2 }, 2));
            Assert.Equal(-1, searchHandler(new []{ 4, 1, 3, 2 }, 5));
            Assert.Equal(1, searchHandler(new []{ 8, 1, 4, 1, 3, 2 }, 1));

            int maxCount = 10000;
            int[] randomData = GetRandomData(maxCount);
            int index = new Random().Next(0, maxCount - 1);
            int value = randomData[index];
            Assert.Equal(index, searchHandler(randomData, value));
        }
        
        private void SortedSearch_Test(SearchHandler searchHandler)
        {
            Assert.Equal(-1, searchHandler(null, 1));
            Assert.Equal(2, searchHandler(new []{ 1, 2, 3, 4 }, 3));
            Assert.Equal(1, searchHandler(new []{ 1, 2, 3, 4 }, 2));
            Assert.Equal(-1, searchHandler(new []{ 1, 2, 3, 4 }, 5));
            // Assert.Equal(0, searchHandler(new []{ 1, 1, 2, 3, 4, 8 }, 1));

            int maxCount = 10000;
            int[] randomData = GetRandomData(maxCount);
            randomData = randomData.OrderBy(p => p).ToArray();
            int index = new Random().Next(0, maxCount - 1);
            int value = randomData[index];
            Assert.Equal(index, searchHandler(randomData, value));
        }
        
        private void SearchExecutionTimeTest(Stopwatch sw, int[] randomData, int value, SearchHandler searchHandler, string searchHandlerName)
        {
            sw.Restart();
            searchHandler(randomData, value);
            sw.Stop();
            _testOutputHelper.WriteLine((searchHandlerName + "耗时: ").PadRight(20, ' ') + sw.Elapsed);
        }
        
        [Fact]
        public void SearchExecutionTime_Test()
        {
            int maxCount = 10000000;
            int[] randomData = GetRandomData(maxCount);
            int index = new Random().Next(0, maxCount - 1);
            int value = randomData[index];

            int[] sortedData = ((int[]) randomData.Clone()).OrderBy(p => p).ToArray();
            int sortedValue = sortedData[index];

            _testOutputHelper.WriteLine("样本数据，大小为：" + maxCount);
            _testOutputHelper.WriteLine("");
            _testOutputHelper.WriteLine("非排序版本：");
            var sw = new Stopwatch();
            SearchExecutionTimeTest(sw, randomData, value, Searching.SequenceSearch, "顺序查找");
            
            _testOutputHelper.WriteLine("");
            _testOutputHelper.WriteLine("排序版本：");
            SearchExecutionTimeTest(sw, sortedData, sortedValue, Searching.SequenceSearch, "顺序查找");
            SearchExecutionTimeTest(sw, sortedData, sortedValue, Searching.BinarySearchRecursion, "顺序查找(递归版)");
            SearchExecutionTimeTest(sw, sortedData, sortedValue, Searching.BinarySearchNonRecursion, "顺序查找(非递归版)");
        }
        
        [Fact]
        public void SequenceSearch_Test()
        {
            Search_Test(Searching.SequenceSearch);
        }

        [Fact]
        public void BinarySearchNonRecursion_Test()
        {
            SortedSearch_Test(Searching.BinarySearchNonRecursion);
        }
        
        [Fact]
        public void BinarySearchRecursion_Test()
        {
            SortedSearch_Test(Searching.BinarySearchRecursion);
        }
    }
}