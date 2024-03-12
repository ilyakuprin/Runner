using Cysharp.Threading.Tasks;
using MainHero;
using ScriptableObj;
using System;
using System.Threading;
using UI;
using UnityEngine;
using Zenject;

namespace Road
{
    public class MovementAfterAd : IInitializable, IDisposable
    {
        private readonly MovementAfterAdConfig _movementAfterAdConfig;
        private readonly ContinuationGameForAd _continuationGameForAd;
        private readonly SpeedCalculation _speedCalculation;
        private readonly CancellationToken _ct;

        private float _addSpeedValue;
        private float _currentModificator;

        public MovementAfterAd(MovementAfterAdConfig movementAfterAdConfig,
                               ContinuationGameForAd continuationGameForAd,
                               SpeedCalculation speedCalculation,
                               RoadView road)
        {
            _movementAfterAdConfig = movementAfterAdConfig;
            _continuationGameForAd = continuationGameForAd;
            _speedCalculation = speedCalculation;

            _ct = road.Road.GetCancellationTokenOnDestroy();
        }

        public void Initialize()
        {
            _addSpeedValue =
                (SpeedCalculation.StandardModificator - _movementAfterAdConfig.StartingSpeedModificator) /
                _movementAfterAdConfig.ReturnToStandardSpeedInSec;

            _continuationGameForAd.Continued += StartMove;
        }

        public void Dispose()
        {
            _continuationGameForAd.Continued -= StartMove;
        }

        private void StartMove()
        {
            _currentModificator = _movementAfterAdConfig.StartingSpeedModificator;
            SetModificator();
            AddSpeed().Forget();
        }

        private void SetModificator()
            => _speedCalculation.SetModificator(_currentModificator);

        private async UniTask AddSpeed()
        {
            while (_currentModificator < SpeedCalculation.StandardModificator)
            {
                _currentModificator += _addSpeedValue * Time.deltaTime;
                SetModificator();
                await UniTask.NextFrame(_ct);
            }

            _currentModificator = SpeedCalculation.StandardModificator;
            SetModificator();
        }
    }
}
