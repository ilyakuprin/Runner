using UnityEngine;

namespace Block
{
    public interface IViewBlock
    {
        public Transform GetStart { get; }
        public Transform GetEnd { get; }
    }
}
