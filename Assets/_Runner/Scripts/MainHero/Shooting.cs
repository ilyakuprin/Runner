using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Gun;
using Inputting;
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
        private const int CountIIsShotable = 2;

        private readonly PlayerInput _playerInput;
        private readonly CharacterController _hero;
        private readonly List<IIsShotable> _isShotables = new List<IIsShotable>(CountIIsShotable);
        
        private CancellationToken _ct;
        private int _obstacleMask;

        public Shooting(PlayerInput playerInput,
            MainHeroView mainHeroView)
        {
            _playerInput = playerInput;
            _hero = mainHeroView.HeroController;
        }

        public void Execute(InputData inputData)
        {
            if (!inputData.Fire || !IsCanShot()) return;

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

        public void AddIsCanShot(IIsShotable iIsShotable)
            => _isShotables.Add(iIsShotable);

        private bool IsCanShot()
            => _isShotables.Count == 0 || _isShotables.All(isCanShot => isCanShot.IsCanShot());

        private async UniTask Shoot()
        {
            await UniTask.WaitForFixedUpdate(_ct);

            if (!_ct.IsCancellationRequested && TryHit(out var hit))
                hit.transform.gameObject.SetActive(false);
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