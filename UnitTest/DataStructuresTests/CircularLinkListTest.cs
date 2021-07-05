using LearnAlgorithm.DataStructures.LinearList;
using Xunit;

namespace LearnAlgorithm.UnitTest.DataStructuresTests
{
    public class CircularLinkListTest
    {
        [Fact]
        public void Test()
        {
            CircularLinkList<int> list = new CircularLinkList<int>();
            Assert.Equal(0, list.Length);
            Assert.Null(list.Rear);
            
            // 1 <- 2 <- 3 <- 4
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            Assert.Equal(4, list.Length);
            Assert.Equal(2, list[1]);

            // 1 <- 2  <- 3 <- 4
            // 1 <- 20 <- 3 <- 4
            list[1] = 20;
            Assert.Equal(4, list.Length);
            Assert.Equal(20, list[1]);
            
            // 1 <- 20      <- 3 <- 4
            // 1 <- 20 <- 5 <- 3 <- 4
            list.Insert(2, 5);
            Assert.Equal(5, list.Length);
            Assert.Equal(5, list[2]);
            Assert.Equal(3, list[3]);

            // 1 <- 20 <- 5 <- 3 <- 4
            //      20 <- 5 <- 3 <- 4
            list.RemoveAt(0);
            Assert.Equal(4, list.Length);
            Assert.Equal(20, list[0]);
            
            // 20 <- 5 <- 3 <- 4
            // 20 <- 5      <- 4
            list.RemoveAt(2);
            Assert.Equal(3, list.Length);
            Assert.Equal(4, list[2]);
            
            list.Clear();
            Assert.Equal(0, list.Length);
            Assert.Null(list.Rear);
        }
    }
}