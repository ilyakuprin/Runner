using UnityEngine;

namespace ScriptableObj
{
    [CreateAssetMenu(fileName = "HealConfig", menuName = "Configs/HealConfig")]
    public class HealConfig : ScriptableObject
    {
        [field: SerializeField, Min(1)] public int Heal { get; private set; }
    }
}
