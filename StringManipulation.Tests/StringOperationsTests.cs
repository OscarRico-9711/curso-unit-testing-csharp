using Microsoft.Extensions.Logging;
using Moq;

namespace StringManipulation.Tests
{
    public class StringOperationsTests
    {
        private readonly StringOperations stringOperations;

        public StringOperationsTests()
        {
            stringOperations = new StringOperations();
        }

        [Theory]
        [InlineData("perpetuo", "Beats", "perpetuo Beats")]
        [InlineData("sonido", "perpetuo", "sonido perpetuo")]
        [InlineData("texto 1", "texto 2", "texto 1 texto 2")]
        public void ConcatenateStrings(string string1, string string2, string expected)
        {
            var result = stringOperations.ConcatenateStrings(string1, string2);

            Assert.Equal($"{expected}", result);
        }

        [Fact]
        public void ReverseString()
        {
            var result = stringOperations.ReverseString("Perpetuo Beatss");
            Assert.Equal("sstaeB outepreP", result);
        }

        [Fact]
        public void GetStringLength()
        {
            var result = stringOperations.GetStringLength("perpetuo Beats");
            Assert.Equal(14, result);
        }

        [Fact]
        public void RemoveWhitespace()
        {
            var result = stringOperations.RemoveWhitespace("Perpetuo Beatsss");
            Assert.Equal("PerpetuoBeatsss", result);
        }

        [Fact]
        public void TruncateString()
        {
            var result = stringOperations.TruncateString("Perpetuo Beats", 2);
            Assert.Equal("Pe", result);
        }

        [Fact]
        public void IsPalindrome()
        {
            var result = stringOperations.IsPalindrome("rajar");
            Assert.Equal(true, result);
            Assert.NotNull(result);

        }

        [Fact]
        public void CountOccurrences()
        {
            var moqlogger = new Mock<ILogger<StringOperations>>();
            var objcountletters = new StringOperations(moqlogger.Object);

            var result = objcountletters.CountOccurrences("Perpetuo Beats", 'e');
            Assert.Equal(3, result);
        }

        [Fact]
        public void Pluralize()
        {
            var result = stringOperations.Pluralize("car");
            Assert.Equal("cars", result);

        }

        [Fact]
        public void QuantintyInWords()
        {
            var result = stringOperations.QuantintyInWords("car", 7);
            Assert.Equal("seven cars", result);

        }

        [Fact]
        public void ReadFile()
        {
            var objReadFile = new StringOperations();
            var objmoq = new Mock<IFileReaderConector>();
            objmoq.Setup(p => p.ReadString("file.txt")).Returns("TEXTO FALSO");

            var result = objReadFile.ReadFile(objmoq.Object, "file.txt");
            Assert.Equal("TEXTO FALSO", result);

        }




    }

}
