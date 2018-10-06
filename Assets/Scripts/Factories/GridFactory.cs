using MatchThree.UI;
using UnityEngine;

namespace MatchThree.Core
{
    public class GridFactory
    {
        #region Singleton

        private static GridFactory _instance = new GridFactory();
        public static GridFactory Instance
        {
            get { return _instance; }
        }

        static GridFactory()
        {
        }

        private GridFactory()
        {
        }

        #endregion //Singleton

        #region Factory Methods

        public Grid CreateModel(string resourceName)
        {
            var model = Resources.Load<Grid>("Models/" + resourceName);
            return Object.Instantiate(model);
        }

        public GridView CreateView()
        {
            var view = Resources.Load<GameObject>("Prefabs/GridView");
            return Object.Instantiate(view).GetComponent<GridView>();
        }

        public GridController CreateController(Grid model, GridView view)
        {
            var controller = new GridController(model, view);
            return controller;
        }

        #endregion //Factory Methods
    }
}
