using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace GameOfLife
{
    public class World : IWorld
    {
        #region Globals

        private const int WorldWidth = 22;
        private const int WorldHeight = 30;
        private const int TotalItems = WorldWidth * WorldHeight;
           
        private ICell[] world = new ICell[TotalItems];
        private readonly IWorldPrinter worldPrinter;

        #endregion

        #region Construction

        public World(IWorldPrinter worldPrinter)
        {
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

        #endregion

        #region Public Members

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

        public IEnumerable<ICell> ListOfNewCells()
        {
            var newCellList = new List<ICell>();
            for (int i = 0; i < TotalItems; i++)
            {
                ICell c = world[i];
                if (c == null)
                {
                    continue;
                }
                List<ICell> neighbourList = GetNeighbours(c);
                foreach (ICell neighbour in neighbourList)
                {
                    int numberOfNeighbours = GetNumberOfNeighbours(neighbour);
                    bool isNotPresentInWorld = IsNotPresentInWorld(neighbour);
                    bool isNotPresentInList = IsNotPresentInList(newCellList, neighbour);

                    if (numberOfNeighbours == 3 && isNotPresentInWorld && isNotPresentInList)
                    {
                        newCellList.Add(neighbour);
                    }
                }
            }
            return newCellList;
        }

        public void Add(ICell cell)
        {
            world[Index(cell.X, cell.Y)] = cell;
        }

        public IEnumerable<ICell> GetLiveCells()
        {
            return world.Where(c => c != null && IsCellAlive(c));
        } 

        public void Initialise(IEnumerable<ICell> cells = null)
        {
            world = new ICell[TotalItems];
            
            if (cells != null)
            {
                foreach (Cell c in cells)
                {
                    world[Index(c.X, c.Y)] = c;
                }
            }
        }

        public static bool IsCellAlive(int neighbours)
        {
            return !(neighbours > 3 || neighbours < 2);
        }

        public bool IsCellAlive(ICell cell)
        {
            return IsCellAlive(GetNumberOfNeighbours(cell));
        }

        public int GetNumberOfNeighbours(ICell cell)
        {
            return world.Count(x => x != null && IsNeighbour(x, cell));
        }

        public static bool IsNeighbour(ICell potentialNeighbour, ICell focus)
        {
            bool result = false;
            double sqDistance = Math.Pow(focus.X - potentialNeighbour.X, 2) + Math.Pow(focus.Y - potentialNeighbour.Y, 2);
            if (sqDistance <= 2 && sqDistance > 0)
            {
                result = true;
            }
            return result;
        }

        public bool IsNotPresentInWorld(ICell needle)
        {
            return world.All(cell => cell == null || !cell.Equals(needle));
        }

        public static bool IsNotPresentInList(List<ICell> haystack, ICell needle)
        {
            return haystack.Count(cell => cell.Equals(needle)) == 0;
        }

        public static List<ICell> GetNeighbours(ICell focus)
        {
            var neighbourList = new List<ICell>();
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    var newCell = new Cell(focus.X + i, focus.Y + j);
                    if (IsNeighbour(focus, newCell))
                    {
                        neighbourList.Add(newCell);
                    }
                }
            }

            return neighbourList;
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
