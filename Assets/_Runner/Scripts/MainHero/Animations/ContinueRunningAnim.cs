using StringValues;
using System;
using UI;
using UnityEngine;
using Zenject;

namespace MainHero
{
    public class ContinueRunningAnim : IInitializable, IDisposable, IPlayableAnim
    {
        private readonly Animator _animator;
        private readonly AnimCaching _animCaching;
        private readonly ContinuationGameForAd _continuationGameForAd;

        public ContinueRunningAnim(MainHeroView heroView,
                                   AnimCaching animCaching,
                                   ContinuationGameForAd continuationGameForAd)
        {
            _animator = heroView.Anim;
            _animCaching = animCaching;
            _continuationGameForAd = continuationGameForAd;
        }

        public void Initialize()
        {
            _continuationGameForAd.Continued += Play;
        }

        public void Dispose()
        {
            _continuationGameForAd.Continued -= Play;
        }

        public void Play()
        {
            _animator.SetTrigger(_animCaching.Run);
        }
    }
}
