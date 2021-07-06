using LearnAlgorithm.DataStructures.LinearList;
using Xunit;

namespace LearnAlgorithm.UnitTest.DataStructuresTests
{
    public class DoubleShareStackTest
    {
        [Fact]
        public void Test()
        {
            DoubleShareStack<int> stack = new DoubleShareStack<int>();
            stack.Push(1, 1);
            stack.Push(2, 1);
            stack.Push(3, 1);
            stack.Push(4, 2);
            stack.Push(5, 2);
            stack.Push(6, 2);
            
            Assert.Equal(3, stack.Pop(1));
            Assert.Equal(2, stack.Pop(1));
            Assert.Equal(1, stack.Pop(1));
            Assert.Equal(6, stack.Pop(2));
            Assert.Equal(5, stack.Pop(2));
            Assert.Equal(4, stack.Pop(2));
        }
    }
}