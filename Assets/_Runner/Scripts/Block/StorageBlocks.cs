using System;
using System.Linq;
using UnityEngine;

namespace Block
{
    public class StorageBlocks : MonoBehaviour
    {
        [SerializeField] private Transform _pool;
        [SerializeField] private BlockView[] _blocksPrefabs;
        private PoolBlock[] _poolBlocks;

        private int GetLength => _blocksPrefabs.Length;

        public IGetableNameBlock GetObj(EnumNameBlock nameBlock)
        {
            for (var i = 0; i < GetLength; i++)
            {
                if (_poolBlocks[i].GetNameBlock == nameBlock)
                {
                    if (_poolBlocks[i].TryGetObjInPool(out var obj))
                    {
                        return obj;
                    }

                    var newObj = Create(i);
                    _poolBlocks[i].AddObjToPool(newObj);
                    return newObj;
                }
            }

            throw new NotImplementedException(nameBlock + " отсутствует в массиве префабов");
        }

        private void Awake()
        {
            _poolBlocks = new PoolBlock[GetLength];

            FillPool();
        }

        private void FillPool()
        {
            for (var k = 0; k < GetLength; k++)
            {
                _poolBlocks[k] = new PoolBlock(_blocksPrefabs[k].GetNameBlock);

                for (var i = 0; i < PoolBlock.StartPool; i++)
                {
                    _poolBlocks[k].AddObjToPool(Create(k));
                }
            }
        }

        private IGetableNameBlock Create(int index)
        {
            var block = Instantiate(_blocksPrefabs[index], Vector3.zero, Quaternion.identity, _pool);
            block.gameObject.SetActive(false);

            return block;
        } 

        private void OnValidate()
        {
            var distinct = _blocksPrefabs.Distinct();

            if (distinct.Count() != GetLength)
                Debug.LogError("есть повтор€ющиес€ элементы");
        }
    }
}
