namespace StringKata
{
    using System;

    public class ConsoleOutput : IOutput
    {
        public void Write(string output)
        {
            Console.WriteLine(output);
        }
    }
}