namespace MatchThree.Core
{
    public class CellGrid
    {
        private Cell[,] _collection;
        public CellGrid(int rowCount, int colCount)
        {
            _collection = new Cell[rowCount, colCount];
        }

        public Cell this[int row, int col]
        {
            get { return _collection[row, col]; }
            set { _collection[row, col] = value; }
        }
    }
}
