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
        private readonly ChangingParentRoadRotation _changingParentRoadRotation;
        private readonly IViewBlock[] _blocks;

        private int _lengthAllNames;
        private EnumNameBlock[] _blocksWithoutRotate;
        private bool _isCanRotate;

        public CreatingRoad(RoadView roadView,
                            StorageBlocks storageBlocks,
                            RoadConfig roadConfig,
                            ChangingParentRoadRotation changingParentRoadRotation)
        {
            _roadView = roadView;
            _storageBlocks = storageBlocks;
            _roadConfig = roadConfig;
            _changingParentRoadRotation = changingParentRoadRotation;

            _blocks = new IViewBlock[_roadConfig.NumberVisibleBlocks];
        }

        private EnumNameBlock GetRandomIndexEnumAllBlock => (EnumNameBlock)Random.Range(0, _lengthAllNames);
        private EnumNameBlock GetRandomIndexEnumWithoutRotate => _blocksWithoutRotate[Random.Range(0, _blocksWithoutRotate.Length)];

        public void Initialize()
        {
            _lengthAllNames = Enum.GetValues(typeof(EnumNameBlock)).Length;
            FillArrayWithoutRotateBlocks();

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
            var randomBlock = GetRandomBlock();
            var lastBlock = _blocks[lastIndex];

            SetPosition(randomBlock, lastBlock.GetEnd.position);
            SetParent(randomBlock);
            SetRotation(randomBlock, lastBlock);

            _blocks[currentIndex] = randomBlock;
        }

        private IViewBlock GetRandomBlock()
        {
            if (_isCanRotate)
            {
                var block = GetRandomIndexEnumAllBlock;
                if(IsRotateBlock(block))
                    _isCanRotate = false;

                return _storageBlocks.GetObj(block);
            }

            return _storageBlocks.GetObj(GetRandomIndexEnumWithoutRotate);
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
            {
                CreateBlock(i, i - 1);
            }

            _isCanRotate = true;
        }

        private void SetParent(IViewBlock block)
            => block.GetStart.parent = _roadView.Road;

        private void SetPosition(IViewBlock block, Vector3 position)
            => block.GetStart.position = position;

        private void SetRotation(IViewBlock block, IViewBlock lastBlock)
        {
            block.GetStart.rotation = lastBlock.GetEnd.rotation;

            if (IsRotateBlock(lastBlock.GetNameBlock))
            {
                _changingParentRoadRotation.Change(lastBlock);
            }
        }

        private void FillArrayWithoutRotateBlocks()
        {
            var length = 0;

            for (var i = 0; i < _lengthAllNames; i++)
            {
                if (!IsRotateBlock((EnumNameBlock)i))
                {
                    length++;
                }
            }

            _blocksWithoutRotate = new EnumNameBlock[length];

            for (var i = 0; i < _blocksWithoutRotate.Length; i++)
            {
                var nameBlock = (EnumNameBlock)i;

                if (!IsRotateBlock(nameBlock))
                {
                    _blocksWithoutRotate[i] = nameBlock;
                }
            }
        }

        private bool IsRotateBlock(EnumNameBlock nameBlock)
            => nameBlock == EnumNameBlock.Left ||
               nameBlock == EnumNameBlock.Right;
    }
}
