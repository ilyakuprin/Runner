using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MenuCanvasView : MonoBehaviour
    {
        [field: SerializeField] public Button GameButton { get; private set; }
        [field: SerializeField] public TextMeshProUGUI Scoring { get; private set; }
    }
}