using ScriptableObj;
using System;
using Zenject;

namespace PoolObjects
{
    public class Storage<T> : IInitializable
    {
        private const string Error = "объект отсутствует в массиве префабов";

        private readonly StorageView<T> _storageView;
        private readonly PoolConfig _poolConfig;
        private Pool<T>[] _pools;

        public Storage(StorageView<T> storageView,
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
                if (_pools[i].NameEnum == nameIntBlock)
                {
                    if (!_pools[i].TryGetObjFromPool(out var obj))
                    {
                        obj = _storageView.Create(i);
                        _pools[i].AddObjToPool(obj);
                    }

                    var poolable = (PoolObjects.IPoolable)obj;
                    poolable.SetActive(true);
                    return obj;
                }
            }

            throw new NotImplementedException(Error);
        }

        public void ReturnObj(T obj)
        {
            for (var i = 0; i < GetLength; i++)
            {
                var poolable = (PoolObjects.IPoolable)obj;

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
                var poolable = (PoolObjects.IPoolable)_storageView.GetPrefab(k);

                _pools[k] = new Pool<T>(poolable.GetIntName, _poolConfig.StartCountInPool);

                for (var i = 0; i < _poolConfig.StartCountInPool; i++)
                {
                    _pools[k].AddObjToPool(_storageView.Create(k));
                }
            }
        }
    }
}
