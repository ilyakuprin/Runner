using Cysharp.Threading.Tasks;
using MainHero;
using System;
using System.Threading;
using UnityEngine;
using Zenject;

namespace Road
{
    public class MovingRoad : IInitializable
    {
        public event Action Moved;

        private readonly SpeedCalculation _speedCalculation;
        private readonly RoadView _roadView;

        private CancellationToken _ct;

        public MovingRoad(RoadView roadView,
                          SpeedCalculation speedCalculation)
        {
            _roadView = roadView;
            _speedCalculation = speedCalculation;
        }

        public void Initialize()
        {
            _ct = _roadView.GetCancellationTokenOnDestroy();

            Move().Forget();
        }

        private async UniTask Move()
        {
            while (!_ct.IsCancellationRequested)
            {
                _roadView.Road.position += Time.deltaTime * (Vector3.back * _speedCalculation.GetSpeed());

                Moved?.Invoke();

                await UniTask.NextFrame(_ct);
            }
        }
    }
}
