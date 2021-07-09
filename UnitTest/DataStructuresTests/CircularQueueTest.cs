﻿using LearnAlgorithm.DataStructures.LinearList;
using Xunit;

namespace LearnAlgorithm.UnitTest.DataStructuresTests
{
    public class CircularQueueTest
    {
        [Fact]
        public void Test()
        {
            CircularQueue<int> stack = new CircularQueue<int>();
            stack.EnQueue(1);
            stack.EnQueue(2);
            stack.EnQueue(3);
            
            Assert.Equal(1, stack.DeQueue());
            Assert.Equal(2, stack.DeQueue());
            Assert.Equal(3, stack.DeQueue());
            
            stack.EnQueue(1);
            stack.EnQueue(2);
            Assert.Equal(1, stack.DeQueue());
            Assert.Equal(2, stack.DeQueue());
            
            stack.EnQueue(3);
            Assert.Equal(3, stack.DeQueue());
        }
    }
}