using UnityEngine;

namespace Gun
{
    public class GunView : MonoBehaviour
    {
        [field: SerializeField] public AudioSource Source { get; private set; }
        [field: SerializeField] public ParticleSystem Vfx { get; private set; }
    }
}