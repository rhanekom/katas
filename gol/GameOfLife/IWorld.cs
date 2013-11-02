namespace GameOfLife
{
    public interface IWorld
    {
        int Width { get; }

        int Height { get; }

        ICell this[int x, int y] { get; set; }
    }
}