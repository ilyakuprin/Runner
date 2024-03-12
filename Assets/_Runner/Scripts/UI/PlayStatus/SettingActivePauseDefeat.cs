using System;
using Inputting;
using MainHero;
using Road;
using Zenject;

namespace UI
{
    public class SettingActivePauseDefeat : IInitializable, IDisposable
    {
        private readonly PlayerInput _playerInput;
        private readonly MovingRoad _movingRoad;
        private readonly GettingSpeed _gettingSpeed;
        private readonly GettingInvulnerability _gettingInvulnerability;
        private readonly HealthChanging _healthChanging;
        private readonly ContinuationGameForAd _continuationGameForAd;

        public SettingActivePauseDefeat(PlayerInput playerInput,
                           MovingRoad movingRoad,
                           GettingSpeed gettingSpeed,
                           GettingInvulnerability gettingInvulnerability,
                           HealthChanging healthChanging,
                           ContinuationGameForAd continuationGameForAd)
        {
            _playerInput = playerInput;
            _movingRoad = movingRoad;
            _gettingSpeed = gettingSpeed;
            _gettingInvulnerability = gettingInvulnerability;
            _healthChanging = healthChanging;
            _continuationGameForAd = continuationGameForAd;
        }

        public void Initialize()
        {
            _healthChanging.Dead += PauseEnabled;
            _continuationGameForAd.Continued += PauseDisabled;
        }

        public void Dispose()
        {
            _healthChanging.Dead -= PauseEnabled;
            _continuationGameForAd.Continued -= PauseDisabled;
        }

        private void PauseEnabled()
        {
            _playerInput.SetPause(true);
            _gettingSpeed.ResetBoost();
            _gettingInvulnerability.ResetBoost();
            _movingRoad.StopMove();
        }

        private void PauseDisabled()
        {
            _playerInput.SetPause(false);
            _movingRoad.StartMove();
            _healthChanging.TakeHeal(_healthChanging.MaxHealth);
        }
    }
}
