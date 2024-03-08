using UnityEngine;

namespace ScriptableObj
{
    [CreateAssetMenu(fileName = "RoadConfig", menuName = "Configs/RoadConfig")]
    public class RoadConfig : ScriptableObject
    {
        [field: SerializeField, Range(1f, 20f)] public float Speed { get; private set; }
        [field: SerializeField, Range(1, 7)] public int NumberVisibleBlocks { get; private set; }
        [field: SerializeField, Range(7, 50)] public int NumberAllBlocks { get; private set; }
    }
}
