using System;
using ScriptableObj;
using Zenject;

namespace Block
{
    public class StorageBlocks : IInitializable
    {
        private readonly StorageBlocksView _blocks;
        private readonly RoadConfig _roadConfig;
        private PoolBlock[] _poolBlocks;

        public StorageBlocks(StorageBlocksView storageBlocksView,
                             RoadConfig roadConfig)
        {
            _blocks = storageBlocksView;
            _roadConfig = roadConfig;
        }

        private int GetLength => _poolBlocks.Length;

        public void Initialize()
        {
            _poolBlocks = new PoolBlock[_blocks.GetLength];
            FillPool();
        }

        public IViewBlock GetObj(EnumNameBlock nameBlock)
        {
            for (var i = 0; i < GetLength; i++)
            {
                if (_poolBlocks[i].GetNameBlock == nameBlock)
                {
                    if (!_poolBlocks[i].TryGetObjInPool(out var obj))
                    {
                        obj = _blocks.Create(i);
                        _poolBlocks[i].AddObjToPool(obj);
                    }

                    SetActiveObj(obj, true);
                    return obj;
                }
            }

            throw new NotImplementedException(nameBlock + " отсутствует в массиве префабов");
        }

        public void ReturnObj(IViewBlock obj)
        {
            for (var i = 0; i < GetLength; i++)
            {
                if (_poolBlocks[i].GetNameBlock == obj.GetNameBlock)
                {
                    obj.GetStart.parent = _blocks.Pool;
                    _poolBlocks[i].AddObjToPool(obj);
                    SetActiveObj(obj, false);
                    return;
                }
            }

            throw new NotImplementedException(obj.GetNameBlock + " отсутствует в массиве префабов");
        }

        private void FillPool()
        {
            for (var k = 0; k < GetLength; k++)
            {
                _poolBlocks[k] = new PoolBlock(_blocks.GetBlock(k).GetNameBlock, _roadConfig.NumberVisibleBlocks);

                for (var i = 0; i < _roadConfig.NumberVisibleBlocks; i++)
                {
                    _poolBlocks[k].AddObjToPool(_blocks.Create(k));
                }
            }
        }

        public void SetActiveObj(IViewBlock obj, bool value)
            => obj.GetStart.gameObject.SetActive(value);
    }
}
