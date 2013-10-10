namespace Tennis
{
    public class MatchScore
    {
        #region Globals

        private readonly Score score1;
        private readonly Score score2;

        #endregion

        #region Construction

        public MatchScore(Score score1, Score score2)
        {
            this.score1 = score1;
            this.score2 = score2;
        }

        #endregion

        #region Object Members

        public override string ToString()
        {
            return GetScore();
        }

        #endregion

        #region Private Members

        private string GetScore()
        {
            if (score1.Value == score2.Value)
            {
                switch (score1.Value)
                {
                    case 0:
                    case 1:
                    case 2:
                        return score1 + "-All";
                    default:
                        return "Deuce";
                }
            }

            if (IsMatchAdvantageOrWin())
            {
                int minusResult = score1.Value - score2.Value;

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

            return string.Format("{0}-{1}", score1, score2);
        }

        private bool IsMatchAdvantageOrWin()
        {
            return score1.Value >= 4 || score2.Value >= 4;
        }

        #endregion
    }
}
