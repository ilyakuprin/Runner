using UnityEngine;

namespace Block
{
    public abstract class BlockView : MonoBehaviour, IViewBlock
    {
        [SerializeField] private EnumNameBlock _nameBlock;
        
        public EnumNameBlock GetNameBlock => _nameBlock;

        public abstract Transform GetStart { get; }
        public abstract Transform GetEnd { get; }
    }
}
