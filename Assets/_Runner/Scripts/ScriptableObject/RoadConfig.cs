using UnityEngine;

namespace ScriptableObj
{
    [CreateAssetMenu(fileName = "RoadConfig", menuName = "Configs/RoadConfig")]
    public class RoadConfig : ScriptableObject
    {
        [field: SerializeField, Range(1f, 20)] public float Speed { get; private set; }
        [field: SerializeField, Range(1, 10)] public int NumberVisibleBlocks { get; private set; }
    }
}
