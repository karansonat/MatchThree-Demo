using MatchThree.UI;
using UnityEngine;

namespace MatchThree.Core
{
    public class PieceFactory
    {
        #region Singleton

        private static PieceFactory _instance = new PieceFactory();
        public static PieceFactory Instance
        {
            get { return _instance; }
        }

        static PieceFactory()
        {
        }

        private PieceFactory()
        {
        }

        #endregion //Singleton

        #region Factory Methods

        public Piece CreateModel(string resourceName)
        {
            var model = Resources.Load<Piece>("Models/" + resourceName);
            return Object.Instantiate(model);
        }

        public PieceView CreateView()
        {
            var view = Resources.Load<GameObject>("Prefabs/PieceView");
            return Object.Instantiate(view).GetComponent<PieceView>();
        }

        public PieceController CreateController(Piece model, PieceView view)
        {
            var controller = new PieceController(model, view);
            return controller;
        }

        #endregion //Factory Methods
    }
}
