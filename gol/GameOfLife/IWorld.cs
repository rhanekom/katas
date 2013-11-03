using System.Collections.Generic;

namespace GameOfLife
{
    public interface IWorld
    {
        int Width { get; }

        int Height { get; }

        ICell this[int x, int y] { get; set; }

        IWorld NextIteration();

        IEnumerable<ICell> GetLiveCells();
    }
}