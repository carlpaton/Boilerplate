using NUnit.Framework;
using System.Collections.Generic;

namespace ABC_Problem
{
    [TestFixture]
    public class Tests
    {
        private List<string> _blocks;

        [SetUp]
        public void Setup()
        {
            _blocks = new List<string>() { "B O", "X K", "D Q", "C P", "N A", "G T", "R E", "T G", "Q D", "F S", "J W", "H U", "V I", "A N", "O B", "E R", "F S", "L Y", "P C", "Z M" };
        }

        [TestCase(true, "A")]
        [TestCase(true, "BARK")]
        [TestCase(true, "bark")]
        [TestCase(true, "Bark")]
        [TestCase(false, "BOOK")]
        [TestCase(true, "TREAT")]
        [TestCase(false, "COMMON")]
        [TestCase(true, "SQUAD")]
        [TestCase(true, "CONFUSE")]
        [TestCase(false, "KELVIN")]
        public void ForeachLoop(bool expected, string word)
        {
            // Arrange
            var classUnderTest = new MakeWord();

            // Act
            var actual = classUnderTest.ForeachLoop(word, _blocks);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(true, "A")]
        [TestCase(true, "BARK")]
        [TestCase(true, "bark")]
        [TestCase(true, "Bark")]
        [TestCase(false, "BOOK")]
        [TestCase(true, "TREAT")]
        [TestCase(false, "COMMON")]
        [TestCase(true, "SQUAD")]
        [TestCase(true, "CONFUSE")]
        [TestCase(false, "KELVIN")]
        public void ActionDelegate(bool expected, string word)
        {
            // Arrange
            var classUnderTest = new MakeWord();

            // Act
            var actual = classUnderTest.ActionDelegate(word, _blocks);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(true, "A")]
        [TestCase(true, "BARK")]
        [TestCase(true, "bark")]
        [TestCase(true, "Bark")]
        [TestCase(false, "BOOK")]
        [TestCase(true, "TREAT")]
        [TestCase(false, "COMMON")]
        [TestCase(true, "SQUAD")]
        [TestCase(true, "CONFUSE")]
        [TestCase(false, "KELVIN")]
        public void Regex(bool expected, string word)
        {
            // Arrange
            var classUnderTest = new MakeWord();
            var blocks2 = string.Join("|", _blocks.ToArray()).Replace(" ", "").Replace("|", " ");

            // Act
            var actual = classUnderTest.Regex(word, blocks2);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}