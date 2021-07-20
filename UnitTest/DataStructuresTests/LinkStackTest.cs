using LearnAlgorithm.DataStructures.LinearList;
using LearnAlgorithm.DataStructures.LinearList.Stack;
using Xunit;

namespace LearnAlgorithm.UnitTest.DataStructuresTests
{
    public class LinkStackTest
    {
        [Fact]
        public void Test()
        {
            LinkStack<int> stack = new LinkStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            
            Assert.Equal(3, stack.Pop());
            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Pop());
            
            stack.Push(1);
            stack.Push(2);
            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Pop());
            
            stack.Push(3);
            Assert.Equal(3, stack.Pop());
        }
    }
}