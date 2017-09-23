using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class NegativesSearcher
    {
        public string GetNegatives(IEnumerable<int> numbers)
        {
            var negativesNumbers = numbers.Where(n => n < 0).Select(x => x.ToString()).ToList();
            return string.Join(",", negativesNumbers);
        }
    }
}