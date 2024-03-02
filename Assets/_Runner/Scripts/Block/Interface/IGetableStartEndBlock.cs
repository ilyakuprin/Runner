using UnityEngine;

namespace Block
{
    public interface IGetableStartEndBlock
    {
        public Transform GetStart();
        public Transform GetEnd();
    }
}
