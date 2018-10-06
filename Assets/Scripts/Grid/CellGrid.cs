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
            get { return _collection[row, col]; }
            set { _collection[row, col] = value; }
        }
    }
}
