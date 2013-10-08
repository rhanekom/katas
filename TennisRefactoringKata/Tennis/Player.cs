namespace Tennis
{
    public class Player
    {
        #region Construction

        public Player(string name)
        {
            Name = name;
            Score = new Score();
        }

        #endregion

        #region Public Members

        public string Name { get; private set; }

        public Score Score { get; private set; }

        public void WonPoint()
        {
            Score.Increase();
        }

        #endregion
    }
}
