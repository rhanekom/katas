namespace StringKata.Core
{
    public interface IUserInterface
    {
        bool GetNextUserInput(out string input);

        void Write(string output);
    }
}