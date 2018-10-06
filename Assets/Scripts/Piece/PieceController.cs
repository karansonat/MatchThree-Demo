using MatchThree.UI;

namespace MatchThree.Core
{
    public class PieceController
    {
        #region Fields

        private Piece _model;
        private PieceView _view;

        #endregion //Fields

        #region Constructor

        public PieceController(Piece model, PieceView view)
        {
            _model = model;
            _view = view;
        }

        #endregion //Constructor
    }
}
