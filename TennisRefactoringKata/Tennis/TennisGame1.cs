namespace Tennis
{
    using System.Linq;

    public class TennisGame1 : ITennisGame
    {
        #region Globals

        private readonly Player player1;
        private readonly Player player2;
        private readonly MatchScore score;

        #endregion

        #region Construction

        public TennisGame1(string player1Name, string player2Name)
        {
            player1 = new Player(player1Name);
            player2 = new Player(player2Name);
            score = new MatchScore(player1.Score, player2.Score);
        }

        #endregion

        #region ITennisGame Members

        public void WonPoint(string playerName)
        {
            GetPlayer(playerName).WonPoint();
        }

        public string GetScore()
        {
            return score.ToString();
        }

        #endregion

        #region Private Members

        private Player GetPlayer(string playerName)
        {
            return (new[] { player1, player2 }).SingleOrDefault(x => x.Name == playerName);
        }

        #endregion
    }
}
