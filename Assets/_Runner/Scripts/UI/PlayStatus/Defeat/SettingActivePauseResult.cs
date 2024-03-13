using System;
using Inputting;
using MainHero;
using Road;
using Zenject;

namespace UI
{
    public class SettingActivePauseResult : IInitializable, IDisposable
    {
        private readonly PlayerInput _playerInput;
        private readonly MovingRoad _movingRoad;
        private readonly GettingSpeed _gettingSpeed;
        private readonly GettingInvulnerability _gettingInvulnerability;
        private readonly HealthChanging _healthChanging;
        private readonly ContinuationGameForAd _continuationGameForAd;
        private readonly ResultCanvasView _resultCanvasView;
        private readonly CollidingWithFinalBlock _collidingWithFinalBlock;

        public SettingActivePauseResult(PlayerInput playerInput,
                                        MovingRoad movingRoad,
                                        GettingSpeed gettingSpeed,
                                        GettingInvulnerability gettingInvulnerability,
                                        HealthChanging healthChanging,
                                        ContinuationGameForAd continuationGameForAd,
                                        ResultCanvasView resultCanvasView,
                                        CollidingWithFinalBlock collidingWithFinalBlock)
        {
            _playerInput = playerInput;
            _movingRoad = movingRoad;
            _gettingSpeed = gettingSpeed;
            _gettingInvulnerability = gettingInvulnerability;
            _healthChanging = healthChanging;
            _continuationGameForAd = continuationGameForAd;
            _resultCanvasView = resultCanvasView;
            _collidingWithFinalBlock = collidingWithFinalBlock;
        }

        public void Initialize()
        {
            _healthChanging.Dead += PauseEnabled;
            _continuationGameForAd.Continued += PauseDisabled;
            _collidingWithFinalBlock.Collided += PauseEnabled;
        }

        public void Dispose()
        {
            _healthChanging.Dead -= PauseEnabled;
            _continuationGameForAd.Continued -= PauseDisabled;
            _collidingWithFinalBlock.Collided -= PauseEnabled;
        }

        private void PauseEnabled()
        {
            _resultCanvasView.SetActive(true);
            _playerInput.SetPause(true);
            _gettingSpeed.ResetBoost();
            _gettingInvulnerability.ResetBoost();
            _movingRoad.StopMove();
        }

        private void PauseDisabled()
        {
            _resultCanvasView.SetActive(false);
            _playerInput.SetPause(false);
            _movingRoad.StartMove();
            _healthChanging.TakeHeal(_healthChanging.MaxHealth);
        }
    }
}
