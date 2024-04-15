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
        private int _boost;

        public CollidingWithBoost(CollidingMainHero collidingMainHero)
        {
            _collidingMainHero = collidingMainHero;
        }

        public void Initialize()
        {
            _boost = LayerCaching.Boost;
            _collidingMainHero.Triggered += Collide;
        }

        public void Dispose()
        {
            _collidingMainHero.Triggered -= Collide;
        }

        public void Collide(GameObject gameObj)
        {
            if (gameObj.layer != _boost) return;

            Collided?.Invoke(gameObj.tag);

            gameObj.SetActive(false);
        }
    }
}
