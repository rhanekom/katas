namespace GameOfLife
{
    public interface ICell
    {
        bool IsAlive { get; }

        void Live();
    }
}