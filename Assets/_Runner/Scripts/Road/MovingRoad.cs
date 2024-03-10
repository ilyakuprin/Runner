using Cysharp.Threading.Tasks;
using System.Threading;
using ScriptableObj;
using UnityEngine;
using Zenject;
using Block;

namespace Road
{
    public class MovingRoad : IInitializable
    {
        private readonly RoadView _roadView;
        private readonly CreatingRoad _creatingRoad;
        private readonly StorageBlocks _storageBlocks;
        private readonly RoadConfig _roadConfig;
        private readonly float _speed;

        private CancellationToken _ct;
        private float _pointDeletion;
        private int _currentIndexBlock;
        private int _counterBlocks;

        public MovingRoad(RoadView roadView,
                          CreatingRoad creatingRoad,
                          StorageBlocks storageBlocks,
                          RoadConfig roadConfig,
                          MainHeroStatConfig heroStatConfig)
        {
            _roadView = roadView;
            _creatingRoad = creatingRoad;
            _storageBlocks = storageBlocks;
            _roadConfig = roadConfig;
            _speed = heroStatConfig.Speed;
        }

        public void Initialize()
        {
            _pointDeletion = _roadView.Road.position.z;
            _ct = _roadView.GetCancellationTokenOnDestroy();

            _counterBlocks = _roadConfig.NumberVisibleBlocks;

            Move().Forget();
        }

        private async UniTask Move()
        {
            while (!_ct.IsCancellationRequested)
            {
                _roadView.Road.position += Time.deltaTime * (Vector3.back * _speed);

                var currentBlock = _creatingRoad.GetBlock(_currentIndexBlock);

                if (currentBlock.GetEnd.position.z < _pointDeletion && _counterBlocks < _roadConfig.NumberAllBlocks)
                {
                    DeleteBlock(currentBlock);
                    CreateBlock();
                    SetNextIndex();
                }

                await UniTask.NextFrame(_ct);
            }
        }

        private void DeleteBlock(IViewBlock block)
            => _storageBlocks.ReturnObj(block);

        private void CreateBlock()
        {
            var lastIndex = (_roadConfig.NumberVisibleBlocks - 1 + _currentIndexBlock) % _roadConfig.NumberVisibleBlocks;
            _creatingRoad.CreateBlock(_currentIndexBlock, lastIndex);

            _counterBlocks++;
        }

        private void SetNextIndex()
            => _currentIndexBlock = (_currentIndexBlock + 1) % _roadConfig.NumberVisibleBlocks;
    }
}
