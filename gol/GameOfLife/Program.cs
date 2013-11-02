using System;

namespace GameOfLife
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var world = new World(new WorldPrinter());

            int iterations = 50;

            world[3, 10].Live();
            world[3, 11].Live();
            world[3, 12].Live();

            world[8, 13].Live();
            world[8, 12].Live();
            world[7, 13].Live();
            world[7, 12].Live();

            world[3, 3].Live();
            world[3, 2].Live();
            world[3, 1].Live();
            world[2, 3].Live();
            world[1, 2].Live();

            while (iterations > 0)
            {
                Console.Write(world.ToString());
                world = world.NextIteration();
                iterations--;
            }
        }
    }
}
