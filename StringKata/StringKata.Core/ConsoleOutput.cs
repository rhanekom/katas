namespace StringKata.Core
{
    using System;

    public class ConsoleUserInterface : IUserInterface
    {
        public string GetNextUserInput()
        {
            return Console.ReadLine();
        }

        public void Write(string output)
        {
            Console.WriteLine(output);
        }
    }
}