using UnityEngine;

namespace ScriptableObj
{
    [CreateAssetMenu(fileName = "RoadConfig", menuName = "Configs/RoadConfig")]
    public class RoadConfig : PoolConfig
    {
        [field: SerializeField, Range(1, 20)] public int NumberVisibleBlocks { get; private set; }
    }
}
