using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int iterations = 50;

            Cell.Add(new Cell(3, 10));
            Cell.Add(new Cell(3, 11));
            Cell.Add(new Cell(3, 12));

            Cell.Add(new Cell(8, 13));
            Cell.Add(new Cell(8, 12));
            Cell.Add(new Cell(7, 13));
            Cell.Add(new Cell(7, 12));

            Cell.Add(new Cell(3, 3));
            Cell.Add(new Cell(3, 2));
            Cell.Add(new Cell(3, 1));
            Cell.Add(new Cell(2, 3));
            Cell.Add(new Cell(1, 2));

            while (iterations > 0)
            {
                Cell.DisplayOutput();

                List<Cell> cellsToKeep = new List<Cell>();

                for (int i = 0; i < 22*30; i++)
                {
                    Cell c = Cell.GetWorld()[i];
                    if (c!= null && c.IsCellAlive())
                    {
                        cellsToKeep.Add(c);
                    }
                    
                }
                List<Cell> newCells = Cell.ListOfNewCells();

                cellsToKeep.AddRange(newCells);
                Cell.SetWorld(new Cell[22*30]);

                foreach(Cell c in cellsToKeep)
                {
                    Cell.GetWorld()[c.X + c.Y * 22] = c;
                }

                iterations--;
            }
        }
    }
}
