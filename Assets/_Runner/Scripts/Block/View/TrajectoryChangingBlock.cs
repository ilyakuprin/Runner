using UnityEngine;

namespace Block
{
    public class TrajectoryChangingBlock : BlockView
    {
        private const int CountEnds = 2;

        [SerializeField] private Transform _start;
        [SerializeField] private Transform _left;
        [SerializeField] private Transform _right;

        public override Transform GetStart => _start;
        public override Transform GetEnd => Random.Range(0, CountEnds) == 0 ? _left : _right;
    }
}
