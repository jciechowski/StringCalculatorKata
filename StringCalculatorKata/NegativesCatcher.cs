using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class NegativesCatcher
    {
        public void Catch(IEnumerable<int> numbers)
        {
            var negativesNumbers = string.Join(",", numbers.Where(n => n < 0));
            if (negativesNumbers.Any())
                throw new NegativeValuesException($"Negatives are not allowed: {negativesNumbers}");
        }
    }
}