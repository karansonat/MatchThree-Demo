using UnityEngine;

namespace MatchThree.Core
{
    [CreateAssetMenu(menuName = "MatchThree/Create Piece", fileName = "NewPiece.asset")]
    public class Piece : ScriptableObject
    {
        [SerializeField] private Sprite _sprite;
        public Sprite Sprite
        {
            get { return _sprite; }
        }
    }
}
