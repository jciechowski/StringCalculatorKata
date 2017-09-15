using NUnit.Framework;
using StringCalculatorKata;

namespace StringCalculatorSpecs
{
    [TestFixture]
    public class StringCalculatorSpecs
    {
        [Test]
        [TestCase("", 0)]
        [TestCase("1", 1)]
        [TestCase("1,2", 3)]
        [TestCase("1,3", 4)]
        [TestCase("1,2,3", 6)]
        public void ShouldAddNumbers(string value, int expected)
        {
            var sut = new StringCalculator();
            var result = sut.Add(value);
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase("1\n", 1)]
        [TestCase("1\n2", 3)]
        [TestCase("1\n2\n3", 6)]
        public void ShouldAddNumbersWithNewlineDelimeter(string value, int expected)
        {
            var sut = new StringCalculator();
            var result = sut.Add(value);
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase("//;\n1;", 1)]
        [TestCase("//;\n1;2", 3)]
        [TestCase("//;\n1;2;3", 6)]
        [TestCase("//.\n1.2.3", 6)]
        public void ShouldAddNumberWithUserDefinedDelimeter(string value, int expected)
        {
            var sut = new StringCalculator();
            var result = sut.Add(value);
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase("//;\n1000;2", 2)]
        public void ShouldIgnoreNumbersGreaterThan1000(string value, int expected)
        {
            var sut = new StringCalculator();
            var result = sut.Add(value);
            Assert.AreEqual(expected, result);
        }
    }
}