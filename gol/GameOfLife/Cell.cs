using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }

        private static Cell[] _world = new Cell[22 * 30];

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public bool IsCellAlive(int neighbours)
        {
            return !(neighbours > 3 || neighbours < 2);
        }

        public static void Clear()
        {
            Initialise();
        }

        private static void Initialise()
        {
            _world = new Cell[22 * 30];
        }

        public bool IsCellAlive()
        {
            int neighbours = 0;
            for (int i = 0; i < 22*30; i++)
            {
                Cell c = _world[i];
                if(c != null && IsNeighbour(c))
                {
                    neighbours++;
                }
            }

            return IsCellAlive(neighbours);
        }        

        public int DetermineNumberOfNeighbours()
        {
            int neighbours = 0;
            for (int i = 0; i < 22*30; i++)
            {
                Cell c = _world[i];
                if (c != null && IsNeighbour(c))
                {
                    neighbours++;
                }                
            }
            return neighbours;
        }

        public bool IsNeighbour(Cell cell)
        {
            bool result = false;
            double sqDistance = Math.Pow(X - cell.X, 2) + Math.Pow(Y - cell.Y, 2);
            if (sqDistance <= 2 && sqDistance > 0)
            {
                result = true;
            }
            return result;
        }

        public static List<Cell> ListOfNewCells()
        {
            List<Cell> newCellList = new List<Cell>();
            for (int i = 0; i < 22*30; i++)
            {
                Cell c = _world[i];
                if(c == null)
                {
                    continue;
                }
                List<Cell> neighbourList = c.GetNeighbours();
                foreach (Cell neighbour in neighbourList)
                {
                    int numberOfNeighbours = neighbour.DetermineNumberOfNeighbours();
                    bool isNotPresentInWorld = neighbour.IsNotPresentInWorld();
                    bool isNotPresentInList = neighbour.IsNotPresentInList(newCellList);

                    if (numberOfNeighbours == 3 && isNotPresentInWorld && isNotPresentInList)
                    {
                        newCellList.Add(neighbour);
                    }
                }                
            }
            return newCellList;
        }

        private bool IsNotPresentInWorld()
        {
            bool result = true;
            for (int i = 0; i < 22*30; i++)
            {
                Cell c = _world[i];
                if(c != null && c.X == X && c.Y == Y)
                {
                    result = false;
                }                
            }
            return result;
        }

        public bool IsNotPresentInList(List<Cell> cellsList)
        {
            return cellsList.Count(cell => (X == cell.X) && (Y == cell.Y)) == 0;
        }

        public List<Cell> GetNeighbours()
        {
            List<Cell> neighbourList = new List<Cell>();
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    Cell newCell = new Cell(X + i, Y + j);
                    if (newCell.IsNeighbour(this))
                    {
                        neighbourList.Add(newCell);
                    }
                }
            }
            return neighbourList;
        }

        public static void Add(Cell cell)
        {
            _world[cell.X + cell.Y * 22] = cell;
        }

        public static void DisplayOutput()
        {
            for (int i = 0; i < 22; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    string printChar = " ";
                    if (_world[i + j * 22] != null)
                    {
                        printChar = "*";
                    }
                    Console.Write(printChar);
                }
                Console.WriteLine();
            }
        }

        public static Cell[] GetWorld()
        {
            return _world;
        }

        public static void SetWorld(Cell[] world)
        {
            _world = world;
        }
    }
}
