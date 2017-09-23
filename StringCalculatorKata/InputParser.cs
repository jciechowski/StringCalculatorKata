using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class InputParser
    {
        public IEnumerable<int> ParseStringInput(string value)
        {
            var separators = GetSeparator(ref value);
            var numbers = value.Split(separators.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            return numbers.Select(int.Parse).Where(n => n < 1000);
        }

        private List<string> GetSeparator(ref string value)
        {
            var separators = new List<string>{",", "\n"};
            if (!value.StartsWith("/")) return separators;

            separators.Add(value[2].ToString());
            value = value.Remove(0, 4);

            return separators;
        }
    }
}