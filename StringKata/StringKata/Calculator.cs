namespace StringKata
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Calculator
    {
        #region Globals

        private const string Expression = "(//(?<delimiter>.*)\n)?(?<numbers>[\\s\\S]*)$";
        private readonly Regex formatExpression = new Regex(Expression, RegexOptions.Compiled);

        #endregion

        #region Public Members

        public int Add(string numbers)
        {
            char[] delimiters;
            var cleanNumbers = MatchNumbers(numbers, out delimiters);
            return Add(cleanNumbers, delimiters);
        }

        #endregion

        #region Private Members
        
        private static int Add(string cleanNumbers, char[] delimiters)
        {
            string[] split = cleanNumbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            var numbers = split.Select(int.Parse).Where(x => x <= 1000).ToList();

            AssertNoNegativeNumbers(numbers);

            return numbers.Sum();
        }

        private static void AssertNoNegativeNumbers(IEnumerable<int> numbers)
        {
            var negatives = numbers.Where(x => x < 0).ToArray();

            if (negatives.Any())
            {
                throw new ArgumentException("negatives not allowed : " + string.Join(",", negatives));
            }
        }

        private string MatchNumbers(string numbers, out char[] delimiters)
        {
            var match = formatExpression.Match(numbers);

            var delimiterMatch = match.Groups["delimiter"];
            var numberMatch = match.Groups["numbers"];

            string cleanNumbers = numberMatch.Value;
            delimiters = delimiterMatch.Success ? new[] { Convert.ToChar(delimiterMatch.Value) } : new[] { ',', '\n' };
            return cleanNumbers;
        }

        #endregion
    }
}
