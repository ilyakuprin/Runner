using System;
using System.Collections.Generic;
using UnityEngine;

namespace PoolObjects
{
    public class Pool<T>
    {
        private readonly List<T> _pool;

        public Pool(int nameEnum,
                    int startPool)
        {
            NameEnum = nameEnum;
            _pool = new List<T>(startPool);
        }

        public int NameEnum { get; }
        private int GetCount => _pool.Count;

        public void AddObjToPool(T obj)
        {
            if (!TryDespawn(obj))
            {
                Expand(obj);
            }
        }

        public bool TryGetObjFromPool(out T obj)
        {
            for (var i = 0; i < GetCount; i++)
            {
                var currentObjInPool = _pool[i];

                if (currentObjInPool != null)
                {
                    obj = currentObjInPool;
                    _pool[i] = default;
                    return true;
                }
            }

            obj = default;
            return false;
        }

        private bool IsNameSame(T obj)
        {
            var poolable = (IPoolable)obj;
            return poolable.GetIntName == NameEnum;
        }

        private bool TryDespawn(T obj)
        {
            for (var i = 0; i < GetCount; i++)
            {
                if (_pool[i] == null)
                {
                    if (IsNameSame(obj))
                    {
                        _pool[i] = obj;
                        return true;
                    }

                    ReturnError();
                }
            }

            return false;
        }

        private void Expand(T obj)
        {
            if (IsNameSame(obj))
            {
                _pool.Add(obj);
            }
            else
            {
                ReturnError();
            }
        }

        private static void ReturnError()
            => throw new NotImplementedException("Объект не соответсвует пулу");
    }
}
