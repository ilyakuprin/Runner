using ScriptableObj;
using System;
using UnityEngine;
using Zenject;

namespace PoolObjects
{
    public abstract class Storage<T> : IInitializable where T : IPoolable
    {
        private const string Error = "The object is missing from the prefab array";

        private readonly StorageView<T> _storageView;
        private readonly PoolConfig _poolConfig;
        private Pool<T>[] _pools;

        protected Storage(StorageView<T> storageView,
                          PoolConfig poolConfig)
        {
            _storageView = storageView;
            _poolConfig = poolConfig;
        }

        private int GetLength => _pools.Length;

        public void Initialize()
        {
            _pools = new Pool<T>[_storageView.GetLength];
            FillPool();
        }

        public T GetObj(int nameIntBlock)
        {
            for (var i = 0; i < GetLength; i++)
            {
                if (_pools[i].NameEnum != nameIntBlock) continue;
                
                if (!_pools[i].TryGetObjFromPool(out var obj))
                    obj = _storageView.Create(i);

                var poolable = (IPoolable)obj;
                poolable.SetActive(true);
                return obj;
            }

            throw new NotImplementedException(Error);
        }

        public void ReturnObj(T obj)
        {
            for (var i = 0; i < GetLength; i++)
            {
                var poolable = (IPoolable)obj;

                if (_pools[i].NameEnum == poolable.GetIntName)
                {
                    poolable.GetTransform.parent = _storageView.Pool;
                    _pools[i].AddObjToPool(obj);
                    poolable.SetActive(false);

                    return;
                }
            }

            throw new NotImplementedException(Error);
        }

        private void FillPool()
        {
            for (var k = 0; k < GetLength; k++)
            {
                var poolable = (IPoolable)_storageView.GetPrefab(k);

                _pools[k] = new Pool<T>(poolable.GetIntName, _poolConfig.StartCountInPool);

                for (var i = 0; i < _poolConfig.StartCountInPool; i++)
                {
                    _pools[k].AddObjToPool(_storageView.Create(k));
                }
            }
        }
    }
}
