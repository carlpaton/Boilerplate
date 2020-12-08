using Microsoft.VisualStudio.TestTools.UnitTesting;
using PleaseTestMeApp;

namespace MsTest
{
    [TestClass]
    public class HeapsOfWorkServiceTests
    {
        [TestMethod]
        public void MakeANoise_GivenValidReason_ReturnsTheNoiseAndReason()
        {
            // Arrange
            IHeapsOfWorkService classUnderTest = new HeapsOfWorkService();
            var reason = "NASA rocket";
            var expected = "BOOMING NOISE! Because Im a NASA rocket!";

            // Act
            var actual = classUnderTest.MakeANoise(reason);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Make a noise is given a valid reason it returns the noise and reason")]
        public void MakeANoiseGivenValidReason()
        {
            // Arrange
            IHeapsOfWorkService classUnderTest = new HeapsOfWorkService();
            var reason = "NASA rocket";
            var expected = "BOOMING NOISE! Because Im a NASA rocket!";

            // Act
            var actual = classUnderTest.MakeANoise(reason);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
