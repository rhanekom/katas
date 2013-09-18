namespace StringKata
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Calculator
    {
        public int Add(string numbers)
        {
            const string expression = "(//(?<delimiter>.*)\n)?(?<numbers>[\\s\\S]*)$";
            var regularExpression = new Regex(expression);

            var match = regularExpression.Match(numbers);

            var delimiterMatch = match.Groups["delimiter"];
            var numberMatch = match.Groups["numbers"];

            string cleanNumbers = numberMatch.Value;
            char[] delimiters = delimiterMatch.Success ? new[] { Convert.ToChar(delimiterMatch.Value) } : new[] { ',', '\n' };

            string[] split = cleanNumbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            return split.Select(int.Parse).Sum();
        }
    }
}
