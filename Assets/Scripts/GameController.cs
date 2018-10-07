using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchThree.Core
{
    public class GameController : MonoBehaviour, IObserver<MatchCheckCompletedArgs>, IObserver<CellButtonPressedArgs>
    {
        public static GameController Instance { get; private set; }

        #region Fields

        public GameSettings GameSettings;
        private GridController _gridController;
        private GameState _state;
        public bool IsInputEnabled { get; private set; }
        private List<CellController> _matchedCells;

        #endregion //Fields

        #region Unity Methods

        private void Awake()
        {
            #region Singleton

            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }

            #endregion //Singleton

            Initialize();
        }

        #endregion //Unity Methods

        #region Private Methods

        private IEnumerator GameStateMachine()
        {
            while (true)
            {
                switch (_state)
                {
                    case GameState.WaitingForInput:
                        Debug.Log(_state.ToString());
                        while (IsInputEnabled)
                            yield return null;
                        break;
                    case GameState.CheckForMatch:
                        Debug.Log(_state.ToString());
                        _gridController.ChechForMatch();
                        break;
                    case GameState.UpdateBoard:
                        Debug.Log(_state.ToString());
                        yield return new WaitForSeconds(GameSettings.DelayBeforeClearMatch);
                        _gridController.ClearCells(_matchedCells);
                        IsInputEnabled = true;
                        _state = GameState.WaitingForInput;
                        break;
                }
            }
        }

        private void Initialize()
        {
            _state = GameState.WaitingForInput;
            IsInputEnabled = true;
            InitializeGridController();
            StartCoroutine(GameStateMachine());
        }

        private void InitializeGridController()
        {
            var model = GridFactory.Instance.CreateModel("DefaultGrid");
            var view = GridFactory.Instance.CreateView();
            _gridController = GridFactory.Instance.CreateController(model, view);
            _gridController.Initalize();

            (_gridController as IObservable<CellButtonPressedArgs>).Attach(this as IObserver<CellButtonPressedArgs>);
            (_gridController as IObservable<MatchCheckCompletedArgs>).Attach(this as IObserver<MatchCheckCompletedArgs>);
        }

        #endregion //Private Methods

        #region IObserver Interface

        void IObserver<MatchCheckCompletedArgs>.OnNotified(object sender, MatchCheckCompletedArgs eventArgs)
        {
            if (eventArgs.MatchedCells != null)
            {
                _matchedCells = eventArgs.MatchedCells;
                _state = GameState.UpdateBoard;
            }
            else
            {
                IsInputEnabled = true;
                _state = GameState.WaitingForInput;
            }
        }

        void IObserver<CellButtonPressedArgs>.OnNotified(object sender, CellButtonPressedArgs eventArgs)
        {
            IsInputEnabled = false;
            _state = GameState.CheckForMatch;
        }

        #endregion //IObserver Interface
    }
}
