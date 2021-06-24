using LearnAlgorithm.Algorithms;
using Xunit;
using Xunit.Abstractions;

namespace LearnAlgorithm.UnitTest.AlgorithmsTests
{
    public class SortingTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        
        public SortingTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        
        [Fact]
        public void BubbleSort_Test()
        {
            int[] testData = new[] { 1, 7, 3, 4, 11, 6 };
            int[] expectedData = new[] { 1, 3, 4, 6, 7, 11 };
            
            Sorting.BubbleSort(testData);
            Assert.Equal(testData, expectedData);
        }
        
        [Fact]
        public void SelectionSort_Test()
        {
            int[] testData = new[] { 1, 7, 3, 4, 11, 6 };
            int[] expectedData = new[] { 1, 3, 4, 6, 7, 11 };
            
            Sorting.SelectionSort(testData);
            Assert.Equal(testData, expectedData);
        }
        
        [Fact]
        public void InsertionSort_Test()
        {
            int[] testData = new[] { 1, 7, 3, 4, 11, 6 };
            int[] expectedData = new[] { 1, 3, 4, 6, 7, 11 };
            
            Sorting.InsertionSort(testData);
            Assert.Equal(testData, expectedData);
        }
        
        [Fact]
        public void ShellSort_Test()
        {
            int[] testData = new[] { 1, 7, 3, 4, 11, 6 };
            int[] expectedData = new[] { 1, 3, 4, 6, 7, 11 };
            
            Sorting.ShellSort(testData);
            Assert.Equal(testData, expectedData);
        }
        
        [Fact]
        public void MergeSortRecursion_Test()
        {
            int[] testData = new[] { 1, 7, 3, 4, 11, 6, 2 };
            int[] expectedData = new[] { 1, 2, 3, 4, 6, 7, 11 };
            
            Sorting.MergeSortRecursion(testData);
            Assert.Equal(testData, expectedData);
        }
        
        [Fact]
        public void MergeSortNonRecursion_Test()
        {
            int[] testData = new[] { 1, 7, 3, 4, 11, 6, 2 };
            int[] expectedData = new[] { 1, 2, 3, 4, 6, 7, 11 };
            
            Sorting.MergeSortNonRecursion(testData);
            Assert.Equal(testData, expectedData);
        }
        
        [Fact]
        public void QuickSort_Test()
        {
            int[] testData = new[] { 1, 7, 3, 4, 11, 6, 2 };
            int[] expectedData = new[] { 1, 2, 3, 4, 6, 7, 11 };
            
            Sorting.QuickSort(testData);  
            Assert.Equal(testData, expectedData);
        }
        
        [Fact]
        public void HeapSort_Test()
        {
            int[] testData = new[] { 1, 7, 3, 4, 11, 6, 2 };
            int[] expectedData = new[] { 1, 2, 3, 4, 6, 7, 11 };
            
            Sorting.HeapSort(testData);  
            Assert.Equal(testData, expectedData);
        }
    }
}