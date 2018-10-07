namespace MatchThree.Core
{
    public class CellGrid
    {
        private CellController[,] _collection;
        public CellGrid(int rowCount, int colCount)
        {
            _collection = new CellController[rowCount, colCount];
        }

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
    }
}
