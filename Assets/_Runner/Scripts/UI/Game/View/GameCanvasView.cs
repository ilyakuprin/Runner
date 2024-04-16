using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameCanvasView : MonoBehaviour
    {
        [SerializeField] private Image[] _hearts;
        [field: SerializeField] public Image Vignette { get; private set; }
        [field: SerializeField] public TextMeshProUGUI Ammo { get; private set; }
        [field: SerializeField] public TextMeshProUGUI Scoring { get; private set; }

        public int LengthArrayHearts => _hearts.Length;

        public Image GetHeart(int index)
            => _hearts[index];
    }
}
