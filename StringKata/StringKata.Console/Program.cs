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
                Output.Write("Usage : scalc '1,2,3'");
            }
        }

        #endregion
    }
}
