using UnityEngine;
using Zenject;

namespace StringValues
{
    public class AnimCaching : IInitializable
    {
        private const string NameJump = "Jump";
        private const string NameDeath = "Death";
        private const string NameRun = "Run";
        private const string NameIdle = "Idle";

        public int Jump { get; private set; }
        public int Death { get; private set; }
        public int Run { get; private set; }
        public int Idle { get; private set; }

        public void Initialize()
        {
            Jump = Animator.StringToHash(NameJump);
            Death = Animator.StringToHash(NameDeath);
            Run = Animator.StringToHash(NameRun);
            Idle = Animator.StringToHash(NameIdle);
        }
    }
}
