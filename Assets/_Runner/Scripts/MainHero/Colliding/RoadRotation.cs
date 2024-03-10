using Collision;
using Cysharp.Threading.Tasks;
using Caching;
using Road;
using System;
using System.Threading;
using UnityEngine;
using Zenject;

namespace MainHero
{
    public class RoadRotation : IInitializable, IDisposable, ICollidable
    {
        private const float TimeRotate = 0.7f;
        private const float Speed = 1 / TimeRotate;

        private readonly Transform _road;
        private readonly CharacterController _hero;
        private readonly LayerCaching _layerCaching;
        private readonly ChangingParentRoadRotation _changingParentRoadRotation;
        private readonly CollidingMainHero _collidingMainHero;

        private CancellationToken _ct;

        public RoadRotation(RoadView roadView,
                            MainHeroView mainHeroView,
                            LayerCaching layerCaching,
                            ChangingParentRoadRotation changingParentRoadRotation,
                            CollidingMainHero collidingMainHero)
        {
            _road = roadView.Road;
            _hero = mainHeroView.HeroController;
            _layerCaching = layerCaching;
            _changingParentRoadRotation = changingParentRoadRotation;
            _collidingMainHero = collidingMainHero;
        }

        public void Initialize()
        {
            _ct = _hero.GetCancellationTokenOnDestroy();

            _collidingMainHero.Triggered += Collide;
        }

        public void Dispose()
        {
            _collidingMainHero.Triggered -= Collide;
        }

        public void Collide(int layer)
        {
            if (layer == _layerCaching.TrajectoryChangeBlock)
            {
                Rotate().Forget();
            }
        }

        private async UniTaskVoid Rotate()
        {
            var timer = 0f;

            var targetRotation = _changingParentRoadRotation.Rotation;

            while (timer < TimeRotate)
            {
                _road.rotation = Quaternion.Lerp(_road.rotation, targetRotation, Speed * timer);
                timer += Time.deltaTime;
                await UniTask.NextFrame(_ct);
            }

            _road.rotation = targetRotation;
        }
    }
}
