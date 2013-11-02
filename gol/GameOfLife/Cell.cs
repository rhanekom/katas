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

        #region Object Members

        public override string ToString()
        {
            return IsAlive ? "*" : " ";
        }

        #endregion

        #region Properties

        public bool IsAlive
        {
            get
            {
                return State == CellState.Alive;
            }
        }

        #endregion

        #region Public Members

        public void Live()
        {
            State = CellState.Alive;
        }
        #endregion

        #region Private Members

        private CellState State { get; set; }

        #endregion
    }
}
