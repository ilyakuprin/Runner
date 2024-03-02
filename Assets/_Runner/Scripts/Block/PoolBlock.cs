using System;
using System.Collections.Generic;

namespace Block
{
    public class PoolBlock
    {
        public const int StartPool = 3;

        private readonly List<IGetableNameBlock> _inactive = new List<IGetableNameBlock>(StartPool);

        public PoolBlock(EnumNameBlock nameBlock)
        {
            GetNameBlock = nameBlock;
        }

        public EnumNameBlock GetNameBlock { get; private set; }
        private int GetCount => _inactive.Count;

        public void AddObjToPool(IGetableNameBlock obj)
        {
            if (!TryDespawn(obj))
            {
                Expand(obj);
            }
        }

        private bool TryDespawn(IGetableNameBlock obj)
        {
            for (var i = 0; i < GetCount; i++)
            {
                if (_inactive[i] == null)
                {
                    if (obj.GetNameBlock == GetNameBlock)
                    {
                        _inactive[i] = obj;
                        return true;
                    }

                    ReturnError(obj);
                }
            }

            return false;
        }

        public bool TryGetObjInPool(out IGetableNameBlock obj)
        {
            for (var i = 0; i < GetCount; i++)
            {
                var currentObjInPool = _inactive[i];

                if (currentObjInPool != null)
                {
                    obj = currentObjInPool;
                    return true;
                }
            }

            obj = null;
            return false;
        }

        private void Expand(IGetableNameBlock obj)
        {
            if (obj.GetNameBlock == GetNameBlock)
            {
                _inactive.Add(obj);
            }
            else
            {
                ReturnError(obj);
            }
        }

        private void ReturnError(IGetableNameBlock obj)
            => throw new NotImplementedException("ѕытаешьс€ внести " + obj.GetNameBlock + " в пулл " + GetNameBlock);
    }
}
