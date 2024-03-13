using System;
using StringValues;
using UnityEngine;
using Zenject;

namespace MainHero
{
    public class IdleMainHeroAnim : IInitializable, IDisposable, IPlayableAnim
    {
        private readonly Animator _animator;
        private readonly AnimCaching _animCaching;
        private readonly CollidingWithFinalBlock _collidingWithFinalBlock;

        public IdleMainHeroAnim(MainHeroView heroView,
                                AnimCaching animCaching,
                                CollidingWithFinalBlock collidingWithFinalBlock)
        {
            _animator = heroView.Anim;
            _animCaching = animCaching;
            _collidingWithFinalBlock = collidingWithFinalBlock;
        }

        public void Initialize()
        {
            _collidingWithFinalBlock.Collided += Play;
        }

        public void Dispose()
        {
            _collidingWithFinalBlock.Collided -= Play;
        }

        public void Play()
        {
            _animator.SetTrigger(_animCaching.Idle);
        }
    }
}
