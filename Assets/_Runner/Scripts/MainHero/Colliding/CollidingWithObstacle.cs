using Collision;
using StringValues;
using System;
using UnityEngine;
using Zenject;

namespace MainHero
{
    public class CollidingWithObstacle : IInitializable, IDisposable, ICollidable
    {
        private readonly CollidingMainHero _collidingMainHero;
        private readonly HealthChanging _healthChanging;
        private readonly GettingDamageCalculation _gettingDamageCalculation;

        private int _obstacle;

        public CollidingWithObstacle(CollidingMainHero collidingMainHero,
                                     HealthChanging healthChanging,
                                     GettingDamageCalculation gettingDamageCalculation)
        {
            _collidingMainHero = collidingMainHero;
            _healthChanging = healthChanging;
            _gettingDamageCalculation = gettingDamageCalculation;
        }

        public void Initialize()
        {
            _obstacle = LayerCaching.Obstacle;
            _collidingMainHero.Triggered += Collide;
        }

        public void Dispose()
        {
            _collidingMainHero.Triggered -= Collide;
        }

        public void Collide(GameObject gameObj)
        {
            if (gameObj.layer == _obstacle)
            {
                _healthChanging.TakeDamage(_gettingDamageCalculation.GetDamage());
            }
        }
    }
}
