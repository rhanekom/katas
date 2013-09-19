namespace StringKata
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Calculator
    {
        #region Globals

        private readonly Regex formatRegex = new Regex("(//(?<delimiter>.*)\n)?(?<numbers>[\\s\\S]*)$", RegexOptions.Compiled);
        private readonly Regex delimiterRegex = new Regex("\\[(?<delimiter>.*)\\]", RegexOptions.Compiled);



        #endregion

        #region Public Members

        public int Add(string numbers)
        {
            string[] delimiters;
            var cleanNumbers = MatchNumbers(numbers, out delimiters);
            return Add(cleanNumbers, delimiters);
        }

        #endregion

        #region Private Members
        
        private int Add(string cleanNumbers, string[] delimiters)
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

        private string MatchNumbers(string numbers, out string[] delimiters)
        {
            var match = formatRegex.Match(numbers);

            var cleanNumbers = GetNumberValue(match);
            delimiters = GetDelimiterValue(match);
            
            return cleanNumbers;
        }

        private string[] GetDelimiterValue(Match match)
        {
            var delimiterMatch = match.Groups["delimiter"];

            if (delimiterMatch.Success)
            {
                return new[] { ParseDelimiter(delimiterMatch.Value) };
            }

            return new[] { ",", "\n" };
        }

        private string ParseDelimiter(string value)
        {
            var match = delimiterRegex.Match(value);
            return !match.Success ? value :  match.Groups["delimiter"].Value;
        }

        private string GetNumberValue(Match match)
        {
            var numberMatch = match.Groups["numbers"];
            string cleanNumbers = numberMatch.Value;
            return cleanNumbers;
        }

        #endregion
    }
}
