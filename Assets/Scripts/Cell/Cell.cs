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

        public int Row { get; private set; }
        public int Col { get; private set; }

        #endregion //Fields

        #region Constructor

        public void Initialize(int row, int col)
        {
            Row = row;
            Col = col;
        }

        #endregion //Constructor
    }
}
