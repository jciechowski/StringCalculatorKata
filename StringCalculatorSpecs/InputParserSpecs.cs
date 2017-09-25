using System.Collections.Generic;
using NUnit.Framework;
using StringCalculatorKata;

namespace StringCalculatorSpecs
{
    [TestFixture]
    public class InputParserSpecs
    {
        private static readonly object[] DefaultDelimeters =
        {
            new object[] {"", new List<int> {0}},
            new object[] {"1", new List<int> {1}},
            new object[] {"1,2", new List<int> {1,2}},
            new object[] {"1,2", new List<int> {1,2}},
            new object[] {"1\n2,3", new List<int> {1,2,3}}
        };

        
        [Test]
        [TestCaseSource(nameof(DefaultDelimeters))]
        public void ShouldReturnListOfNumbersFromStringWithDelimeters(string input, IEnumerable<int> expected)
        {
            var sut = new InputParser();
            var result = sut.ParseStringInput(input);
            CollectionAssert.AreEqual(expected, result);
        }

        private static readonly object[] UserDefinedDelimeters =
        {
            new object[] {"//;\n1;", new List<int> {1}},
            new object[] {"//;\n1;2", new List<int> {1,2}},
            new object[] {"//;\n1;2;3", new List<int> {1,2,3}},
            new object[] {"//.\n1.2.3", new List<int> {1,2,3}},
        };

        [Test]
        [TestCaseSource(nameof(UserDefinedDelimeters))]
        public void ShouldReturnListOfNumbersWithUserDefinedDelimeter(string input, IEnumerable<int> expected)
        {
            var sut = new InputParser();
            var result = sut.ParseStringInput(input);
            CollectionAssert.AreEqual(expected, result);
        }
    }
}