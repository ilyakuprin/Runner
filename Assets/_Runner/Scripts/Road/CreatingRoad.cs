using Block;
using System;
using ScriptableObj;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Road
{
    public class CreatingRoad : IInitializable
    {
        private readonly RoadView _roadView;
        private readonly StorageBlocks _storageBlocks;
        private readonly RoadConfig _roadConfig;
        private readonly IViewBlock[] _blocks;

        private Array _blocksNames;

        public CreatingRoad(RoadView roadView,
                            StorageBlocks storageBlocks,
                            RoadConfig roadConfig)
        {
            _roadView = roadView;
            _storageBlocks = storageBlocks;
            _roadConfig = roadConfig;

            _blocks = new IViewBlock[_roadConfig.NumberVisibleBlocks];
        }

        private IViewBlock GetRandomBlock => _storageBlocks.GetObj(GetRandomIndexEnum);
        private EnumNameBlock GetRandomIndexEnum => (EnumNameBlock)Random.Range(0, _blocksNames.Length);

        public void Initialize()
        {
            _blocksNames = Enum.GetValues(typeof(EnumNameBlock));

            CreateStartingFirstBlock();
            CreateStartingRemainingBlock();
        }

        public IViewBlock GetBlock(int index)
        {
            if (index >= 0 && index < _roadConfig.NumberVisibleBlocks)
            {
                return _blocks[index];
            }

            throw new IndexOutOfRangeException("index за пределами массива");
        }

        public void CreateBlock(int currentIndex, int lastIndex)
        {
            var randomBlock = GetRandomBlock;
            SetStartingLocation(randomBlock, lastIndex);
            _blocks[currentIndex] = randomBlock;
        }

        private void CreateStartingFirstBlock()
        {
            var emptyBlock = _storageBlocks.GetObj(EnumNameBlock.Empty);
            SetStartPosition(emptyBlock, _roadView.Road.position);
            SetParent(emptyBlock);
            _blocks[0] = emptyBlock;
        }

        private void CreateStartingRemainingBlock()
        {
            for (var i = 1; i < _roadConfig.NumberVisibleBlocks; i++)
            {
                CreateBlock(i, i - 1);
            }
        }

        private void SetStartingLocation(IViewBlock currentBlock, int lastBlockIndex)
        {
            SetStartPosition(currentBlock, _blocks[lastBlockIndex].GetEnd.position);
            SetParent(currentBlock);
        }

        private void SetParent(IViewBlock block)
            => block.GetStart.parent = _roadView.Road;

        private void SetStartPosition(IViewBlock block, Vector3 position)
            => block.GetStart.position = position;
    }
}
