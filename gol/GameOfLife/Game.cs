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

        #region Public Members

        public void Run(IWorld world, int iterations)
        {
            int currentIteration = 0;

            while (currentIteration < iterations)
            {
                userInterface.Write(world.ToString());
                world = world.NextIteration();
                currentIteration++;
            }
        }

        #endregion
    }
}
