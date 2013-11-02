namespace GameOfLife
{
    public class Cell : ICell
    {
        #region Construction

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        #endregion

        #region Properties

        public int X { get; private set; }
        public int Y { get; private set; }

        #endregion

        #region Object Members

        protected bool Equals(Cell other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Cell) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X*397) ^ Y;
            }
        }

        #endregion
    }
}
