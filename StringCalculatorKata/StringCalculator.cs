using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        private readonly NegativesCatcher _negativesCatcher;
        private readonly InputParser _parser;

        public StringCalculator()
        {
            _negativesCatcher = new NegativesCatcher();
            _parser = new InputParser();
        }

        public int Add(string value)
        {
            var numbers = _parser.ParseStringInput(value).ToList();
            _negativesCatcher.Catch(numbers);

            return numbers.Sum();
        }
    }
}