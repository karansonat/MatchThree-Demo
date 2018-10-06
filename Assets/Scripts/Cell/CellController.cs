using MatchThree.UI;

namespace MatchThree.Core
{
    public class CellController
    {
        #region Fields

        private Cell _model;
        private CellView _view;

        #endregion //Fields

        #region Constructor

        public CellController(Cell model, CellView view)
        {
            _model = model;
            _view = view;

            _view.Initialize(_model);
        }

        #endregion //Constructor
    }
}
