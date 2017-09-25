using System.Collections.Generic;
using NUnit.Framework;
using StringCalculatorKata;

namespace StringCalculatorSpecs
{
    [TestFixture]
    public class NegativeSearcherSpecs
    {
        private static object[] _negativeValues =
        {
            new object[] {new List<int> {-1}, "Negatives are not allowed: -1"},
            new object[] {new List<int> {-1, -2}, "Negatives are not allowed: -1,-2"},
            new object[] {new List<int> {0, -2, 15}, "Negatives are not allowed: -2"}
        };

        [Test]
        [TestCaseSource(nameof(_negativeValues))]
        public void ShouldThrowExceptionWhenListContainsNegatives(List<int> negativeValues, string expectedMessage)
        {
            var sut = new NegativesCatcher();
            var expectedException = Assert.Throws<NegativeValuesException>(() => sut.Catch(negativeValues));
            Assert.AreEqual(expectedException.Message, expectedMessage);
        }
    }
}