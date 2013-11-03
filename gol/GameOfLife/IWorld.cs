namespace GameOfLife
{
    using System.Collections.Generic;

    public interface IWorld
    {
        int Width { get; }

        int Height { get; }

        IWorldPrinter Printer { get; }

        ICell this[int x, int y] { get; }

        IEnumerable<ICell> GetLiveCells();

        int GetNumberOfNeighbours(int x, int y);
    }
}