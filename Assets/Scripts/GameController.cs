using System.Collections;
using UnityEngine;

namespace MatchThree.Core
{
    public class GameController : MonoBehaviour, IObserver<MatchFoundArgs>, IObserver<CellButtonPressedArgs>
    {
        #region Singleton

        private static GameController _instance = new GameController();
        public static GameController Instance
        {
            get { return _instance; }
        }

        static GameController()
        {
        }

        private GameController()
        {
        }

        #endregion //Singleton

        #region Fields

        private GridController _gridController;

        #endregion //Fields

        #region Unity Methods

        private void Awake()
        {
            Initialize();
        }

        #endregion //Unity Methods

        #region Private Methods

        private void Initialize()
        {
            InitializeGridController();
        }

        private void InitializeGridController()
        {
            var model = GridFactory.Instance.CreateModel("DefaultGrid");
            var view = GridFactory.Instance.CreateView();
            _gridController = GridFactory.Instance.CreateController(model, view);
            _gridController.Initalize();

            (_gridController as IObservable<CellButtonPressedArgs>).Attach(this as IObserver<CellButtonPressedArgs>);
            (_gridController as IObservable<MatchFoundArgs>).Attach(this as IObserver<MatchFoundArgs>);
        }

        #endregion //Private Methods

        #region IObserver Interface

        void IObserver<MatchFoundArgs>.OnNotified(object sender, MatchFoundArgs eventArgs)
        {
            _gridController.ClearCells(eventArgs.MatchedCells);
        }

        void IObserver<CellButtonPressedArgs>.OnNotified(object sender, CellButtonPressedArgs eventArgs)
        {
            _gridController.ChechForMatch();
        }

        #endregion //IObserver Interface
    }
}
