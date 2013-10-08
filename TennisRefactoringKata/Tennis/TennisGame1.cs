namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        #region Globals

        private readonly Player player1;
        private readonly Player player2;

        #endregion

        #region Construction

        public TennisGame1(string player1Name, string player2Name)
        {
            player1 = new Player(player1Name);
            player2 = new Player(player2Name);
        }

        #endregion

        #region ITennisGame Members

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
            {
                player1.WonPoint();
            }
            else
            {
                player2.WonPoint();
            }
        }

        public string GetScore()
        {
            if (player1.Score == player2.Score)
            {
                switch (player1.Score.Value)
                {
                    case 0:
                    case 1:
                    case 2:
                        return player1.Score + "-All";
                    default:
                        return "Deuce";
                }
            }
            
            if (player1.Score.Value >= 4 || player2.Score.Value >= 4)
            {
                int minusResult = player1.Score.Value - player2.Score.Value;
                switch (minusResult)
                {
                    case 1:
                        return "Advantage player1";
                    case -1:
                        return "Advantage player2";
                    default:
                        return minusResult >= 2 ? "Win for player1" : "Win for player2";
                }
            }

            return string.Format("{0}-{1}", player1.Score, player2.Score);
        }

        #endregion
    }
}
