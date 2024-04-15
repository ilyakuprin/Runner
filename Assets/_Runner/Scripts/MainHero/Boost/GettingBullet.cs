using System;
using Collision;
using Gun;
using MainHero;
using ScriptableObj;
using StringValues;
using Zenject;

namespace Boost
{
    public class GettingBullet : IInitializable, IDisposable, ITakebleBoost
    {
        private readonly CollidingWithBoost _collidingWithBoost;
        private readonly BulletConfig _bulletConfig;
        private readonly ChangingNumberAmmo _changingNumberAmmo;
        
        private string _tag;

        public GettingBullet(CollidingWithBoost collidingWithBoost,
                             BulletConfig bulletConfig,
                             ChangingNumberAmmo changingNumberAmmo)
        {
            _collidingWithBoost = collidingWithBoost;
            _bulletConfig = bulletConfig;
            _changingNumberAmmo = changingNumberAmmo;
        }
        
        public void Initialize()
        {
            _tag = Tags.Bullet;
            _collidingWithBoost.Collided += Take;
        }

        public void Dispose()
            => _collidingWithBoost.Collided -= Take;

        public void Take(string tag)
        {
            if (tag == _tag)
            {
                _changingNumberAmmo.Add(_bulletConfig.NumberBullet);
            }
        }
    }
}