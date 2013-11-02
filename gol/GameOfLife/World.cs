using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class World
    {
        #region Globals

        private static Cell[] world = new Cell[22 * 30];

        #endregion

        #region Public Members

        public static void Clear()
        {
            Initialise();
        }

        public static List<Cell> ListOfNewCells()
        {
            var newCellList = new List<Cell>();
            for (int i = 0; i < 22 * 30; i++)
            {
                Cell c = world[i];
                if (c == null)
                {
                    continue;
                }
                List<Cell> neighbourList = Cell.GetNeighbours(c);
                foreach (Cell neighbour in neighbourList)
                {
                    int numberOfNeighbours = Cell.GetNumberOfNeighbours(neighbour);
                    bool isNotPresentInWorld = Cell.IsNotPresentInWorld(neighbour);
                    bool isNotPresentInList = Cell.IsNotPresentInList(newCellList, neighbour);

                    if (numberOfNeighbours == 3 && isNotPresentInWorld && isNotPresentInList)
                    {
                        newCellList.Add(neighbour);
                    }
                }
            }
            return newCellList;
        }

        public static void Add(Cell cell)
        {
            world[cell.X + cell.Y * 22] = cell;
        }

        public static void DisplayOutput()
        {
            for (int i = 0; i < 22; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    string printChar = " ";
                    if (world[i + j * 22] != null)
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
            return world;
        }

        public static void SetWorld(Cell[] newWorld)
        {
            world = newWorld;
        }

        #endregion

        #region Private Members

        private static void Initialise()
        {
            world = new Cell[22 * 30];
        }

        #endregion
    }
}
