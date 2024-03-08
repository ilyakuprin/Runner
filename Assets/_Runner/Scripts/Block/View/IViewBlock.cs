using UnityEngine;

namespace Block
{
    public interface IViewBlock
    {
        public EnumNameBlock GetNameBlock { get; }
        public Transform GetStart { get; }
        public Transform GetEnd { get; }
    }
}
