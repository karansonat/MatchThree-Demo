using UnityEngine;
using MatchThree.Core;
using Grid = MatchThree.Core.Grid;

namespace MatchThree.UI
{
    public class GridView : MonoBehaviour
    {
        #region Fields

        private Grid _model;
        private Vector2 _cellViewStartPosition;

        [SerializeField] private Transform _cellsContainer;

        #endregion //Fields

        #region Public Methods

        public void Initialize(Grid model)
        {
            _model = model;

            _cellViewStartPosition = new Vector2(
                -(_model.Size - 1) / 2f * _model.CellViewSize,
                (_model.Size - 1) / 2f * _model.CellViewSize
                );
        }

        #endregion //Public Methods

        #region Private Methods

        public void AddCellView(CellView cellView, int row, int col)
        {
            cellView.gameObject.name += string.Format(" ({0}, {1})", row, col);
            cellView.transform.SetParent(_cellsContainer, false);
            (cellView.transform as RectTransform).sizeDelta = _model.CellViewSize * Vector2.one;
            (cellView.transform as RectTransform).anchoredPosition = new Vector2
                (
                _cellViewStartPosition.x + (_model.CellViewSize * col),
                _cellViewStartPosition.y - (_model.CellViewSize * row)
                );
        }

        #endregion //Private Methods
    }
}
