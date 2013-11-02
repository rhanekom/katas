using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var world = new World(new WorldPrinter());

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
                Console.Write(world.ToString());

                List<ICell> cellsToKeep = world.GetLiveCells().ToList();
                List<ICell> newCells = world.ListOfNewCells().ToList();

                cellsToKeep.AddRange(newCells);
                world.Initialise(cellsToKeep);

                iterations--;
            }
        }
    }
}
