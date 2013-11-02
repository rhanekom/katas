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

        public World NextIteration()
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
            int count = 0;

            for (int i = Math.Max(0, x - 1); i <= Math.Min(Width - 1, x + 1); i++)
            {
                for (int j = Math.Max(0, y - 1); j <= Math.Min(Height - 1, y + 1); j++)
                {
                    if ((i == x) && (j == y))
                    {
                        continue;
                    }

                    if (this[i, j].IsAlive)
                    {
                        count++;
                    }
                }
                
            }

            return count;
        }

        public IEnumerable<ICell> GetLiveCells()
        {
            return world.Where(x => x.IsAlive);
        }

        #endregion

        #region Private Members

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
