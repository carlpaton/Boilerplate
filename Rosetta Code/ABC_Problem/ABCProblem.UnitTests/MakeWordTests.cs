using System.Collections.Generic;
using Xunit;

namespace ABCProblem.UnitTests
{
    public class MakeWordTests
    {
        private List<string> _blocks;

        public MakeWordTests()
        {
            _blocks = new List<string>() { "B O", "X K", "D Q", "C P", "N A", "G T", "R E", "T G", "Q D", "F S", "J W", "H U", "V I", "A N", "O B", "E R", "F S", "L Y", "P C", "Z M" };
        }

        [Theory]
        [InlineData(true, "A")]
        [InlineData(true, "BARK")]
        [InlineData(true, "bark")]
        [InlineData(true, "Bark")]
        [InlineData(false, "BOOK")]
        [InlineData(true, "TREAT")]
        [InlineData(false, "COMMON")]
        [InlineData(true, "SQUAD")]
        [InlineData(true, "CONFUSE")]
        [InlineData(false, "KELVIN")]
        public void ForeachLoop(bool expected, string word)
        {
            // Arrange
            var classUnderTest = new MakeWord();

            // Act
            var actual = classUnderTest.ForeachLoop(word, _blocks);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(true, "A")]
        [InlineData(true, "BARK")]
        [InlineData(true, "bark")]
        [InlineData(true, "Bark")]
        [InlineData(false, "BOOK")]
        [InlineData(true, "TREAT")]
        [InlineData(false, "COMMON")]
        [InlineData(true, "SQUAD")]
        [InlineData(true, "CONFUSE")]
        [InlineData(false, "KELVIN")]
        public void ActionDelegate(bool expected, string word)
        {
            // Arrange
            var classUnderTest = new MakeWord();

            // Act
            var actual = classUnderTest.ActionDelegate(word, _blocks);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(true, "A")]
        [InlineData(true, "BARK")]
        [InlineData(true, "bark")]
        [InlineData(true, "Bark")]
        [InlineData(false, "BOOK")]
        [InlineData(true, "TREAT")]
        [InlineData(false, "COMMON")]
        [InlineData(true, "SQUAD")]
        [InlineData(true, "CONFUSE")]
        [InlineData(false, "KELVIN")]
        public void Regex(bool expected, string word)
        {
            // Arrange
            var classUnderTest = new MakeWord();
            var blocks2 = string.Join("|", _blocks.ToArray()).Replace(" ", "").Replace("|", " ");

            // Act
            var actual = classUnderTest.Regex(word, blocks2);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
