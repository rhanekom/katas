using System.Collections.Generic;

namespace GameOfLife
{
    public interface IWorld
    {
        int Width { get; }

        int Height { get; }

        IWorldPrinter Printer { get; }

        ICell this[int x, int y] { get; set; }

        IEnumerable<ICell> GetLiveCells();

        int GetNumberOfNeighbours(int x, int y);
    }
}