namespace GameOfLife
{
    public class Game : IGame
    {
        #region Globals

        private readonly IUserInterface userInterface;

        #endregion

        #region Construction

        public Game(IUserInterface userInterface)
        {
            this.userInterface = userInterface;
        }

        #endregion

        #region IGame Members 

        public void Run(IWorld world, int iterations)
        {
            int currentIteration = 0;

            while (currentIteration < iterations)
            {
                userInterface.Write(world.ToString());
                world = NextIteration(world);
                currentIteration++;
            }
        }

        #endregion

        #region Public Members

        public IWorld NextIteration(IWorld world)
        {
            var newWorld = new World(world.Printer);

            newWorld.ForEachCell((cx, cy) =>
            {
                if (IsEligibleForSurvival(cx, cy, world)) {
                    newWorld[cx, cy].Live();
                }
            });

            return newWorld;
        }

        public static bool IsCellAlive(bool cellAlive, int neighbours)
        {
            return !cellAlive ? neighbours == 3 : neighbours == 2 || neighbours == 3;
        }


        #endregion

        #region Private Members

        private bool IsEligibleForSurvival(int x, int y, IWorld world)
        {
            var cell = world[x, y];
            return IsCellAlive(cell.IsAlive, world.GetNumberOfNeighbours(x, y));
        }

        #endregion
    }
}
