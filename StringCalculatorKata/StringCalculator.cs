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

            var numbers = GetNumericValues(value).ToList();
            var negativesNumbers = numbers.Where(n => n < 0).Select(x => x.ToString()).ToList();
            var negatives = string.Join(",", negativesNumbers);
            if (negatives.Any())
                throw new ArgumentOutOfRangeException($"Negatives are not allowed: {negatives}", new ArgumentOutOfRangeException());
            return numbers.Sum();
        }

        private IEnumerable<int> GetNumericValues(string value)
        {
            var separator = string.Empty;
            if (value.StartsWith("/"))
            {
                separator = value[2].ToString();
                value = value.Remove(0, 4);
            }

            var separators = new[] {",", "\n", separator};
            var numbers = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            return numbers.Select(int.Parse).Where(n => n < 1000);
        }
    }
}