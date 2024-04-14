using UnityEngine;

namespace ScriptableObj
{
    [CreateAssetMenu(fileName = "GunConfig", menuName = "Configs/GunConfig")]
    public class GunConfig : ScriptableObject
    {
        [field: SerializeField, Range(0.1f, 5f)] public float ShotDelay { get; private set; }
    }
}