using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string value)
        {
            if (string.IsNullOrEmpty(value))
                return 0;
            if (value.Length == 1)
                return int.Parse(value);
            var numbers = value.Split(',');
            return numbers.Sum(int.Parse);
        }
    }
}