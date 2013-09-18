namespace StringKata
{
    using System;
    using System.Linq;

    public class Calculator
    {
        public int Add(string numbers)
        {
            string[] split = numbers.Split(new[] { ',', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return split.Select(int.Parse).Sum();
        }
    }
}
