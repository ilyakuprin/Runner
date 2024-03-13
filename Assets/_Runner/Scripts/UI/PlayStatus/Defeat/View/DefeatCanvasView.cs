using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DefeatCanvasView : MonoBehaviour
    {
        [field: SerializeField] public GameObject DefeatObj { get; private set; }
        [field: SerializeField] public Button RestartButton { get; private set; }
        [field: SerializeField] public Button AdButton { get; private set; }
    }
}
