using UnityEngine;

namespace MatchThree.Core
{
    [CreateAssetMenu(menuName = "MatchThree/Create Cell", fileName = "NewCell.asset")]
    public class Cell : ScriptableObject
    {
        [SerializeField] private Sprite _sprite;
        public Sprite Sprite
        {
            get { return _sprite; }
        }

        private Piece _piece;
        public Piece Piece
        {
            get { return null; }
            set { _piece = value; }
        }

        public bool HasPiece
        {
            get { return _piece != null; }
        }
    }
}
