using Boosts;
using MainHero;
using StringValues;
using System;
using UnityEngine;
using Zenject;

namespace Collision
{
    public class CollidingWithBoost : IInitializable, IDisposable, ICollidable
    {
        public event Action<string> Collided;

        private readonly CollidingMainHero _collidingMainHero;
        private readonly LayerCaching _layerCaching;
        private readonly CreatingBoost _creatingBoost;

        public CollidingWithBoost(CollidingMainHero collidingMainHero,
                                  LayerCaching layerCaching,
                                  CreatingBoost creatingBoost)
        {
            _collidingMainHero = collidingMainHero;
            _layerCaching = layerCaching;
            _creatingBoost = creatingBoost;
        }

        public void Initialize()
        {
            _collidingMainHero.Triggered += Collide;
        }

        public void Dispose()
        {
            _collidingMainHero.Triggered -= Collide;
        }

        public void Collide(GameObject gameObj)
        {
            if (gameObj.layer != _layerCaching.Boost) return;

            Collided?.Invoke(gameObj.tag);

            _creatingBoost.ReturnObj();
        }
    }
}
