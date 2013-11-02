using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace GameOfLife
{
    public class World
    {
        #region Globals

        private const int Width = 22;
        private const int Height = 30;
        private const int TotalItems = Width * Height;
           
        private Cell[] world = new Cell[TotalItems];

        #endregion

        #region Object Members

        public override string ToString()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    var printChar = GetPrintChar(i, j);
                    sb.Append(printChar);
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        private string GetPrintChar(int i, int j)
        {
            Cell cell = world[Index(i, j)];
            return GetPrintChar(cell);
        }

        private static string GetPrintChar(Cell cell)
        {
            return cell != null ? "*" : " ";
        }

        #endregion

        #region Public Members

        public Cell this[int x, int y]
        {
            get { return world[Index(x, y)]; }
            set { world[Index(x, y)] = value; }
        }

        public List<Cell> ListOfNewCells()
        {
            var newCellList = new List<Cell>();
            for (int i = 0; i < TotalItems; i++)
            {
                Cell c = world[i];
                if (c == null)
                {
                    continue;
                }
                List<Cell> neighbourList = GetNeighbours(c);
                foreach (Cell neighbour in neighbourList)
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

        public void Add(Cell cell)
        {
            world[Index(cell.X, cell.Y)] = cell;
        }

        public IEnumerable<Cell> GetLiveCells()
        {
            return world.Where(c => c != null && IsCellAlive(c));
        } 

        public void Initialise(IEnumerable<Cell> cells = null)
        {
            world = new Cell[TotalItems];
            
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

        public bool IsCellAlive(Cell cell)
        {
            int neighbours = 0;

            for (int i = 0; i < TotalItems; i++)
            {
                Cell neighbour = world[i];
                if (neighbour != null && IsNeighbour(neighbour, cell))
                {
                    neighbours++;
                }
            }

            return IsCellAlive(neighbours);
        }

        public int GetNumberOfNeighbours(Cell cell)
        {
            int neighbours = 0;
            for (int i = 0; i < TotalItems; i++)
            {
                Cell neighbour = world[i];
                if (neighbour != null && IsNeighbour(neighbour, cell))
                {
                    neighbours++;
                }
            }
            return neighbours;
        }

        public static bool IsNeighbour(Cell potentialNeighbour, Cell focus)
        {
            bool result = false;
            double sqDistance = Math.Pow(focus.X - potentialNeighbour.X, 2) + Math.Pow(focus.Y - potentialNeighbour.Y, 2);
            if (sqDistance <= 2 && sqDistance > 0)
            {
                result = true;
            }
            return result;
        }


        public bool IsNotPresentInWorld(Cell needle)
        {
            bool result = true;
            for (int i = 0; i < TotalItems; i++)
            {
                Cell cell = world[i];
                if (cell != null && cell.X == needle.X && cell.Y == needle.Y)
                {
                    result = false;
                }
            }
            return result;
        }

        public static bool IsNotPresentInList(List<Cell> haystack, Cell needle)
        {
            return haystack.Count(cell => (needle.X == cell.X) && (needle.Y == cell.Y)) == 0;
        }

        public static List<Cell> GetNeighbours(Cell focus)
        {
            var neighbourList = new List<Cell>();
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
            return x + y * Width;
        }

        #endregion
    }
}
