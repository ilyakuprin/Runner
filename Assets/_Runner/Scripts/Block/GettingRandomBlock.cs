using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Block
{
    public class GettingRandomBlock : IInitializable
    {
        private readonly StorageBlocks _storage;

        private int _lengthAllNames;
        private EnumNameBlock[] _blocksWithoutRotate;

        public GettingRandomBlock(StorageBlocks storage)
        {
            _storage = storage;
        }

        private int GetRandomIndexEnumAllBlock
            => Random.Range(0, _lengthAllNames);
        private int GetRandomIndexEnumWithoutRotate
            => (int)_blocksWithoutRotate[Random.Range(0, _blocksWithoutRotate.Length)];

        public void Initialize()
        {
            _lengthAllNames = Enum.GetValues(typeof(EnumNameBlock)).Length;
            FillArrayWithoutRotateBlocks();
        }

        public BlockView GetFromAll()
            => _storage.GetObj(GetRandomIndexEnumAllBlock);

        public BlockView GetWithoutRotate()
            => _storage.GetObj(GetRandomIndexEnumWithoutRotate);

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

        private static bool IsRotateBlock(EnumNameBlock nameBlock)
            => nameBlock == EnumNameBlock.Left ||
               nameBlock == EnumNameBlock.Right;
    }
}
