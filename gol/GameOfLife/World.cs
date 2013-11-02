using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace GameOfLife
{
    public class World : IWorld
    {
        #region Globals

        private const int WorldWidth = 22;
        private const int WorldHeight = 30;
        private const int TotalItems = WorldWidth * WorldHeight;
           
        private readonly ICell[] world = new ICell[TotalItems];
        private readonly IWorldPrinter worldPrinter;

        #endregion

        #region Construction

        public World(IWorldPrinter worldPrinter)
        {
            for (int i = 0; i < TotalItems; i++)
            {
                world[i] = new Cell();
            }

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
            get { return world[Index(x, y)]; }
            set { world[Index(x, y)] = value; }
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

        public static bool IsCellAlive(CellState cellState, int neighbours)
        {
            if (cellState == CellState.Dead)
            {
                return neighbours == 3;
            }
            
            return neighbours == 2 || neighbours == 3;
        }


        public bool IsCellAlive(int x, int y)
        {
            ICell cell = this[x, y];
            return IsCellAlive(cell.State, GetNumberOfNeighbours(x, y));
        }

        public void EachCell(Action<int, int> action)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    action(x, y);
                }
            }
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

                    if (this[i, j].State == CellState.Alive)
                    {
                        count++;
                    }
                }
                
            }

            return count;
        }

        public IEnumerable<ICell> GetLiveCells()
        {
            return world.Where(x => x.State == CellState.Alive);
        }

        #endregion

        #region Private Members

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int Index(int x, int y)
        {
            return x + y * WorldWidth;
        }

        #endregion
    }
}
