using Collision;
using ScriptableObj;
using StringValues;
using System;
using Zenject;

namespace MainHero
{
    public class GettingHeal : IInitializable, IDisposable, ITakebleBoost
    {
        private readonly HealConfig _healConfig;
        private readonly HealthChanging _healthChanging;
        private readonly CollidingWithBoost _collidingWithBoost;
        
        private string _tag;

        public GettingHeal(HealConfig healConfig,
                           HealthChanging healthChanging,
                           CollidingWithBoost collidingWithBoost)
        {
            _healConfig = healConfig;
            _healthChanging = healthChanging;
            _collidingWithBoost = collidingWithBoost;
            
        }

        public void Initialize()
        {
            _tag = Tags.Heal;
            _collidingWithBoost.Collided += Take;
        } 

        public void Dispose()
            => _collidingWithBoost.Collided -= Take;

        public void Take(string tag)
        {
            if (tag == _tag)
            {
                _healthChanging.TakeHeal(_healConfig.Heal);
            }
        }
    }
}
