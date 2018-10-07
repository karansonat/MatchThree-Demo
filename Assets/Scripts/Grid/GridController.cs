using MatchThree.UI;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MatchThree.Core
{
    public class GridController : IObservable<CellButtonPressedArgs>, IObserver<CellButtonPressedArgs>,
                                  IObservable<MatchFoundArgs>
    {
        #region Fields

        private Grid _model;
        private GridView _view;

        private event EventHandler<CellButtonPressedArgs> _cellButtonPressed;
        private event EventHandler<MatchFoundArgs> _matchFound;

        private readonly Vector2[] _adjacentIndexHelper = new Vector2[]
        {
            new Vector2(0, -1),
            new Vector2(0, +1),
            new Vector2(-1, 0),
            new Vector2(+1, 0),
        };

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

        public void ChechForMatch()
        {
            var matchedCells = SearchForMatch(3);
            if (matchedCells != null)
            {
                (this as IObservable<MatchFoundArgs>).Notify(new MatchFoundArgs(matchedCells));
            }
        }

        public void ClearCells(List<CellController> cellControllers)
        {
            foreach (var cellController in cellControllers)
            {
                cellController.RemovePiece();
            }
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

        private List<CellController> SearchForMatch(int pieceCount)
        {
            var matchedPieces = new List<CellController>();

            for (int row = 0; row < _model.Size; row++)
            {
                for (int col = 0; col < _model.Size; col++)
                {
                    var cellController = _model.Cells[row, col];
                    if (!cellController.HasPiece()) continue;

                    matchedPieces.Clear();
                    matchedPieces.Add(cellController);
                    GetAdjacentCellsWithPieceRecursively(cellController, ref matchedPieces, pieceCount);

                    if (matchedPieces.Count == pieceCount)
                        return matchedPieces;
                }
            }

            return null;
        }

        private void GetAdjacentCellsWithPieceRecursively(CellController cellController, ref List<CellController> matchedCells, int pieceCount)
        {
            var row = cellController.Row;
            var col = cellController.Col;

            foreach (var indexHelper in _adjacentIndexHelper)
            {
                var adjacentCell = _model.Cells[row + (int)indexHelper.x, col + (int)indexHelper.y];
                if (adjacentCell != null && adjacentCell.HasPiece() && !matchedCells.Contains(adjacentCell))
                {
                    matchedCells.Add(adjacentCell);

                    if (matchedCells.Count == pieceCount)
                        return;

                    GetAdjacentCellsWithPieceRecursively(adjacentCell, ref matchedCells, pieceCount);
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

        void IObservable<MatchFoundArgs>.Attach(IObserver<MatchFoundArgs> observer)
        {
            _matchFound += observer.OnNotified;
        }

        void IObservable<MatchFoundArgs>.Detach(IObserver<MatchFoundArgs> observer)
        {
            _matchFound -= observer.OnNotified;
        }

        void IObservable<MatchFoundArgs>.Notify(MatchFoundArgs eventArgs)
        {
            if (_matchFound != null)
            {
                _matchFound.Invoke(this, eventArgs);

            }
        }

        #endregion //IObservable Interface

        #region IObserver Interface

        void IObserver<CellButtonPressedArgs>.OnNotified(object sender, CellButtonPressedArgs eventArgs)
        {
            (this as IObservable<CellButtonPressedArgs>).Notify(eventArgs);
        }

        #endregion //IObserver Interface
    }
}
