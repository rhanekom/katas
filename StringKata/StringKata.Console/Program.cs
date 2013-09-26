namespace StringKata.Console
{
    using Core;

    public class Program
    {
        #region Construction
        
        static Program()
        {
            UI = new ConsoleUserInterface();
        }

        #endregion

        #region Public Members

        public static IUserInterface UI { get; set; }
 
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                PrintUsage();
            }
            else
            {
                Calculate(args[0]);
            }
        }

        #endregion

        #region Private Members

        private static void Calculate(string s)
        {
            var calculator = new Calculator(UI);
            calculator.Add(s);

            CalculateNextValue(calculator);
        }

        private static void CalculateNextValue(Calculator calculator)
        {
            string input;

            while (GetUserInput(out input))
            {
                calculator.Add(input);
            }
        }

        private static bool GetUserInput(out string input)
        {
            UI.Write("Another input please");
            return UI.GetNextUserInput(out input);
        }

        private static void PrintUsage()
        {
            UI.Write("Usage : scalc 1,2,3");
        }

        #endregion
    }
}
