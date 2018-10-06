using MatchThree.UI;
using UnityEngine;

namespace MatchThree.Core
{
    public class CellFactory
    {
        #region Singleton

        private static CellFactory _instance = new CellFactory();
        public static CellFactory Instance
        {
            get { return _instance; }
        }

        static CellFactory()
        {
        }

        private CellFactory()
        {
        }

        #endregion //Singleton

        #region Factory Methods

        public Cell CreateModel(string resourceName)
        {
            var model = Resources.Load<Cell>("Models/" + resourceName);
            return Object.Instantiate(model);
        }

        public CellView CreateView()
        {
            var view = Resources.Load<GameObject>("Prefabs/CellView");
            return Object.Instantiate(view).GetComponent<CellView>();
        }

        public CellController CreateController(Cell model, CellView view)
        {
            var controller = new CellController(model, view);
            return controller;
        }

        #endregion //Factory Methods
    }
}
