using UnityEngine;

namespace MainHero
{
    public class MainHeroView : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody Hero { get; private set; }
    }
}
