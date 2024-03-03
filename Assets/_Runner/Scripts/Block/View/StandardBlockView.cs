using UnityEngine;

namespace Block
{
    public class StandardBlockView : BlockView
    {
        [SerializeField] private Transform _start;
        [SerializeField] private Transform _end;

        public override Transform GetStart => _start;
        public override Transform GetEnd => _end;
    }
}
