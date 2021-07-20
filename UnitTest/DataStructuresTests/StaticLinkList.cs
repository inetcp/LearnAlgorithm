using LearnAlgorithm.DataStructures.LinearList;
using LearnAlgorithm.DataStructures.LinearList.List;
using Xunit;

namespace LearnAlgorithm.UnitTest.DataStructuresTests
{
    public class StaticLinkListTest
    {
        [Fact]
        public void Test()
        {
            StaticLinkList<int> list = new StaticLinkList<int>();
            Assert.Equal(0, list.Length);

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
        }
    }
}