using System;
using System.Threading;
using Collision;
using Cysharp.Threading.Tasks;
using ScriptableObj;
using StringValues;
using Zenject;

namespace MainHero
{
    public class GettingSpeed : IInitializable, IDisposable, ITakebleBoost, IResetableBoost
    {
        private readonly SpeedConfig _speedConfig;
        private readonly SpeedCalculation _speedCalculation;
        private readonly CollidingWithBoost _collidingWithBoost;
        private readonly string _tag;

        private CancellationTokenSource _cts = new CancellationTokenSource();

        public GettingSpeed(SpeedConfig speedConfig,
                            Tags tags,
                            SpeedCalculation speedCalculation,
                            CollidingWithBoost collidingWithBoost)
        {
            _speedConfig = speedConfig;
            _speedCalculation = speedCalculation;
            _collidingWithBoost = collidingWithBoost;
            _tag = tags.Speed;
        }

        public void Initialize()
            => _collidingWithBoost.Collided += Take;

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

        public void ResetBoost()
        {
            _cts.Cancel();
            _speedCalculation.ResetModificator();
        }

        private void Get()
        {
            _cts.Cancel();
            _cts = new CancellationTokenSource();

            _speedCalculation.SetModificator(_speedConfig.Modificator);
            TimerResetSpeed().Forget();
        }

        private async UniTask TimerResetSpeed()
        {
            await UniTask.WaitForSeconds(_speedConfig.TimeActionInSec, cancellationToken: _cts.Token);
            _speedCalculation.ResetModificator();
        }
    }
}
