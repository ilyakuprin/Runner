using UnityEngine;
using Zenject;

namespace Caching
{
    public class AnimCaching : IInitializable
    {
        private const string NameJump = "Jump";

        public int Jump { get; private set; }

        public void Initialize()
        {
            Jump = Animator.StringToHash(NameJump);
        }
    }
}
