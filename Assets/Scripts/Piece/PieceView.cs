using MatchThree.Core;
using UnityEngine;
using UnityEngine.UI;

namespace MatchThree.UI
{
    public class PieceView : MonoBehaviour
    {
        #region Fields

        private Piece _model;
        [SerializeField] private Image _pieceImage;

        #endregion //Fields

        #region Public Methods

        public void Initialize(Piece model)
        {
            _model = model;
            _pieceImage.sprite = _model.Sprite;
        }

        #endregion
    }
}
