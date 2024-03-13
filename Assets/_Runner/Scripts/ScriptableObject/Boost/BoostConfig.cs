using System;
using System.Linq;
using Boosts;
using UnityEngine;

namespace ScriptableObj
{
    [Serializable]
    public struct BoostDropChance
    {
        public EnumNameBoost BoostName;
        [Tooltip("0 - zero probability, 100 - 100% probability"),
         Range(0, 100)] public int Chance;
    }

    [CreateAssetMenu(fileName = "BoostConfig", menuName = "Configs/BoostConfig")]
    public class BoostConfig : PoolConfig
    {
        [HideInInspector] public int OneHundred = 100;

        [field: Tooltip("0 - zero probability, 100 - 100% probability"),
                SerializeField, Range(0, 100)] public int BoostProbability { get; private set; }

        [Tooltip("The chance of all boosts should be 100 in total"),
         SerializeField] private BoostDropChance[] _boostDropChance;

        [field: SerializeField, Range(0f, 2f)] public float PositionHeight { get; private set; }

        public int GetLength => _boostDropChance.Length;

        public BoostDropChance GetChance(int index)
            => _boostDropChance[index];

        private void OnValidate()
        {
            CheckingSumChance();
            CheckingDistinct();
        }

        private void CheckingSumChance()
        {
            var sumChance = 0;

            for (var i = 0; i < _boostDropChance.Length; i++)
            {
                sumChance += _boostDropChance[i].Chance;
            }

            if (sumChance != 100)
                Debug.LogError("The sum of the chances does not equal 100");
        }

        private void CheckingDistinct()
        {
            var distinct = _boostDropChance.Distinct();

            if (distinct.Count() != GetLength)
                Debug.LogError("There are repeating elements");
        }
    }
}
