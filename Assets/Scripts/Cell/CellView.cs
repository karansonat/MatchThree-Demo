using MatchThree.Core;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace MatchThree.UI
{
    public class CellView : MonoBehaviour, IObservable<CellButtonPressedArgs>
    {
        #region Fields

        private Cell _model;

        [SerializeField] private Image _imageBackground;
        [SerializeField] private Button _buttonCell;
        [SerializeField] private Transform _pieceContainer;

        private event EventHandler<CellButtonPressedArgs> _cellButtonPressed;

        #endregion //Fields

        #region Public Methods

        public void Initialize(Cell model)
        {
            _model = model;
            _imageBackground.sprite = model.Sprite;

            _buttonCell.onClick.RemoveAllListeners();
            _buttonCell.onClick.AddListener(OnClick);
        }

        public void AddPiece(PieceView view)
        {
            view.transform.SetParent(_pieceContainer, false);
        }

        #endregion //Public Methods

        #region Private Methods

        private void OnClick()
        {
            var args = new CellButtonPressedArgs { Row = _model.Row, Col = _model.Col };
            (this as IObservable<CellButtonPressedArgs>).Notify(args);
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
    }
}
