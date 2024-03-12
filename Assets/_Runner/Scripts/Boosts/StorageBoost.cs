using PoolObjects;
using ScriptableObj;

namespace Boosts
{
    public class StorageBoost : Storage<BoostView>
    {
        public StorageBoost(StorageBoostView storageBoostView, BoostConfig boostConfig) : base(storageBoostView, boostConfig)
        {

        }
    }
}
