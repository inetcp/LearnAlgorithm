using LearnAlgorithm.Algorithms;
using Xunit;

namespace LearnAlgorithm.UnitTest.AlgorithmsTests
{
    public class FibonacciTest
    {
        [Fact]
        public void Test()
        {
            Fibonacci f = new Fibonacci();
            Assert.Equal(0, f.FibonacciNonRecursion(0));
            Assert.Equal(1, f.FibonacciNonRecursion(1));
            Assert.Equal(1, f.FibonacciNonRecursion(2));
            Assert.Equal(13, f.FibonacciNonRecursion(7));
            
            Assert.Equal(0, f.FibonacciWithRecursion(0));
            Assert.Equal(1, f.FibonacciWithRecursion(1));
            Assert.Equal(1, f.FibonacciWithRecursion(2));
            Assert.Equal(13, f.FibonacciWithRecursion(7));
        }
    }
}