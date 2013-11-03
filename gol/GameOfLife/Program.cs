namespace GameOfLife
{
    public static class Program
    {
        #region Entry Point
        
        public static void Main()
        {
            var world = CreateWorld();
            Run(world);
        }

        #endregion

        #region Private Members

        private static void Run(IWorld world)
        {
            const int iterations = 50;

            IGame game = new Game(new ConsoleUserInterface());
            game.Run(world, iterations);
        }

        private static World CreateWorld()
        {
            var world = new World(new WorldPrinter());

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
            return world;
        }

        #endregion
    }
}
