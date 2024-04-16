using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using ScriptableObj;
using UnityEngine;
using Zenject;

namespace MainHero
{
    public class SpeedCalculation : IInitializable, IDisposable
    {
        private const float StandardModificator = 1f;

        private readonly MainHeroStatConfig _mainHeroStatConfig;
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();
        
        private float _externalModificator = StandardModificator;
        private float _internalModificator = 1f;

        public SpeedCalculation(MainHeroStatConfig heroStatConfig)
        {
            _mainHeroStatConfig = heroStatConfig;
        }

        public void Initialize()
        {
            IncreaseInternalModificator().Forget();
        }

        public void Dispose()
        {
            _cts.Cancel();
            _cts.Dispose();
        }

        public float GetSpeed()
            => _mainHeroStatConfig.StartSpeedRun * _externalModificator * _internalModificator;

        public void SetExternalModificator(float value)
        {
            if (value < 0)
                value = 0;

            _externalModificator = value;
        }

        public void ResetModificator()
            => _externalModificator = StandardModificator;

        private async UniTask IncreaseInternalModificator()
        {
            var time = 0f;

            while (time < _mainHeroStatConfig.TimeToReachMaxSpeedInSec)
            {
                time += Time.deltaTime;
                var progress = time / _mainHeroStatConfig.TimeToReachMaxSpeedInSec;

                _internalModificator = StandardModificator + _mainHeroStatConfig.GameSpeedCurve.Evaluate(progress) *
                                                             _mainHeroStatConfig.MaxSpeedModificator;
  
                await UniTask.NextFrame(_cts.Token);
            }

            _internalModificator = StandardModificator + _mainHeroStatConfig.MaxSpeedModificator;
        }
    }
}
