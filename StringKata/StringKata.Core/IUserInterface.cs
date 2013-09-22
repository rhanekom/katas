namespace StringKata.Core
{
    public interface IUserInterface
    {
        string GetNextUserInput();

        void Write(string output);
    }
}