using Block;
using UnityEngine;

namespace Road
{
    public class RoadView : MonoBehaviour
    {
        [field: SerializeField] public Transform Road { get; private set; }
        [field: SerializeField] public BlockView FinalBlock { get; private set; }
    }
}
