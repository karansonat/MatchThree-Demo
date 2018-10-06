using MatchThree.UI;
using System;

namespace MatchThree.Core
{
    public class CellController : IObservable<CellButtonPressedArgs>, IObserver<CellButtonPressedArgs>
    {
        #region Fields

        private Cell _model;
        private CellView _view;
        private PieceController _pieceController;

        private event EventHandler<CellButtonPressedArgs> _cellButtonPressed;

        #endregion //Fields

        #region Constructor

        public CellController(Cell model, CellView view)
        {
            _model = model;
            _view = view;

            _view.Initialize(_model);

            SubscribeEvents();
        }

        ~CellController()
        {
            UnsubscribeEvents();
        }

        #endregion //Constructor

        #region Public Methods

        #endregion //Public Methods

        #region Private Methods

        private void SubscribeEvents()
        {
            (_view as IObservable<CellButtonPressedArgs>).Attach(this as IObserver<CellButtonPressedArgs>);
        }

        private void UnsubscribeEvents()
        {
            (_view as IObservable<CellButtonPressedArgs>).Detach(this as IObserver<CellButtonPressedArgs>);
        }

        private void ToggleCell()
        {
            if (_pieceController == null)
            {
                var model = PieceFactory.Instance.CreateModel("BlueCross");
                var view = PieceFactory.Instance.CreateView();
                _view.AddPiece(view);
                _pieceController = PieceFactory.Instance.CreateController(model, view);
            }
            else
            {
                _pieceController.RemovePiece();
                _pieceController = null;
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

            ToggleCell();
        }

        #endregion //IObserver Interface
    }
}
