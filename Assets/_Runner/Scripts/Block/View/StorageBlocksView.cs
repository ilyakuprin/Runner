using PoolObjects;
using UnityEngine;

namespace Block
{
    public class StorageBlocksView : StorageView<BlockView>
    {
        public override BlockView Create(int index)
        {
            var obj = Instantiate(GetPrefab(index), Vector3.zero, Quaternion.identity, Pool);
            obj.SetActive(false);

            return obj;
        }
    }
}
