using UnityEngine;

namespace ScriptableObj
{
    [CreateAssetMenu(fileName = "BulletConfig", menuName = "Configs/BulletConfig")]
    public class BulletConfig : ScriptableObject
    {
        [field: SerializeField, Min(1)] public int NumberBullet { get; private set; }
    }
}
