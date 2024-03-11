using UnityEngine;

namespace ScriptableObj
{
    public class PoolConfig : ScriptableObject
    {
        [field: SerializeField, Range(1, 7)] public int StartCountInPool { get; private set; }
    }
}
