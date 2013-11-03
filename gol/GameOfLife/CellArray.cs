namespace GameOfLife
{
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class CellArray : IEnumerable<ICell>
    {
        #region Globals

        private readonly ICell[] world;
        private readonly int width;

        #endregion

        #region Construction

        public CellArray(int width, int height)
        {
            this.width = width;

            world = new ICell[width * height];

            for (int i = 0; i < world.Length; i++)
            {
                world[i] = new Cell();
            }
        }

        #endregion

        #region IEnumerable<ICell> Members

        public IEnumerator<ICell> GetEnumerator()
        {
            return ((IList<ICell>)world).GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Public Members

        public ICell this[int x, int y]
        {
            get { return world[Index(x, y)]; }
            set { world[Index(x, y)] = value; }
        }

        #endregion

        #region Private Members

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int Index(int x, int y)
        {
            return x + (y * width);
        }

        #endregion
    }
}
