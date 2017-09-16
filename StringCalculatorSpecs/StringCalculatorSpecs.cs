using NUnit.Framework;
using StringCalculatorKata;
using System;

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

        [Test]
        [TestCase("//;\n1;-1")]
        public void ShouldThrowExceptionForNegativeNumber(string value)
        {
            var sut = new StringCalculator();
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.Add(value));
        }


        [Test]
        [TestCase("//;\n1;-1", "Negatives are not allowed: -1")]
        [TestCase("//;\n1;-1,-2", "Negatives are not allowed: -1,-2")]
        [TestCase("//;\n1;-1,2,-3,4", "Negatives are not allowed: -1,-3")]
        public void ShouldThrowExceptionWithNegativeValues(string value, string expectedMessage)
        {
            var sut = new StringCalculator();
            var result = Assert.Throws<ArgumentOutOfRangeException>(() => sut.Add(value));
            Assert.AreEqual(expectedMessage, result.Message);
        }
    }
}