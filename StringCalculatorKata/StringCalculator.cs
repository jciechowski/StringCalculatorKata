using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        private readonly NegativesSearcher _negativesSearcher;
        private readonly InputParser _parser;

        public StringCalculator()
        {
            _negativesSearcher = new NegativesSearcher();
            _parser = new InputParser();
        }

        public int Add(string value)
        {
            var numbers = _parser.ParseStringInput(value).ToList();
            _negativesSearcher.FindNegavites(numbers);

            return numbers.Sum();
        }
    }
}