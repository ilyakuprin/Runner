using System;
using Caching;
using UnityEngine;
using Zenject;

namespace MainHero
{
    public class JumpingMainHeroAnim : IInitializable, IDisposable
    {
        private readonly Animator _animator;
        private readonly JumpingMainHero _jumpingMainHero;
        private readonly AnimCaching _animCaching;

        public JumpingMainHeroAnim(MainHeroView heroView,
                                   JumpingMainHero jumpingMainHero,
                                   AnimCaching animCaching)
        {
            _animator = heroView.Anim;
            _jumpingMainHero = jumpingMainHero;
            _animCaching = animCaching;
        }

        public void Initialize()
        {
            _jumpingMainHero.Jumped += Play;
        }

        public void Dispose()
        {
            _jumpingMainHero.Jumped -= Play;
        }

        private void Play()
        {
            _animator.SetTrigger(_animCaching.Jump);
        }
    }
}
