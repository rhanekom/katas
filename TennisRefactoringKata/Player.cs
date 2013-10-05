namespace Tennis
{
    public class Player
    {
        #region Construction

        public Player(string name)
        {
            Name = name;
        }

        #endregion

        #region Public Members

        public string Name { get; private set; }

        public int Score { get; private set; }

        public void WonPoint()
        {
            Score += 1;
        }

        #endregion
    }
}
