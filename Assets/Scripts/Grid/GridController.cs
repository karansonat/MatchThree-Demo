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
        }

        #endregion //Public Methods

        #region Private Methods

        #endregion //Private Methods
    }
}
