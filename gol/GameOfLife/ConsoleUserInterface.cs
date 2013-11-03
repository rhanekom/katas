using System;

namespace GameOfLife
{
    public class ConsoleUserInterface : IUserInterface
    {
        #region IUserInterface Members

        public void Write(string message)
        {
            Console.Write(message);
        }

        #endregion
    }
}