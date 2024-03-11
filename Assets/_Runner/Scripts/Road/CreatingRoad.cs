using Block;
using ScriptableObj;
using System;
using UnityEngine;
using Zenject;

namespace Road
{
    public class CreatingRoad : IInitializable, IDisposable
    {
        public event Action<IViewBlock> Created;

        private readonly RoadView _roadView;
        private readonly StorageBlocks _storageBlocks;
        private readonly RoadConfig _roadConfig;
        private readonly GettingRandomBlock _gettingRandomBlock;
        private readonly MovingRoad _movingRoad;
        private readonly IViewBlock[] _blocks;

        private bool _isCanRotate;
        private int _currentIndexBlock;
        private float _pointDeletion;

        public CreatingRoad(RoadView roadView,
                            StorageBlocks storageBlocks,
                            RoadConfig roadConfig,
                            GettingRandomBlock gettingRandomBlock,
                            MovingRoad movingRoad)
        {
            _roadView = roadView;
            _storageBlocks = storageBlocks;
            _roadConfig = roadConfig;
            _gettingRandomBlock = gettingRandomBlock;
            _movingRoad = movingRoad;

            _blocks = new IViewBlock[_roadConfig.NumberVisibleBlocks];
        }

        public void Initialize()
        {
            _pointDeletion = _roadView.Road.position.z;

            _movingRoad.Moved += ReplaceBlock;

            CreateStartingFirstBlock();
            CreateStartingRemainingBlock();

            _isCanRotate = true;
        }

        public void Dispose()
        {
            _movingRoad.Moved -= ReplaceBlock;
        }

        public void SetIsCanRotate(bool value)
            => _isCanRotate = value;

        private void ReplaceBlock()
        {
            var currentBlock = _blocks[_currentIndexBlock];

            if (currentBlock.GetEnd.position.z >= _pointDeletion)
                return;

            _storageBlocks.ReturnObj(currentBlock);

            var lastIndex = (_roadConfig.NumberVisibleBlocks - 1 + _currentIndexBlock) % _roadConfig.NumberVisibleBlocks;
            CreateBlock(_currentIndexBlock, lastIndex);

            _currentIndexBlock = (_currentIndexBlock + 1) % _roadConfig.NumberVisibleBlocks;
        }

        private void CreateBlock(int currentIndex, int lastIndex)
        {
            var randomBlock = _isCanRotate
                ? _gettingRandomBlock.GetFromAll()
                : _gettingRandomBlock.GetWithoutRotate();

            var lastBlock = _blocks[lastIndex];
            SetPosition(randomBlock, lastBlock.GetEnd.position);
            SetParent(randomBlock);
            SetRotation(randomBlock, lastBlock);

            _blocks[currentIndex] = randomBlock;

            Created?.Invoke(randomBlock);
        }

        private void CreateStartingFirstBlock()
        {
            var emptyBlock = _storageBlocks.GetObj(EnumNameBlock.Empty);
            SetPosition(emptyBlock, _roadView.Road.position);
            SetParent(emptyBlock);
            _blocks[0] = emptyBlock;
        }

        private void CreateStartingRemainingBlock()
        {
            for (var i = 1; i < _roadConfig.NumberVisibleBlocks; i++)
                CreateBlock(i, i - 1);
        }

        private void SetParent(IViewBlock block)
            => block.GetStart.parent = _roadView.Road;

        private static void SetRotation(IViewBlock block, IViewBlock lastBlock)
            => block.GetStart.rotation = lastBlock.GetEnd.rotation;

        private static void SetPosition(IViewBlock block, Vector3 position)
            => block.GetStart.position = position;
    }
}
