using MatchThree.UI;
using System;
using UnityEngine;

namespace MatchThree.Core
{
    public class GridController : IObservable<CellButtonPressedArgs>, IObserver<CellButtonPressedArgs>
    {
        #region Fields

        private Grid _model;
        private GridView _view;

        private event EventHandler<CellButtonPressedArgs> _cellButtonPressed;

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
            CreateCells();
        }

        #endregion //Public Methods

        #region Private Methods

        private void CreateCells()
        {
            for (int row = 0; row < _model.Size; row++) 
            {
                for (int col = 0; col < _model.Size; col++)
                {
                    var cell = CellFactory.Instance.CreateModel("RedCell");
                    cell.Initialize(row, col);
                    var cellView = CellFactory.Instance.CreateView();
                    var cellController = CellFactory.Instance.CreateController(cell, cellView);
                    _view.AddCellView(cellView, row, col);
                    _model.Cells[row, col] = cellController;

                    (cellView as IObservable<CellButtonPressedArgs>).Attach(this as IObserver<CellButtonPressedArgs>);
                }
            }
        }

        #endregion //Private Methods

        #region IObservable Interface

        void IObservable<CellButtonPressedArgs>.Attach(IObserver<CellButtonPressedArgs> observer)
        {
            _cellButtonPressed += observer.OnNotified;
        }

        void IObservable<CellButtonPressedArgs>.Detach(IObserver<CellButtonPressedArgs> observer)
        {
            _cellButtonPressed -= observer.OnNotified;
        }

        void IObservable<CellButtonPressedArgs>.Notify(CellButtonPressedArgs eventArgs)
        {
            if (_cellButtonPressed != null)
            {
                _cellButtonPressed.Invoke(this, eventArgs);
            }
        }

        #endregion //IObservable Interface

        #region IObserver Interface

        void IObserver<CellButtonPressedArgs>.OnNotified(object sender, CellButtonPressedArgs eventArgs)
        {
            (this as IObservable<CellButtonPressedArgs>).Notify(eventArgs);

            Debug.Log(string.Format("User click Cell ({0},{1})", eventArgs.Row, eventArgs.Col));
        }

        #endregion //IObserver Interface
    }
}
