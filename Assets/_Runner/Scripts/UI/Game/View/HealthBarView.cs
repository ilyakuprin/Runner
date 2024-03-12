using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthBarView : MonoBehaviour
    {
        [field: SerializeField] public Image Bar { get; private set; }
    }
}
