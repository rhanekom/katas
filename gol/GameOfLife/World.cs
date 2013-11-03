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
        private readonly IWorldPrinter worldPrinter;

        #endregion

        #region Construction

        public World(IWorldPrinter worldPrinter)
        {
            world = new CellArray(WorldWidth, WorldHeight);
            this.worldPrinter = worldPrinter;
        }

        #endregion

        #region Object Members

        public override string ToString()
        {
            return worldPrinter.Print(this);
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
            get
            {
                return WorldWidth;
            }
        }

        public int Height
        {
            get
            {
                return WorldHeight;
            }
        }
        
        #endregion

        #region Public Members

        public IWorld NextIteration()
        {
            var newWorld = new World(worldPrinter);

            EachCell((cx, cy) => { 
                if (IsCellAlive(cx, cy))
                {
                    newWorld[cx, cy].Live(); 
                } });

            return newWorld;
        }

        public static bool IsCellAlive(bool cellAlive, int neighbours)
        {
            return !cellAlive ? neighbours == 3 : neighbours == 2 || neighbours == 3;
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

        #region Private Members

        private IEnumerable<int> RangeBetween(int start, int end)
        {
            return Enumerable.Range(start, end - start + 1);
        } 

        private bool IsCellAlive(int x, int y)
        {
            ICell cell = this[x, y];
            return IsCellAlive(cell.IsAlive, GetNumberOfNeighbours(x, y));
        }

        private void EachCell(Action<int, int> action)
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
    }
}
