namespace StringKata.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Calculator
    {
        #region Globals

        private readonly IUserInterface userInterface;

        #endregion
        
        #region Construction

        public Calculator(IUserInterface userInterface)
        {
            this.userInterface = userInterface;
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
            IList<int> parsedNumbers = new ExpressionParser().Parse(numbers); 
            var result = Sum(parsedNumbers);
            return result;
        }

        private int Sum(IList<int> numbers)
        {
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

        private void WriteResult(int result)
        {
            userInterface.Write("The result is " + result);
        }

        #endregion
    }
}
