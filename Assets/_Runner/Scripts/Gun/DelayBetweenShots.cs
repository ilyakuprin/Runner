using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using MainHero;
using ScriptableObj;
using Zenject;

namespace Gun
{
    public class DelayBetweenShots : IInitializable, IDisposable, IIsShotable
    {
        private readonly Shooting _shooting;
        private readonly GunConfig _gunConfig;
        
        private CancellationTokenSource _cts;
        private bool _isCanShot = true;

        public DelayBetweenShots(Shooting shooting,
                                 GunConfig gunConfig)
        {
            _shooting = shooting;
            _gunConfig = gunConfig;
        }

        public void Initialize()
        {
            _cts = new CancellationTokenSource();
            
            _shooting.Shot += StartWaitDelay;
            _shooting.AddIsCanShot(this);
        }

        public void Dispose()
            => _shooting.Shot -= StartWaitDelay;

        public bool IsCanShot()
            => _isCanShot;

        private void StartWaitDelay()
            => WaitDelay().Forget();

        private async UniTask WaitDelay()
        {
            _isCanShot = false;
            await UniTask.WaitForSeconds(_gunConfig.ShotDelay,
                                         false,
                                         PlayerLoopTiming.Update,
                                         _cts.Token);
            _isCanShot = true;
        }
    }
}