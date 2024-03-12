using UnityEngine;

namespace ScriptableObj
{
    [CreateAssetMenu(fileName = "SpeedConfig", menuName = "Configs/SpeedConfig")]
    public class SpeedConfig : ScriptableObject
    {
        [field: SerializeField, Min(1f)] public float Modificator { get; private set; }
        [field: SerializeField, Range(0.5f, 50f)] public float TimeActionInSec { get; private set; }
    }
}
