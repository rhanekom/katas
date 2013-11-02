using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class World
    {
        #region Globals

        private static Cell[] _world = new Cell[22 * 30];

        #endregion

        #region Public Members

        public static void Clear()
        {
            Initialise();
        }

        public static List<Cell> ListOfNewCells()
        {
            List<Cell> newCellList = new List<Cell>();
            for (int i = 0; i < 22 * 30; i++)
            {
                Cell c = _world[i];
                if (c == null)
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

        #endregion

        #region Private Members

        private static void Initialise()
        {
            _world = new Cell[22 * 30];
        }

        #endregion
    }
}
