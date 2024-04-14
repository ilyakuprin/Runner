using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Inputting;
using ScriptableObj;
using StringValues;
using UnityEngine;
using Zenject;

namespace MainHero
{
    public class Shooting : IInitializable, IDisposable, IExecutive
    {
        public event Action Shot;
        
        private const float Half = 0.5f;
        private const float MaxDistance = 20f;
        
        private readonly PlayerInput _playerInput;
        private readonly CharacterController _hero;
        private readonly GunConfig _gunConfig;

        private CancellationToken _ct;
        private int _obstacleMask;
        private bool _isCanShot = true;

        public Shooting(PlayerInput playerInput,
                        MainHeroView mainHeroView,
                        GunConfig gunConfig)
        {
            _playerInput = playerInput;
            _hero = mainHeroView.HeroController;
            _gunConfig = gunConfig;
        }

        public void Execute(InputData inputData)
        {
            if (!inputData.Fire || !_isCanShot) return;
            
            Reload().Forget();
            Shoot().Forget();
            Shot?.Invoke();
        }

        public void Initialize()
        {
            _ct = _hero.GetCancellationTokenOnDestroy();
            _obstacleMask = LayerCaching.ObstacleMask;
            
            _playerInput.Inputted += Execute;
        }

        public void Dispose()
        {
            _playerInput.Inputted -= Execute;
        }

        private async UniTask Shoot()
        {
            await UniTask.WaitForFixedUpdate(_ct);
            
            if (!_ct.IsCancellationRequested && TryHit(out var hit))
                hit.transform.gameObject.SetActive(false);
        }

        private async UniTask Reload()
        {
            _isCanShot = false;
            await UniTask.WaitForSeconds(_gunConfig.ShotDelay, false, PlayerLoopTiming.Update, _ct);
            _isCanShot = true;
        }

        private bool TryHit(out RaycastHit hit)
        {
            var heroHeight = _hero.height;
            var heroTransform = _hero.transform;
            
            var point1 = heroTransform.position + (_hero.center - Vector3.up * heroHeight * Half);
            var point2 = point1 + Vector3.up * heroHeight;

            return Physics.CapsuleCast(point1,
                                       point2,
                                       _hero.radius,
                                       heroTransform.forward,
                                       out hit,
                                       MaxDistance,
                                       _obstacleMask);
        }
    }
}