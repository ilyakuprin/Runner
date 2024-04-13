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
        private bool _isPause;

        public MovingRoad(RoadView roadView,
                          SpeedCalculation speedCalculation)
        {
            _roadView = roadView;
            _speedCalculation = speedCalculation;
        }

        public void Initialize()
        {
            _ct = _roadView.GetCancellationTokenOnDestroy();
            StartMove();
        }

        public void StartMove()
        {
            _isPause = false;
            Move().Forget();
        }

        public void StopMove()
        {
            _isPause = true;
        }

        private async UniTask Move()
        {
            while (!_isPause && !_ct.IsCancellationRequested)
            {
                _roadView.Road.position += Time.deltaTime * (Vector3.back * _speedCalculation.GetSpeed());

                Moved?.Invoke();

                await UniTask.NextFrame(_ct);
            }
        }
    }
}
