using LearnAlgorithm.DataStructures.String;
using Xunit;

namespace LearnAlgorithm.UnitTest.StringTests
{
    public class SequenceStringTest
    {
        [Fact]
        public void Test()
        {
            SequenceString str = new SequenceString(new char[]{ 'h', 'e', 'l', 'l', 'o' });
            
            Assert.Equal(5, str.Length);
            Assert.Equal('e', str[1]);
            Assert.Equal(0, str.Compare(new SequenceString(new char[]{ 'h', 'e', 'l', 'l', 'o' })));
            Assert.Equal(1, str.Compare(new SequenceString(new char[]{ 'h', 'e' })));
            Assert.Equal(-1, str.Compare(new SequenceString(new char[]{ 'h', 'e', 'l', 'l', 'o', 'w' })));
            Assert.Equal(1, str.Compare(new SequenceString(new char[]{ 'a', 'b', 'c' })));
            Assert.Equal(-1, str.Compare(new SequenceString(new char[]{ 'x', 'y', 'z' })));

            var testStr = str.SubString(1, 2);
            Assert.Equal(2, testStr.Length);
            Assert.Equal('e', testStr[0]);
            Assert.Equal('l', testStr[1]);

            testStr = str.Concat(new SequenceString(new char[] {'w', 'o'}));
            Assert.Equal(7, testStr.Length);
            Assert.Equal('w', testStr[5]);
            Assert.Equal('o', testStr[6]);

            testStr = str.Insert(1, new SequenceString(new char[] {'w', 'o'}));
            Assert.Equal(7, testStr.Length);
            Assert.Equal('w', testStr[1]);
            Assert.Equal('o', testStr[2]);
            Assert.Equal('e', testStr[3]);

            testStr = str.Delete(1, 1);
            Assert.Equal(4, testStr.Length);
            Assert.Equal('l', testStr[1]);
            
            Assert.Equal(0, str.IndexOf(new SequenceString(new []{'h'})));
            Assert.Equal(0, str.IndexOf(new SequenceString(new []{'h', 'e'})));
            Assert.Equal(2, str.IndexOf(new SequenceString(new []{'l', 'l'})));
            Assert.Equal(-1, str.IndexOf(new SequenceString(new []{'w', 'o'})));
            
            Assert.Equal(0, str.BfIndexOf(new SequenceString(new []{'h'})));
            Assert.Equal(0, str.BfIndexOf(new SequenceString(new []{'h', 'e'})));
            Assert.Equal(2, str.BfIndexOf(new SequenceString(new []{'l', 'l'})));
            Assert.Equal(-1, str.BfIndexOf(new SequenceString(new []{'w', 'o'})));
        }
    }
}