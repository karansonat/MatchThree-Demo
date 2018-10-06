using UnityEngine;

namespace MatchThree.Core
{
    [CreateAssetMenu(menuName = "MatchThree/Create Cell", fileName = "NewCell.asset")]
    public class Cell : ScriptableObject
    {
        #region Fields

        [SerializeField] private Sprite _sprite;
        public Sprite Sprite
        {
            get { return _sprite; }
        }

        private Piece _piece;
        public Piece Piece
        {
            get { return _piece; }
        }

        public bool HasPiece
        {
            get { return _piece != null; }
        }

        #endregion //Fields

        #region Public Methods

        public void SetPiece(Piece piece)
        {
            _piece = piece;
        }

        #endregion //Public Methods
    }
}
