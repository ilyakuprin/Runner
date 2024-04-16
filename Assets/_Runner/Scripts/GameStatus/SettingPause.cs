using System;
using Inputting;
using MainHero;
using Road;
using Zenject;

namespace GameStatus
{
    public class SettingPause : IInitializable, IDisposable
    {
        private readonly PlayerInput _playerInput;
        private readonly MovingRoad _movingRoad;
        private readonly HealthChanging _healthChanging;

        public SettingPause(PlayerInput playerInput,
                            MovingRoad movingRoad,
                            HealthChanging healthChanging)
        {
            _playerInput = playerInput;
            _movingRoad = movingRoad;
            _healthChanging = healthChanging;
        }

        public void Initialize()
            => _healthChanging.Dead += PauseEnabled;

        public void Dispose()
            => _healthChanging.Dead -= PauseEnabled;

        private void PauseEnabled()
        {
            _playerInput.SetPause(true);
            _movingRoad.StopMove();
        }
    }
}
