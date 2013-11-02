namespace GameOfLife
{
    public interface ICell
    {
        CellState State { get; }

        void Live();

        void Die();
    }
}