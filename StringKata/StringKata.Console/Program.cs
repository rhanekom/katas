namespace StringKata.Console
{
    using Core;

    public class Program
    {
        #region Construction
        
        static Program()
        {
            Output = new ConsoleOutput();
        }

        #endregion

        #region Public Members

        public static IOutput Output { get; set; }
 
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
            var calculator = new Calculator(Output);
            calculator.Add(s);
        }

        private static void PrintUsage()
        {
            Output.Write("Usage : scalc 1,2,3");
        }

        #endregion
    }
}
