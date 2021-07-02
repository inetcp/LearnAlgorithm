using System;
using LearnAlgorithm.DataStructures.LinearList;
using Xunit;
using Xunit.Abstractions;

namespace LearnAlgorithm.UnitTest.DataStructuresTests
{
    public class SequenceListTest
    {
        [Fact]
        public void Test()
        {
            SequenceList<int> list = new SequenceList<int>(5);
            
            // 1, 2, 3, 4
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            Assert.Equal(4, list.Length);
            Assert.Equal(2, list[1]);

            // 1, 2, 3, 4
            // 1, 2, 3, 5
            list[3] = 5;
            Assert.Equal(4, list.Length);
            Assert.Equal(5, list[3]);
            
            // 1,    2, 3, 5
            // 1, 8, 2, 3, 5
            list.Insert(1, 8);
            Assert.Equal(5, list.Length);
            Assert.Equal(8, list[1]);
            Assert.Equal(2, list[2]);

            // 1, 8, 2, 3, 5
            // 1,    2, 3, 5
            int removedItem = list.RemoveAt(1);
            Assert.Equal(4, list.Length);
            Assert.Equal(8, removedItem);
            Assert.Equal(2, list[1]);
            
            list.Clear();
            Assert.Equal(0, list.Length);
        }
    }
}