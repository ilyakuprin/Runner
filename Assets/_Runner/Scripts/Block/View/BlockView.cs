using UnityEngine;

namespace Block
{
    public class BlockView : MonoBehaviour, IViewBlock
    {
        [SerializeField] private EnumNameBlock _nameBlock;
        [SerializeField] private Transform _start;
        [SerializeField] private Transform _end;
        
        public EnumNameBlock GetNameBlock => _nameBlock;
        public Transform GetStart => _start;
        public Transform GetEnd => _end;
    }
}
