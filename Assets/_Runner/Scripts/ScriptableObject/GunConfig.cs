using UnityEngine;

namespace ScriptableObj
{
    [CreateAssetMenu(fileName = "GunConfig", menuName = "Configs/GunConfig")]
    public class GunConfig : ScriptableObject
    {
        [field: SerializeField, Range(0.1f, 5f)] public float ShotDelay { get; private set; }
        [field: SerializeField, Range(1, 30)] public int MaxAmmo { get; private set; }
        [field: SerializeField, Range(1, 30)] public int StartAmmo { get; private set; }

        private void OnValidate()
        {
            if (StartAmmo > MaxAmmo)
                StartAmmo = MaxAmmo;
        }
    }
}