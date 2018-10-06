using MatchThree.UI;
using UnityEngine;

namespace MatchThree.Core
{
    public class GridController
    {
        #region Fields

        private Grid _model;
        private GridView _view;

        #endregion //Fields

        #region Constructor

        public GridController(Grid model, GridView view)
        {
            _model = model;
            _view = view;
        }

        #endregion //Constructor

        #region Public Methods

        public void Initalize()
        {
            _model.Initialize();
            _view.Initialize(_model);
            InitializeCells();
        }

        #endregion //Public Methods

        #region Private Methods

        private void InitializeCells()
        {
            for (int row = 0; row < _model.Size; row++) 
            {
                for (int col = 0; col < _model.Size; col++)
                {
                    var cell = CellFactory.Instance.CreateModel("RedCell");
                    var cellView = CellFactory.Instance.CreateView();
                    var cellController = CellFactory.Instance.CreateController(cell, cellView);
                    _view.AddCellView(cellView, row, col);
                    _model.Cells[row, col] = cellController;
                }
            }
        }

        #endregion //Private Methods
    }
}
