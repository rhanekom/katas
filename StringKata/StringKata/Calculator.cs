namespace StringKata
{
    using System.Linq;

    public class Calculator
    {
        public int Add(string numbers)
        {
            if (numbers == string.Empty)
            {
                return 0;
            }

            string[] split = numbers.Split(new[] { ',' });
            return split.Select(int.Parse).Sum();
        }
    }
}
