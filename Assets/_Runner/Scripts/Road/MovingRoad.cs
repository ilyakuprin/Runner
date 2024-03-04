using Block;
using Cysharp.Threading.Tasks;
using System.Threading;
using ScriptableObj;
using UnityEngine;
using Zenject;

namespace Road
{
    public class MovingRoad : IInitializable
    {
        private readonly RoadView _roadView;
        private readonly CreatingRoad _creatingRoad;
        private readonly StorageBlocks _storageBlocks;
        private readonly RoadConfig _roadConfig;

        private CancellationToken _ct;
        private float _pointDeletion;
        private int _currentIndexBlock;

        public MovingRoad(RoadView roadView,
                          CreatingRoad creatingRoad,
                          StorageBlocks storageBlocks,
                          RoadConfig roadConfig)
        {
            _roadView = roadView;
            _creatingRoad = creatingRoad;
            _storageBlocks = storageBlocks;
            _roadConfig = roadConfig;
        }

        public void Initialize()
        {
            _pointDeletion = _roadView.Road.position.z;
            _ct = _roadView.GetCancellationTokenOnDestroy();

            Move().Forget();
        }

        private async UniTask Move()
        {
            while (!_ct.IsCancellationRequested)
            {
                _roadView.Road.position += Time.deltaTime * (Vector3.back * _roadConfig.Speed);

                var currentBlock = _creatingRoad.GetBlock(_currentIndexBlock);

                if (currentBlock.GetEnd.position.z < _pointDeletion)
                {
                    _storageBlocks.ReturnObj(currentBlock);

                    var lastIndex = (_roadConfig.NumberVisibleBlocks - 1 + _currentIndexBlock) % _roadConfig.NumberVisibleBlocks;
                    _creatingRoad.CreateBlock(_currentIndexBlock, lastIndex);

                    var nextIndex = (_currentIndexBlock + 1) % _roadConfig.NumberVisibleBlocks;
                    _currentIndexBlock = nextIndex;
                }

                await UniTask.NextFrame(_ct);
            }
        }
    }
}
