using Collision;
using Caching;
using System;
using ScriptableObj;
using Zenject;

namespace MainHero
{
    public class CollidingWithObstacle : IInitializable, IDisposable, ICollidable
    {
        private readonly CollidingMainHero _collidingMainHero;
        private readonly HealthChanging _healthChanging;
        private readonly LayerCaching _layerCaching;
        private readonly int _damage;

        private int _layerObstacle;

        public CollidingWithObstacle(CollidingMainHero collidingMainHero,
                                     HealthChanging healthChanging,
                                     LayerCaching layerCaching,
                                     ObstacleDamageConfig config)
        {
            _collidingMainHero = collidingMainHero;
            _healthChanging = healthChanging;
            _layerCaching = layerCaching;
            _damage = config.Damage;
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

        public void Collide(int layer)
        {
            if (layer == _layerObstacle)
            {
                _healthChanging.TakeDamage(_damage);
            }
        }
    }
}
