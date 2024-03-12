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
        private readonly LayerCaching _layerCaching;
        private readonly GettingDamageCalculation _gettingDamageCalculation;

        private int _layerObstacle;

        public CollidingWithObstacle(CollidingMainHero collidingMainHero,
                                     HealthChanging healthChanging,
                                     LayerCaching layerCaching,
                                     GettingDamageCalculation gettingDamageCalculation)
        {
            _collidingMainHero = collidingMainHero;
            _healthChanging = healthChanging;
            _layerCaching = layerCaching;
            _gettingDamageCalculation = gettingDamageCalculation;
        }

        public void Initialize()
        {
            _layerObstacle = _layerCaching.Obstacle;

            _collidingMainHero.Triggered += Collide;
        }

        public void Dispose()
        {
            _collidingMainHero.Triggered -= Collide;
        }

        public void Collide(GameObject gameObj)
        {
            if (gameObj.layer == _layerObstacle)
            {
                _healthChanging.TakeDamage(_gettingDamageCalculation.GetDamage());
            }
        }
    }
}
