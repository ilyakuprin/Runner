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

        public IViewBlock GetObj(EnumNameBlock nameBlock)
        {
            for (var i = 0; i < GetLength; i++)
            {
                if (_poolBlocks[i].GetNameBlock == nameBlock)
                {
                    if (!_poolBlocks[i].TryGetObjInPool(out var obj))
                    {
                        obj = Create(i);
                        _poolBlocks[i].AddObjToPool(obj);
                    }

                    SetActiveObj(obj, true);
                    return obj;
                }
            }

            throw new NotImplementedException(nameBlock + " ����������� � ������� ��������");
        }

        public void ReturnObj(IViewBlock obj)
        {
            for (var i = 0; i < GetLength; i++)
            {
                if (_poolBlocks[i].GetNameBlock == obj.GetNameBlock)
                {
                    _poolBlocks[i].AddObjToPool(obj);
                    SetActiveObj(obj, false);
                    return;
                }
            }

            throw new NotImplementedException(obj.GetNameBlock + " ����������� � ������� ��������");
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

        private IViewBlock Create(int index)
        {
            var block = Instantiate(_blocksPrefabs[index], Vector3.zero, Quaternion.identity, _pool);
            block.gameObject.SetActive(false);

            return block;
        }

        public void SetActiveObj(IViewBlock obj, bool value)
            => obj.GetStart.gameObject.SetActive(value);

        private void OnValidate()
        {
            var distinct = _blocksPrefabs.Distinct();

            if (distinct.Count() != GetLength)
                Debug.LogError("���� ������������� ��������");
        }
    }
}
