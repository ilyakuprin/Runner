using Collision;
using StringValues;
using System;
using UnityEngine;
using Zenject;

namespace MainHero
{
    public class CollidingWithFinalBlock : IInitializable, IDisposable, ICollidable
    {
        public event Action Collided;

        private readonly CollidingMainHero _collidingMainHero;
        private readonly LayerCaching _layerCaching;

        public CollidingWithFinalBlock(CollidingMainHero collidingMainHero,
                                       LayerCaching layerCaching)
        {
            _collidingMainHero = collidingMainHero;
            _layerCaching = layerCaching;
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
            if (gameObj.layer == _layerCaching.Final)
            {
                Collided?.Invoke();
            }
        }
    }
}
