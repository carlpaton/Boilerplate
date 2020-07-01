using ABC_Problem;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        // WHY IS THERE NEW HERE CARL?
        private new List<string> _blocks;

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
        public void MakeWord(bool expected, string word)
        {
            // Arrange
            var classUnderTest = new LoopyLoop();

            // Act
            var actual = classUnderTest.MakeWord(word, _blocks);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}