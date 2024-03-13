using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class WinCanvasView : MonoBehaviour
    {
        [field: SerializeField] public GameObject WinObj { get; private set; }
        [field: SerializeField] public Button NextLvlButton { get; private set; }
    }
}
