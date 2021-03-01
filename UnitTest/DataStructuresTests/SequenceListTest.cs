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
            SequenceList<int> s = new SequenceList<int>(5);
            s.Add(1);
            s.Add(2);
            s.Add(3);
            s.Add(4);
            Assert.Equal(4, s.Length);

            Assert.Equal(2, s.GetElement(1));
            
            s.Insert(1, 8);
            Assert.Equal(5, s.Length);
            Assert.Equal(2, s.GetElement(2));

            int removedItem = s.RemoveAt(1);
            Assert.Equal(8, removedItem);
            Assert.Equal(4, s.Length);
            Assert.Equal(2, s.GetElement(1));
        }
    }
}