using UnityEngine;

namespace MatchThree.Core
{
    [CreateAssetMenu(menuName = "MatchThree/Create Settings", fileName = "NewSettings.asset")]
    public class GameSettings : ScriptableObject
    {
        [SerializeField] private int _gridSize = 2;
        public int GridSize
        {
            get { return _gridSize; }
        }

        [SerializeField] private int _minMatchPieceCount;
        public int MinMatchPieceCount
        {
            get { return _minMatchPieceCount; }
        }

        [SerializeField] private bool _allowBetterMatches;
        public bool AllowBetterMatches
        {
            get { return _allowBetterMatches; }
        }

        [SerializeField] [Range(0.1f, 0.5f)] private float _delayBeforeClearMatch = 0.1f;
        public float DelayBeforeClearMatch
        {
            get { return _delayBeforeClearMatch; }
        }
    }
}
