using StringValues;
using System;
using UnityEngine;
using Zenject;

namespace MainHero
{
    public class DeathMainHeroAnim : IInitializable, IDisposable, IPlayableAnim
    {
        private readonly Animator _animator;
        private readonly HealthChanging _healthChanging;
        private int _death;

        public DeathMainHeroAnim(MainHeroView heroView,
                                 HealthChanging healthChanging)
        {
            _animator = heroView.Anim;
            _healthChanging = healthChanging;
        }

        public void Initialize()
        {
            _death = AnimCaching.Death;
            _healthChanging.Dead += Play;
        }

        public void Dispose()
        {
            _healthChanging.Dead -= Play;
        }

        public void Play()
        {
            _animator.SetTrigger(_death);
        }
    }
}
