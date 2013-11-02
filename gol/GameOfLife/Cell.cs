namespace GameOfLife
{
    public class Cell : ICell
    {
        #region Construction

        public Cell()
        {
            State = CellState.Dead;
        }

        #endregion

        #region Properties

        public CellState State { get; private set; }

        #endregion

        #region Public Members

        public void Live()
        {
            State = CellState.Alive;
        }

        public void Die()
        {
            State = CellState.Dead;
        }

        #endregion
    }
}
