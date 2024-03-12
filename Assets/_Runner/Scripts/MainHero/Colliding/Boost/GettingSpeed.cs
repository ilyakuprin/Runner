using System.Threading;
using Collision;
using Cysharp.Threading.Tasks;
using ScriptableObj;
using StringValues;

namespace MainHero
{
    public class GettingSpeed : GettingBoost
    {
        private readonly SpeedConfig _speedConfig;
        private readonly SpeedCalculation _speedCalculation;
        private readonly CancellationTokenSource _cts;

        public GettingSpeed(SpeedConfig speedConfig,
                            Tags tags,
                            SpeedCalculation speedCalculation,
                            CollidingWithBoost collidingWithBoost) :
            base(collidingWithBoost, tags.Speed)
        {
            _speedConfig = speedConfig;
            _speedCalculation = speedCalculation;

            _cts = new CancellationTokenSource();
        }

        protected override void Get()
        {
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
