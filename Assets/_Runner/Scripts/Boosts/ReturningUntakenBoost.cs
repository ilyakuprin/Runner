using System;
using Road;
using Zenject;

namespace Boosts
{
    public class ReturningUntakenBoost : IInitializable, IDisposable
    {
        private readonly CreatingRoad _creatingRoad;
        private readonly CreatingBoost _creatingBoost;
        private readonly StorageBoost _storageBoost;

        public ReturningUntakenBoost(CreatingRoad creatingRoad,
                                     CreatingBoost creatingBoost,
                                     StorageBoost storageBoost)
        {
            _creatingRoad = creatingRoad;
            _creatingBoost = creatingBoost;
            _storageBoost = storageBoost;
        }

        public void Initialize()
            => _creatingRoad.Returned += Return;

        public void Dispose()
            => _creatingRoad.Returned -= Return;

        private void Return()
        {
            if (!_creatingBoost.TryGetFirstBoostOnRoad(out var boostView)) return;
            if (boostView.gameObject.activeInHierarchy) return;
            
            _storageBoost.ReturnObj(boostView);
            _creatingBoost.SetNextIndex();
        }
    }
}