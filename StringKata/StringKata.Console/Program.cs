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
            while (true)
            {
                UI.Write("Another input please");
                string s = UI.GetNextUserInput();

                if (string.IsNullOrWhiteSpace(s))
                {
                    break;
                }

                calculator.Add(s);
            }
        }

        private static void PrintUsage()
        {
            UI.Write("Usage : scalc 1,2,3");
        }

        #endregion
    }
}
