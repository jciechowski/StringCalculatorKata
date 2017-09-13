using System;
using System.Collections.Generic;
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
            var separator = string.Empty;

            var numbers = GetNumericValues(value, separator);
            return numbers.Sum(int.Parse);
        }

        private IEnumerable<string> GetNumericValues(string value, string separator)
        {
            if (value.StartsWith("/"))
            {
                separator = value[2].ToString();
                value = value.Remove(0, 4);
            }

            var separators = new[] {",", "\n", separator};
            var numbers = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            return numbers;
        }
    }
}