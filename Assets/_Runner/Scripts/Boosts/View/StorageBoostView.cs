using PoolObjects;
using UnityEngine;

namespace Boosts
{
    public class StorageBoostView : StorageView<BoostView>
    {
        public override BoostView Create(int index)
        {
            var obj = Instantiate(GetPrefab(index), Vector3.zero, Quaternion.identity, Pool);
            obj.SetActive(false);

            return obj;
        }
    }
}
