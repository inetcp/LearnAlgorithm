using LearnAlgorithm.Algorithms;
using Xunit;
using Xunit.Abstractions;

namespace LearnAlgorithm.UnitTest.DataStructuresTests
{
    public class ArithmeticTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        
        
        public ArithmeticTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        
        [Fact]
        public void Convert_Test()
        {
            Arithmetic arithmetic = new Arithmetic();
            string testData = "9+(3-1)*3+10/2";
            string expectedData = "9 3 1 - 3 * + 10 2 / +";
            string actualData = arithmetic.Convert(testData);
            
            _testOutputHelper.WriteLine(testData);
            _testOutputHelper.WriteLine(actualData);
            Assert.Equal(expectedData, actualData);
            
            testData = "9/(3-2*1)*3+10/2";
            expectedData = "9 3 2 1 * - / 3 * 10 2 / +";
            _testOutputHelper.WriteLine("");
            _testOutputHelper.WriteLine(testData);
            actualData = arithmetic.Convert(testData);
            
            _testOutputHelper.WriteLine(actualData);
            Assert.Equal(expectedData, actualData);
        }
        
        [Fact]
        public void Caculate_Test()
        {
            Arithmetic arithmetic = new Arithmetic();
            string testData = "9+(3-1)*3+10/2";
            int expectedData = 20;
            int actualData = arithmetic.Calculate(testData);
            
            _testOutputHelper.WriteLine(testData);
            _testOutputHelper.WriteLine(actualData.ToString());
            Assert.Equal(expectedData, actualData);
            
            testData = "9/(3-2*1)*3+10/2";
            expectedData = 32;
            actualData = arithmetic.Calculate(testData);
            
            _testOutputHelper.WriteLine("");
            _testOutputHelper.WriteLine(testData);
            _testOutputHelper.WriteLine(actualData.ToString());
            Assert.Equal(expectedData, actualData);
        }
    }
} 