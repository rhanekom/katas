namespace GameOfLife
{
    using System.Text;

    public class WorldPrinter : IWorldPrinter
    {
        #region IWorldPrinter Members

        public string Print(IWorld world)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < world.Width; i++)
            {
                for (int j = 0; j < world.Height; j++)
                {
                    sb.Append(world[i, j]);
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        #endregion
    }
}
