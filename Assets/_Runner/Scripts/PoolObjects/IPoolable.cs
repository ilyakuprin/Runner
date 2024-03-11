using UnityEngine;

namespace PoolObjects
{
    public interface IPoolable
    {
        public int GetIntName { get; }
        public Transform GetTransform { get; }
        public void SetActive(bool value);
    }
}
