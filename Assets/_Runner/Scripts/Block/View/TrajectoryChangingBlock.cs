using UnityEngine;

namespace Block
{
    public class TrajectoryChangingBlock : BlockView, IGetableStartEndBlock
    {
        private const int CountEnds = 2;

        [SerializeField] private Transform _start;
        [SerializeField] private Transform _left;
        [SerializeField] private Transform _right;

        public Transform GetStart() => _start;
        public Transform GetEnd() => Random.Range(0, CountEnds) == 0 ? _left : _right;
    }
}
