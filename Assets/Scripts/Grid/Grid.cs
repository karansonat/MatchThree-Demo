using UnityEngine;

namespace MatchThree.Core
{
    [CreateAssetMenu(menuName = "MatchThree/Create Grid", fileName = "NewGrid.asset")]
    public class Grid : ScriptableObject
    {
        #region Fields

        public int Size { get; private set; }

        public float CellViewSize { get; private set; }

        public CellGrid Cells;

        #endregion //Fields

        #region Public Methods

        public void Initialize(int gridSize)
        {
            Size = gridSize;

            CreateGrid();
            CalculateCellSize();
        }

        #endregion //Public Methods

        #region Private Methods

        private void CreateGrid()
        {
            Debug.Log(string.Format("Creating a {0} x {0} grid", Size));
            Cells = new CellGrid(Size, Size);
        }

        private void CalculateCellSize()
        {
            var aspectRatio = (float)Screen.width / (float)Screen.height;

            //Match Height
            if (aspectRatio > 1f)
            {
                CellViewSize = (float)Screen.height / (float)Size;
            }
            //Match Widht
            else
            {
                CellViewSize = (float)Screen.width / (float)Size;
            }
        }

        #endregion //Private Methods
    }
}
