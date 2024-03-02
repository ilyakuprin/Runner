using UnityEngine;

namespace Block
{
    public class StandardBlockView : BlockView, IGetableStartEndBlock
    {
        [SerializeField] private Transform _start;
        [SerializeField] private Transform _end;

        public Transform GetStart() => _start;
        public Transform GetEnd() => _end;
    }
}
