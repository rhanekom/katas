namespace GameOfLife
{
    public interface IGame
    {
        void Run(IWorld world, int iterations);
    }
}