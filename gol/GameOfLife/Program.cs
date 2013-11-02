using System.Collections.Generic;

namespace GameOfLife
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int iterations = 50;

            World.Add(new Cell(3, 10));
            World.Add(new Cell(3, 11));
            World.Add(new Cell(3, 12));

            World.Add(new Cell(8, 13));
            World.Add(new Cell(8, 12));
            World.Add(new Cell(7, 13));
            World.Add(new Cell(7, 12));

            World.Add(new Cell(3, 3));
            World.Add(new Cell(3, 2));
            World.Add(new Cell(3, 1));
            World.Add(new Cell(2, 3));
            World.Add(new Cell(1, 2));

            while (iterations > 0)
            {
                World.DisplayOutput();

                var cellsToKeep = new List<Cell>();

                for (int i = 0; i < 22*30; i++)
                {
                    Cell c = World.GetWorld()[i];
                    if (c!= null && Cell.IsCellAlive(c))
                    {
                        cellsToKeep.Add(c);
                    }
                    
                }
                List<Cell> newCells = World.ListOfNewCells();

                cellsToKeep.AddRange(newCells);
                World.SetWorld(new Cell[22 * 30]);

                foreach(Cell c in cellsToKeep)
                {
                    World.GetWorld()[c.X + c.Y * 22] = c;
                }

                iterations--;
            }
        }
    }
}
