using System;
using Boosts;
using UnityEngine;

namespace ScriptableObj
{
    [Serializable]
    public struct BoostDropChance
    {
        public BoostView BoostView;
        [Tooltip("0 - нулевая вероятность, 100 - 100% вероятсноть"),
         Range(0, 100)] public int Chance;
    }

    [CreateAssetMenu(fileName = "BoostConfig", menuName = "Configs/BoostConfig")]
    public class BoostConfig : ScriptableObject
    {
        [field: Tooltip("0 - нулевая вероятность, 100 - 100% вероятсноть"),
                SerializeField, Range(0, 100)] public int BoostProbability { get; private set; }

        [Tooltip("Шанс всех бустов должен быть в сумме 100"), SerializeField] private BoostDropChance[] _boostDropChance;

        private void OnValidate()
        {
            var sumChance = 0;

            for (var i = 0; i < _boostDropChance.Length; i++)
            {
                sumChance += _boostDropChance[i].Chance;
            }

            if (sumChance != 100)
                Debug.LogError("Сумма шансов не равна 100");
        }
    }
}
