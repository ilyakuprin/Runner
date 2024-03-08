using Collision;
using Cysharp.Threading.Tasks;
using Layer;
using MainHero;
using System;
using System.Threading;
using UnityEngine;
using Zenject;

namespace Road
{
    public class RoadRotation : IInitializable, IDisposable
    {
        private const float TimeRotate = 0.7f;
        private const float Speed = 1 / TimeRotate;

        private readonly Transform _road;
        private readonly Rigidbody _hero;
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
            _hero = mainHeroView.Hero;
            _layerCaching = layerCaching;
            _changingParentRoadRotation = changingParentRoadRotation;
            _collidingMainHero = collidingMainHero;
        }

        public void Initialize()
        {
            _ct = _hero.GetCancellationTokenOnDestroy();

            _collidingMainHero.Triggered += DetectRotate;
        }

        public void Dispose()
        {
            _collidingMainHero.Triggered -= DetectRotate;
        }

        private void DetectRotate(int layer)
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
