using UnityEngine;

namespace ScriptableObj
{
    [CreateAssetMenu(fileName = "ObstacleDamageConfig", menuName = "Configs/ObstacleDamageConfig")]
    public class ObstacleDamageConfig : ScriptableObject
    {
        [field: SerializeField, Range(1, 10)] public int Damage { get; private set; }
    }
}
