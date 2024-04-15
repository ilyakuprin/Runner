using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameCanvasView : MonoBehaviour
    {
        [field: SerializeField] public Image Bar { get; private set; }
        [field: SerializeField] public Image Vignette { get; private set; }
        [field: SerializeField] public TextMeshProUGUI Ammo { get; private set; }
    }
}
