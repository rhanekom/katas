namespace GameOfLife
{
    using System;

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