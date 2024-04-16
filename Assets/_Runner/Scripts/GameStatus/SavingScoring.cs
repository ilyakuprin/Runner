using System;
using MainHero;
using Road;
using Zenject;

namespace GameStatus
{
    public class SavingScoring : IInitializable, IDisposable
    {
        public event Action ScoringUpdated;
        
        private readonly InteractingWithSaves _interactingWithSaves;
        private readonly LoadingSaves _loadingSaves;
        private readonly ObstacleCounting _obstacleCounting;
        private readonly HealthChanging _healthChanging;
        
        public SavingScoring(InteractingWithSaves interactingWithSaves,
                             LoadingSaves loadingSaves,
                             ObstacleCounting obstacleCounting,
                             HealthChanging healthChanging)
        {
            _interactingWithSaves = interactingWithSaves;
            _loadingSaves = loadingSaves;
            _obstacleCounting = obstacleCounting;
            _healthChanging = healthChanging;
        }

        public void Initialize()
            => _healthChanging.Dead += Save;

        public void Dispose()
            => _healthChanging.Dead -= Save;

        private void Save()
        {
            var gameData = _loadingSaves.GameData;
            if (_obstacleCounting.Counter <= gameData.Scoring) return;
            
            gameData.Scoring = _obstacleCounting.Counter;
            _interactingWithSaves.Save(gameData);
            _loadingSaves.Initialize();
            ScoringUpdated?.Invoke();
        }
    }
}