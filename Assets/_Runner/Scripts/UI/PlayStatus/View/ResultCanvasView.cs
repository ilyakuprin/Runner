using UnityEngine;

namespace UI
{
    public class ResultCanvasView : MonoBehaviour
    {
        [SerializeField] private Canvas _winCanvas;

        public void SetActive(bool value)
            => _winCanvas.gameObject.SetActive(value);
    }
}
