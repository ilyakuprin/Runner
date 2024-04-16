using System;
using System.Threading;
using Collision;
using Cysharp.Threading.Tasks;
using ScriptableObj;
using StringValues;
using Zenject;

namespace MainHero
{
    public class GettingSpeed : IInitializable, IDisposable, ITakebleBoost
    {
        private readonly SpeedConfig _speedConfig;
        private readonly SpeedCalculation _speedCalculation;
        private readonly CollidingWithBoost _collidingWithBoost;
        
        private string _tag;

        private CancellationTokenSource _cts = new CancellationTokenSource();

        public GettingSpeed(SpeedConfig speedConfig,
                            SpeedCalculation speedCalculation,
                            CollidingWithBoost collidingWithBoost)
        {
            _speedConfig = speedConfig;
            _speedCalculation = speedCalculation;
            _collidingWithBoost = collidingWithBoost;
        }

        public void Initialize()
        {
            _tag = Tags.Speed;
            _collidingWithBoost.Collided += Take;
        }

        public void Dispose()
        {
            _collidingWithBoost.Collided -= Take;

            _cts.Cancel();
            _cts.Dispose();
        }

        public void Take(string tag)
        {
            if (tag == _tag)
            {
                Get();
            }
        }

        private void Get()
        {
            _cts.Cancel();
            _cts = new CancellationTokenSource();

            _speedCalculation.SetExternalModificator(_speedConfig.Modificator);
            TimerResetSpeed().Forget();
        }

        private async UniTask TimerResetSpeed()
        {
            await UniTask.WaitForSeconds(_speedConfig.TimeActionInSec, cancellationToken: _cts.Token);
            _speedCalculation.ResetModificator();
        }
    }
}
