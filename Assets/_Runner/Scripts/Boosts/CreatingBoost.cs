using System;
using Block;
using PoolObjects;
using ScriptableObj;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Boosts
{
    public class CreatingBoost
    {
        private readonly BoostConfig _boostConfig;
        private readonly StorageBoost _storageBoost;
        private readonly BoostView[] _boostView;
        
        private int _firstBoostOnRoadIndex;
        private int _lastBoostOnRoadIndex;

        public CreatingBoost(BoostConfig boostConfig,
                             StorageBoost storageBoost,
                             RoadConfig roadConfig)
        {
            _boostConfig = boostConfig;
            _storageBoost = storageBoost;

            _boostView = new BoostView[roadConfig.NumberVisibleBlocks];
        }

        public void Create(BlockView block)
        {
            if (!IsProbabilityPositive()) return;

            var boost = GetRandomBoost();
            _boostView[_lastBoostOnRoadIndex] = boost;
            _lastBoostOnRoadIndex = GetNextIndex(_lastBoostOnRoadIndex);

            SetParent(boost, block);
            SetRotation(boost, block);
            SetPosition(boost, block);
        }
        
        public bool TryGetFirstBoostOnRoad(out BoostView boostView)
        {
            boostView = default;
            if (_boostView[_firstBoostOnRoadIndex] == null) return false;
            
            boostView = _boostView[_firstBoostOnRoadIndex];
            return true;
        }

        public void SetNextIndex()
        {
            _boostView[_firstBoostOnRoadIndex] = null;
            _firstBoostOnRoadIndex = GetNextIndex(_firstBoostOnRoadIndex);
        }

        private int GetNextIndex(int index)
            => (index + 1) % _boostView.Length;

        private bool IsProbabilityPositive()
            => GetRandomProbability() <= _boostConfig.BoostProbability;

        private int GetRandomProbability()
            => Random.Range(0, _boostConfig.OneHundred + 1);

        private BoostView GetRandomBoost()
        {
            var sumChance = 0;
            var randomChance = GetRandomProbability();
            
            for (var i = 0; i < _boostConfig.GetLength; i++)
            {
                var boostDropChance = _boostConfig.GetChance(i);

                sumChance += boostDropChance.Chance;

                if (randomChance <= sumChance)
                {
                    return _storageBoost.GetObj((int)boostDropChance.BoostName);
                }
            }

            throw new Exception("Sum all chance = " + sumChance);
        }

        private static void SetParent(IPoolable boost, IPoolable block)
            => boost.GetTransform.parent = block.GetTransform;

        private static void SetRotation(IPoolable boost, IPoolable block)
            => boost.GetTransform.rotation = block.GetTransform.rotation;

        private void SetPosition(IPoolable boost, BlockView block)
        {
            var position = Vector3.zero;
            position.y = _boostConfig.PositionHeight;
            position.z = block.GetEnd.localPosition.z / 2;
            boost.GetTransform.localPosition = position;
        }
    }
}
