using UnityEngine;

namespace Block
{
    public interface IViewBlock
    {
        public EnumNameBlock GetNameBlock { get;}
        public abstract Transform GetStart { get; }
        public abstract Transform GetEnd { get; }
    }
}
