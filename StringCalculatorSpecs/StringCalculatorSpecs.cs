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
        public void ShouldAddNumbers(string value, int expected)
        {
            var sut = new StringCalculator();
            var result = sut.Add(value);
            Assert.AreEqual(expected, result);
        }
    }
}