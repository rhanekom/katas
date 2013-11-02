using System.Collections.Generic;

namespace GameOfLife
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var world = new World();

            int iterations = 50;

            world.Add(new Cell(3, 10));
            world.Add(new Cell(3, 11));
            world.Add(new Cell(3, 12));

            world.Add(new Cell(8, 13));
            world.Add(new Cell(8, 12));
            world.Add(new Cell(7, 13));
            world.Add(new Cell(7, 12));

            world.Add(new Cell(3, 3));
            world.Add(new Cell(3, 2));
            world.Add(new Cell(3, 1));
            world.Add(new Cell(2, 3));
            world.Add(new Cell(1, 2));

            while (iterations > 0)
            {
                world.DisplayOutput();

                var cellsToKeep = new List<Cell>();

                for (int i = 0; i < 22*30; i++)
                {
                    Cell c = world.GetWorld()[i];
                    if (c != null && world.IsCellAlive(c))
                    {
                        cellsToKeep.Add(c);
                    }
                    
                }
                List<Cell> newCells = world.ListOfNewCells();

                cellsToKeep.AddRange(newCells);
                world.SetWorld(new Cell[22 * 30]);

                foreach(Cell c in cellsToKeep)
                {
                    world.GetWorld()[c.X + c.Y * 22] = c;
                }

                iterations--;
            }
        }
    }
}
