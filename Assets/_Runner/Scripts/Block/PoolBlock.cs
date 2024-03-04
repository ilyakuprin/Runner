using System;
using System.Collections.Generic;

namespace Block
{
    public class PoolBlock
    {
        private readonly List<IViewBlock> _pool;

        public PoolBlock(EnumNameBlock nameBlock, int startPool)
        {
            GetNameBlock = nameBlock;
            _pool = new List<IViewBlock>(startPool);
        }

        public EnumNameBlock GetNameBlock { get; }
        private int GetCount => _pool.Count;

        public void AddObjToPool(IViewBlock obj)
        {
            if (!TryDespawn(obj))
            {
                Expand(obj);
            }
        }

        private bool TryDespawn(IViewBlock obj)
        {
            for (var i = 0; i < GetCount; i++)
            {
                if (_pool[i] == null)
                {
                    if (obj.GetNameBlock == GetNameBlock)
                    {
                        _pool[i] = obj;
                        return true;
                    }

                    ReturnError(obj);
                }
            }

            return false;
        }

        public bool TryGetObjInPool(out IViewBlock obj)
        {
            for (var i = 0; i < GetCount; i++)
            {
                var currentObjInPool = _pool[i];

                if (currentObjInPool != null)
                {
                    obj = currentObjInPool;
                    _pool[i] = null;
                    return true;
                }
            }

            obj = null;
            return false;
        }

        private void Expand(IViewBlock obj)
        {
            if (obj.GetNameBlock == GetNameBlock)
            {
                _pool.Add(obj);
            }
            else
            {
                ReturnError(obj);
            }
        }

        private void ReturnError(IViewBlock obj)
            => throw new NotImplementedException("ѕытаешьс€ внести " + obj.GetNameBlock + " в пулл " + GetNameBlock);
    }
}
