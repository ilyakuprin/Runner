using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;
using MainHero;
using System;
using System.Threading;
using UnityEngine;
using Zenject;

namespace Collision
{
    public class CollidingMainHero : IInitializable
    {
        public event Action<GameObject> Triggered;

        private readonly CharacterController _hero;
        private AsyncTriggerEnterTrigger _trigger;
        private CancellationToken _ct;

        public CollidingMainHero(MainHeroView mainHeroView)
        {
            _hero = mainHeroView.HeroController;
        }

        public void Initialize()
        {
            _trigger = _hero.GetAsyncTriggerEnterTrigger();
            _ct = _hero.GetCancellationTokenOnDestroy();

            DetectCollision().Forget();
        }

        private async UniTaskVoid DetectCollision()
        {
            while (!_ct.IsCancellationRequested)
            {
                var uniTask = _trigger.OnTriggerEnterAsync(_ct);
                await uniTask;
                Triggered?.Invoke(uniTask.GetAwaiter().GetResult().gameObject);
            }
        }
    }
}
