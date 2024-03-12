using UnityEngine;

namespace ScriptableObj
{
    [CreateAssetMenu(fileName = "MovementAfterAdConfig", menuName = "Configs/MovementAfterAdConfig")]
    public class MovementAfterAdConfig : ScriptableObject
    {
        [field: SerializeField, Range(0.1f, 1f)] public float StartingSpeedModificator { get; private set; }
        [field: SerializeField, Range(0.1f, 5f)] public float ReturnToStandardSpeedInSec { get; private set; }
    }
}
