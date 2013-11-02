using System.Text;

namespace GameOfLife
{
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
                    var printChar = GetPrintChar(world[i, j]);
                    sb.Append(printChar);
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        #endregion

        #region Private Members

        private static string GetPrintChar(ICell cell)
        {
            return cell != null ? "*" : " ";
        }

        #endregion
    }
}
