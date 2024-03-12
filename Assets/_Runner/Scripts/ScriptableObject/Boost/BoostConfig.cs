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
        [Tooltip("0 - ������� �����������, 100 - 100% �����������"),
         Range(0, 100)] public int Chance;
    }

    [CreateAssetMenu(fileName = "BoostConfig", menuName = "Configs/BoostConfig")]
    public class BoostConfig : PoolConfig
    {
        public int OneHundred = 100;

        [field: Tooltip("0 - ������� �����������, 100 - 100% �����������"),
                SerializeField, Range(0, 100)] public int BoostProbability { get; private set; }

        [Tooltip("���� ���� ������ ������ ���� � ����� 100"),
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
                Debug.LogError("����� ������ �� ����� 100");
        }

        private void CheckingDistinct()
        {
            var distinct = _boostDropChance.Distinct();

            if (distinct.Count() != GetLength)
                Debug.LogError("���� ������������� ��������");
        }
    }
}
