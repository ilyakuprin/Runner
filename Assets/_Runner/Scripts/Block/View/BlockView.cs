using UnityEngine;

namespace Block
{
    public abstract class BlockView : MonoBehaviour, IGetableNameBlock
    {
        [SerializeField] private EnumNameBlock _nameBlock;
        
        public EnumNameBlock GetNameBlock => _nameBlock;
    }
}
