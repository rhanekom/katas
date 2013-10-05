namespace Tennis
{
    using System;

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
            String score = "";
            int tempScore;
            
            if (player1.Score == player2.Score)
            {
                switch (player1.Score)
                {
                    case 0:
                        score = "Love-All";
                        break;
                    case 1:
                        score = "Fifteen-All";
                        break;
                    case 2:
                        score = "Thirty-All";
                        break;
                    default:
                        score = "Deuce";
                        break;
                }
            }
            else if (player1.Score >= 4 || player2.Score >= 4)
            {
                int minusResult = player1.Score - player2.Score;
                switch (minusResult)
                {
                    case 1:
                        score = "Advantage player1";
                        break;
                    case -1:
                        score = "Advantage player2";
                        break;
                    default:
                        if (minusResult >= 2)
                        {
                            score = "Win for player1";
                        }
                        else
                        {
                            score = "Win for player2";
                        }
                        break;
                }
            }
            else
            {
                for (int i = 1; i < 3; i++)
                {
                    if (i == 1) tempScore = player1.Score;
                    else
                    {
                        score += "-";
                        tempScore = player2.Score;
                    }
                    switch (tempScore)
                    {
                        case 0:
                            score += "Love";
                            break;
                        case 1:
                            score += "Fifteen";
                            break;
                        case 2:
                            score += "Thirty";
                            break;
                        case 3:
                            score += "Forty";
                            break;
                    }
                }
            }

            return score;
        }

        #endregion
    }
}
