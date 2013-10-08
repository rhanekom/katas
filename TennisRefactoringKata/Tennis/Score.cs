namespace Tennis
{
    public class Score
    {
        public int Value { get; private set; }

        public void Increase()
        {
            Value += 1;
        }

        public override string ToString()
        {
            switch (Value)
            {
                case 0:
                    return "Love";
                case 1:
                    return "Fifteen";
                case 2:
                    return "Thirty";
                case 3:
                    return "Forty";
                default:
                    return "Unknown";
            }
        }
    }
}
