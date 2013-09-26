namespace StringKata.Core
{
    using System;

    public class ConsoleUserInterface : IUserInterface
    {
        public bool GetNextUserInput(out string input)
        {
            input = Console.ReadLine();
            return !string.IsNullOrEmpty(input);
        }

        public void Write(string output)
        {
            Console.WriteLine(output);
        }
    }
}