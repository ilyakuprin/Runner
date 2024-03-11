using Cysharp.Threading.Tasks;
using ScriptableObj;
using System;
using System.Threading;
using UnityEngine;
using Zenject;

namespace Road
{
    public class MovingRoad : IInitializable
    {
        public event Action Moved;

        private readonly RoadView _roadView;
        private readonly float _speed;

        private CancellationToken _ct;

        public MovingRoad(RoadView roadView,
                          MainHeroStatConfig heroStatConfig)
        {
            _roadView = roadView;
            _speed = heroStatConfig.Speed;
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
                _roadView.Road.position += Time.deltaTime * (Vector3.back * _speed);

                Moved?.Invoke();

                await UniTask.NextFrame(_ct);
            }
        }
    }
}
