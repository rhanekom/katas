namespace StringKata.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class ExpressionParser
    {
        #region Globals

        private readonly Regex formatRegex = new Regex("(//(?<delimiter>.*)\n)?(?<numbers>[\\s\\S]*)$", RegexOptions.Compiled);
        private readonly Regex delimiterRegex = new Regex("\\[(?<delimiter>[^\\]]*)\\]", RegexOptions.Compiled);

        #endregion

        #region Public Members
        
        public IList<int> Parse(string expression)
        {
            string[] delimiters;
            var cleanNumbers = MatchNumbers(expression, out delimiters);
            string[] split = cleanNumbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            return split.Select(int.Parse).Where(x => x <= 1000).ToList();
        }

        #endregion
        
        #region Private Members

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
