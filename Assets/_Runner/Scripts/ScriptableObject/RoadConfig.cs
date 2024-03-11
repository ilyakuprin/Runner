using UnityEngine;

namespace ScriptableObj
{
    [CreateAssetMenu(fileName = "RoadConfig", menuName = "Configs/RoadConfig")]
    public class RoadConfig : PoolConfig
    {
        [field: SerializeField, Range(1, 7)] public int NumberVisibleBlocks { get; private set; }
        [field: SerializeField, Range(7, 50)] public int NumberAllBlocks { get; private set; }
    }
}
