using System.Linq;
using UnityEngine;

namespace Block
{
    public class StorageBlocksView : MonoBehaviour
    {
        [field: SerializeField] public Transform Pool { get; private set; }

        [SerializeField] private BlockView[] _blocksPrefabs;

        public int GetLength => _blocksPrefabs.Length;

        public BlockView GetBlock(int index)
            => _blocksPrefabs[index];

        public IViewBlock Create(int index)
        {
            var block = Instantiate(_blocksPrefabs[index], Vector3.zero, Quaternion.identity, Pool);
            block.gameObject.SetActive(false);

            return block;
        }

        private void OnValidate()
        {
            var distinct = _blocksPrefabs.Distinct();

            if (distinct.Count() != GetLength)
                Debug.LogError("есть повтор€ющиес€ элементы");
        }
    }
}
