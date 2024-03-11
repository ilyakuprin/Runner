using UnityEngine;

namespace PoolObjects
{
    public abstract class PoolingObjectView : MonoBehaviour, IPoolable
    {
        [SerializeField] private Transform _object;

        public Transform GetTransform => _object;

        public abstract int GetIntName { get; }

        public void SetActive(bool value)
            => _object.gameObject.SetActive(value);
    }
}

