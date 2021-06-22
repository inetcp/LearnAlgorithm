using LearnAlgorithm.Algorithms;
using Xunit;

namespace LearnAlgorithm.UnitTest.AlgorithmsTests
{
    public class SortingTests
    {
        [Fact]
        public void BubbleSorting_Test()
        {
            int[] testData = new[] { 1, 7, 3, 4, 11, 6 };
            int[] expectedData = new[] { 1, 3, 4, 6, 7, 11 };
            
            Sorting.BubbleSorting(testData);
            Assert.Equal(testData, expectedData);
        }
        
        [Fact]
        public void SelectionSorting_Test()
        {
            int[] testData = new[] { 1, 7, 3, 4, 11, 6 };
            int[] expectedData = new[] { 1, 3, 4, 6, 7, 11 };
            
            Sorting.SelectionSorting(testData);
            Assert.Equal(testData, expectedData);
        }
        
        [Fact]
        public void InsertionSorting_Test()
        {
            int[] testData = new[] { 1, 7, 3, 4, 11, 6 };
            int[] expectedData = new[] { 1, 3, 4, 6, 7, 11 };
            
            Sorting.InsertionSorting(testData);
            Assert.Equal(testData, expectedData);
        }
        
        [Fact]
        public void ShellSorting_Test()
        {
            int[] testData = new[] { 1, 7, 3, 4, 11, 6 };
            int[] expectedData = new[] { 1, 3, 4, 6, 7, 11 };
            
            Sorting.ShellSorting(testData);
            Assert.Equal(testData, expectedData);
        }
    }
}