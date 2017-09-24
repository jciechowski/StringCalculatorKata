using System.Collections.Generic;
using NUnit.Framework;
using StringCalculatorKata;

namespace StringCalculatorSpecs
{
    [TestFixture]
    public class InputParserSpecs
    {
        [Test]
        [TestCaseSource(nameof(StringInputCases))]
        public void ShouldReturnCorrectValueForEmptyList(string input, IEnumerable<int> expected)
        {
            var sut = new InputParser();
            var result = sut.ParseStringInput(input);
            CollectionAssert.AreEqual(expected, result);
        }

        private static readonly object[] StringInputCases =
        {
            new object[] {"", new List<int> {0}},
            new object[] {"1", new List<int> {1}},
            new object[] {"1,2", new List<int> {1,2}},
            new object[] {"1,2", new List<int> {1,2}},
            new object[] {"1\n2,3", new List<int> {1,2,3}}
        };
    }
}