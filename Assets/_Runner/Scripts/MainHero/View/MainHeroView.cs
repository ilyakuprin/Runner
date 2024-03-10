using UnityEngine;

namespace MainHero
{
    public class MainHeroView : MonoBehaviour
    {
        [field: SerializeField] public CharacterController HeroController { get; private set; }
        [field: SerializeField] public Animator Anim { get; private set; }
    }
}
