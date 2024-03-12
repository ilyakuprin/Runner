using StringValues;
using System;
using UnityEngine;
using Zenject;

namespace MainHero
{
    public class DeathMainHeroAnim : IInitializable, IDisposable, IPlayableAnim
    {
        private readonly Animator _animator;
        private readonly AnimCaching _animCaching;
        private readonly HealthChanging _healthChanging;

        public DeathMainHeroAnim(MainHeroView heroView,
                                 AnimCaching animCaching,
                                 HealthChanging healthChanging)
        {
            _animator = heroView.Anim;
            _animCaching = animCaching;
            _healthChanging = healthChanging;
        }

        public void Initialize()
        {
            _healthChanging.Dead += Play;
        }

        public void Dispose()
        {
            _healthChanging.Dead -= Play;
        }

        public void Play()
        {
            _animator.SetTrigger(_animCaching.Death);
        }
    }
}
