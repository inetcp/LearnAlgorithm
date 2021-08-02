using LearnAlgorithm.DataStructures.Tree;
using Xunit;
using Xunit.Abstractions;

namespace LearnAlgorithm.UnitTest.DataStructuresTests
{
    public class CTreeTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        
        public CTreeTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        
        [Fact]
        public void Test()
        {
            CTree<int> tree = new CTree<int>(1, 10);
            
            var parent2 = tree.AddNode(2, tree.Root);
            var parent3 = tree.AddNode(3, tree.Root);

            tree.AddNode(4, parent2);
            tree.AddNode(5, parent2);

            tree.AddNode(6, parent3);
            tree.AddNode(7, parent3);
            tree.AddNode(8, parent3);

            _testOutputHelper.WriteLine($"树的节点数量：{tree.Count}");
            _testOutputHelper.WriteLine($"树的根节点：{tree.Root.Data}");
            _testOutputHelper.WriteLine("");
            _testOutputHelper.WriteLine("树的全部节点：");
            foreach (var node in tree.GetChilds())
            {
                _testOutputHelper.WriteLine($"节点数据：{node.Data}，父节点index：{node.ParentIndex}");
            }
            _testOutputHelper.WriteLine("");
            _testOutputHelper.WriteLine($"节点数据为“{parent2.Data}”的子节点为：");
            foreach (var node in tree.GetChilds(parent2))
            {
                _testOutputHelper.WriteLine($"节点数据：{node.Data}，父节点index：{node.ParentIndex}");
            }
            _testOutputHelper.WriteLine("");
            _testOutputHelper.WriteLine($"节点数据为“{parent3.Data}”的子节点为：");
            foreach (var node in tree.GetChilds(parent3))
            {
                _testOutputHelper.WriteLine($"节点数据：{node.Data}，父节点index：{node.ParentIndex}");
            }
        }
    }
}