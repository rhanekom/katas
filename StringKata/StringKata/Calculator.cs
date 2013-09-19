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
        private readonly Regex delimiterRegex = new Regex("\\[(?<delimiter>[^\\]]*)\\]", RegexOptions.Compiled);
        private readonly IOutput output;

        #endregion
        
        #region Construction

        public Calculator(IOutput output)
        {
            this.output = output;
        }

        #endregion
        
        #region Public Members

        public int Add(string numbers)
        {
            var result = GetResult(numbers);
            WriteResult(result);
            return result;
        }

        #endregion

        #region Private Members

        private int GetResult(string numbers)
        {
            string[] delimiters;
            var cleanNumbers = MatchNumbers(numbers, out delimiters);
            var result = Add(cleanNumbers, delimiters);
            return result;
        }

        private void WriteResult(int result)
        {
            output.Write("The result is " + result);
        }

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
                return ParseDelimiters(delimiterMatch.Value);
            }

            return new[] { ",", "\n" };
        }

        private string[] ParseDelimiters(string value)
        {
            Match match = delimiterRegex.Match(value);
            return !match.Success ? new[] { value } : ParseDelimiters(match);
        }

        private static string[] ParseDelimiters(Match match)
        {
            var delimiters = new List<string>();

            do
            {
                delimiters.Add(match.Groups["delimiter"].Value);
                match = match.NextMatch();
            } 
            while (match.Success);

            return delimiters.ToArray();
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
