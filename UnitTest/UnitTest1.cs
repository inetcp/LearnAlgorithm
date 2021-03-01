using System;
using Xunit;
using Xunit.Abstractions;

namespace LearnAlgorithm.UnitTest
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public UnitTest1(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void Test1()
        {
            _testOutputHelper.WriteLine("Test1");
        }
    }
}