namespace MatchThree.Core
{
    public class CellGrid
    {
        #region Fields

        private CellController[,] _collection;

        public CellController this[int row, int col]
        {
            get
            {
                try
                {
                    return _collection[row, col];
                }
                catch (System.Exception)
                {
                    return null;
                }
            }
            set { _collection[row, col] = value; }
        }

        #endregion //Fields

        #region Constructor

        public CellGrid(int rowCount, int colCount)
        {
            _collection = new CellController[rowCount, colCount];
        }

        #endregion //Constructor
    }
}
