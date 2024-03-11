using System;
using Boosts;
using UnityEngine;

namespace ScriptableObj
{
    [Serializable]
    public struct BoostDropChance
    {
        public EnumNameBoost BoostName;
        [Tooltip("0 - ������� �����������, 100 - 100% �����������"),
         Range(0, 100)] public int Chance;
    }

    [CreateAssetMenu(fileName = "BoostConfig", menuName = "Configs/BoostConfig")]
    public class BoostConfig : PoolConfig
    {
        [field: Tooltip("0 - ������� �����������, 100 - 100% �����������"),
                SerializeField, Range(0, 100)] public int BoostProbability { get; private set; }

        [Tooltip("���� ���� ������ ������ ���� � ����� 100"), SerializeField] private BoostDropChance[] _boostDropChance;

        private void OnValidate()
        {
            var sumChance = 0;

            for (var i = 0; i < _boostDropChance.Length; i++)
            {
                sumChance += _boostDropChance[i].Chance;
            }

            if (sumChance != 100)
                Debug.LogError("����� ������ �� ����� 100");
        }
    }
}
