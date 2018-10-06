using MatchThree.Core;
using UnityEngine;
using UnityEngine.UI;

namespace MatchThree.UI
{
    public class CellView : MonoBehaviour
    {
        private Cell _model;

        [SerializeField] private Image _imageBackground;

        public void Initialize(Cell model)
        {
            _model = model;
            _imageBackground.sprite = model.Sprite;
        }
    }
}
