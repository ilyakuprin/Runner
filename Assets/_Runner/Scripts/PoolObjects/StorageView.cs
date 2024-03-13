using System.Linq;
using UnityEngine;

namespace PoolObjects
{
    public abstract class StorageView<T> : MonoBehaviour
    {
        [SerializeField] private T[] _prefabs;

        [field: SerializeField] public Transform Pool { get; private set; }

        public int GetLength => _prefabs.Length;

        public T GetPrefab(int index)
            => _prefabs[index];

        public abstract T Create(int index);

        private void OnValidate()
        {
            var distinct = _prefabs.Distinct();

            if (distinct.Count() != GetLength)
                Debug.LogError("There are repeating elements");
        }
    }
}
