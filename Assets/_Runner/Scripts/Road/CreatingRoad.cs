using Block;
using ScriptableObj;
using System;
using UnityEngine;
using Zenject;

namespace Road
{
    public class CreatingRoad : IInitializable, IDisposable
    {
        public event Action<BlockView> Created;
        public event Action Returned;

        private readonly RoadView _roadView;
        private readonly StorageBlocks _storage;
        private readonly GettingRandomBlock _gettingRandomBlock;
        private readonly MovingRoad _movingRoad;
        private readonly BlockView[] _blocks;

        private bool _isCanRotate;
        private int _currentIndexBlock;
        private float _pointDeletion;

        public CreatingRoad(RoadView roadView,
                            StorageBlocks storage,
                            RoadConfig roadConfig,
                            GettingRandomBlock gettingRandomBlock,
                            MovingRoad movingRoad)
        {
            _roadView = roadView;
            _storage = storage;
            _gettingRandomBlock = gettingRandomBlock;
            _movingRoad = movingRoad;

            _blocks = new BlockView[roadConfig.NumberVisibleBlocks];
        }

        private int GetLengthArray
            => _blocks.Length;

        public void Initialize()
        {
            _pointDeletion = _roadView.Road.position.z;

            _movingRoad.Moved += ReplaceBlock;

            CreateStartingFirstBlock();
            CreateStartingRemainingBlock();

            _isCanRotate = true;
        }

        public void Dispose()
            => _movingRoad.Moved -= ReplaceBlock;

        public void SetIsCanRotate(bool value)
            => _isCanRotate = value;

        private void ReplaceBlock()
        {
            var currentBlock = _blocks[_currentIndexBlock];

            if (currentBlock.GetEnd.position.z >= _pointDeletion)
                return;

            _storage.ReturnObj(currentBlock);
            Returned?.Invoke();

            var lastIndex = (GetLengthArray - 1 + _currentIndexBlock) % GetLengthArray;
            CreateBlock(_currentIndexBlock, lastIndex);

            _currentIndexBlock = (_currentIndexBlock + 1) % GetLengthArray;
        }

        private void CreateBlock(int currentIndex, int lastIndex)
        {
            var randomBlock = _isCanRotate
                ? _gettingRandomBlock.GetFromAll()
                : _gettingRandomBlock.GetWithoutRotate();

            SetLocation(lastIndex, randomBlock);

            _blocks[currentIndex] = randomBlock;

            Created?.Invoke(randomBlock);
        }

        private void SetLocation(int lastIndex, PoolObjects.IPoolable currentBlock)
        {
            var lastBlock = _blocks[lastIndex];
            SetPosition(currentBlock, lastBlock.GetEnd.position);
            SetParent(currentBlock);
            SetRotation(currentBlock, lastBlock);
        }

        private void CreateStartingFirstBlock()
        {
            var emptyBlock = _storage.GetObj((int)EnumNameBlock.Empty);
            SetPosition(emptyBlock, _roadView.Road.position);
            SetParent(emptyBlock);
            _blocks[0] = emptyBlock;
        }

        private void CreateStartingRemainingBlock()
        {
            for (var i = 1; i < GetLengthArray; i++)
                CreateBlock(i, i - 1);
        }

        private void SetParent(PoolObjects.IPoolable block)
            => block.GetTransform.parent = _roadView.Road;

        private static void SetRotation(PoolObjects.IPoolable block, BlockView lastBlock)
            => block.GetTransform.rotation = lastBlock.GetEnd.rotation;

        private static void SetPosition(PoolObjects.IPoolable block, Vector3 position)
            => block.GetTransform.position = position;
    }
}
