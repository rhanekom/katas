using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class World : IWorld
    {
        #region Globals

        private const int WorldWidth = 22;
        private const int WorldHeight = 30;

        private readonly CellArray world;
        private readonly IWorldPrinter printer;

        #endregion

        #region Construction

        public World(IWorldPrinter printer)
        {
            world = new CellArray(WorldWidth, WorldHeight);
            this.printer = printer;
        }

        #endregion

        #region Object Members

        public override string ToString()
        {
            return printer.Print(this);
        }

        #endregion

        #region IWorld Members

        public ICell this[int x, int y]
        {
            get { return world[x, y]; }
            set { world[x, y] = value; }
        }

        public int Width
        {
            get { return WorldWidth; }
        }

        public int Height
        {
            get { return WorldHeight; }
        }

        public IWorldPrinter Printer
        {
            get { return printer; }
        }

        public int GetNumberOfNeighbours(int x, int y)
        {
            int x1 = Math.Max(0, x - 1), x2 = Math.Min(Width - 1, x + 1);
            int y1 = Math.Max(0, y - 1), y2 = Math.Min(Height - 1, y + 1);

            return RangeBetween(x1, x2)
                .SelectMany(i => RangeBetween(y1, y2).Select(j => new { X = i, Y = j }))
                .Where(r => r.X != x || r.Y != y)
                .Count(r => this[r.X, r.Y].IsAlive);
        }

        public IEnumerable<ICell> GetLiveCells()
        {
            return world.Where(x => x.IsAlive);
        }

        #endregion

        #region Public Members

        public void ForEachCell(Action<int, int> action)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    action(x, y);
                }
            }
        }

        #endregion

        #region Private Members

        private IEnumerable<int> RangeBetween(int start, int end)
        {
            return Enumerable.Range(start, end - start + 1);
        } 

        #endregion
    }
}
