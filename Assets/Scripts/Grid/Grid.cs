using UnityEngine;

namespace MatchThree.Core
{
    [CreateAssetMenu(menuName = "MatchThree/Create Grid", fileName = "NewGrid.asset")]
    public class Grid : ScriptableObject
    {
        #region Fields

        [SerializeField] private int _size;
        public int Size
        {
            get { return _size; }
        }

        private float _cellViewSize;
        public float CellViewSize
        {
            get { return _cellViewSize; }
        }

        public CellGrid Cells;

        #endregion //Fields

        #region Public Methods

        public void Initialize()
        {
            CreateGrid();
            CalculateCellSize();
        }

        #endregion //Public Methods

        #region Private Methods

        private void CreateGrid()
        {
            Debug.Log(string.Format("Creating a {0} x {0} grid", _size));
            Cells = new CellGrid(_size, _size);
        }

        private void CalculateCellSize()
        {
            var aspectRatio = (float)Screen.width / (float)Screen.height;

            //Match Height
            if (aspectRatio > 1f)
            {
                _cellViewSize = (float)Screen.height / (float)_size;
            }
            //Match Widht
            else
            {
                _cellViewSize = (float)Screen.width / (float)_size;
            }
        }

        #endregion //Private Methods
    }
}
