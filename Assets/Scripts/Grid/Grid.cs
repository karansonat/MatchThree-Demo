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

        public CellGrid Cells;

        #endregion //Fields

        #region Public Methods

        public void Initialize()
        {
            CreateGrid();
        }

        #endregion //Public Methods

        #region Private Methods

        private void CreateGrid()
        {
            Debug.Log(string.Format("Creating a {0} x {0} grid", _size));
            Cells = new CellGrid(_size, _size);
        }

        #endregion //Private Methods
    }
}
