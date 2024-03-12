using System;
using UnityEngine;
using Zenject;

namespace Collision
{
    public abstract class GettingBoost : IInitializable, IDisposable
    {
        private readonly CollidingWithBoost _collidingWithBoost;
        private readonly string _tag;

        protected GettingBoost(CollidingWithBoost collidingWithBoost,
                               string tag)
        {
            _collidingWithBoost = collidingWithBoost;
            _tag = tag;
        }

        public void Initialize()
            => _collidingWithBoost.Collided += Collide;

        public void Dispose()
            => _collidingWithBoost.Collided -= Collide;

        protected abstract void Get();

        private void Collide(string tag)
        {
            Debug.Log(tag + " == " + _tag);
            if (tag == _tag)
            {
                Get();
            }
        }
    }
}
