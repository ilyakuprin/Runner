using PoolObjects;
using ScriptableObj;

namespace Block
{
    public class StorageBlocks : Storage<BlockView>
    {
        public StorageBlocks(StorageBlocksView storageBlocksView, RoadConfig roadConfig) : base(storageBlocksView, roadConfig)
        {

        }
    }
}
