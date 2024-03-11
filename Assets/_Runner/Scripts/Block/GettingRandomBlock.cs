using System;
using Zenject;
using Random = UnityEngine.Random;

namespace Block
{
    public class GettingRandomBlock : IInitializable
    {
        private readonly StorageBlocks _storageBlocks;

        private int _lengthAllNames;
        private EnumNameBlock[] _blocksWithoutRotate;

        public GettingRandomBlock(StorageBlocks storageBlocks)
        {
            _storageBlocks = storageBlocks;
        }

        private EnumNameBlock GetRandomIndexEnumAllBlock
            => (EnumNameBlock)Random.Range(0, _lengthAllNames);
        private EnumNameBlock GetRandomIndexEnumWithoutRotate
            => _blocksWithoutRotate[Random.Range(0, _blocksWithoutRotate.Length)];

        public void Initialize()
        {
            _lengthAllNames = Enum.GetValues(typeof(EnumNameBlock)).Length;
            FillArrayWithoutRotateBlocks();
        }

        public IViewBlock GetFromAll()
            => _storageBlocks.GetObj(GetRandomIndexEnumAllBlock);

        public IViewBlock GetWithoutRotate()
            => _storageBlocks.GetObj(GetRandomIndexEnumWithoutRotate);

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
