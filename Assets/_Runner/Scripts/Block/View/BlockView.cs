using PoolObjects;
using UnityEngine;

namespace Block
{
    public class BlockView : PoolingObjectView
    {
        [SerializeField] private EnumNameBlock _nameBlock;
        [SerializeField] private Transform _end;

        public Transform GetEnd => _end;
        public EnumNameBlock GetNameBlock => _nameBlock;
        public override int GetIntName => (int)_nameBlock;
    }
}
