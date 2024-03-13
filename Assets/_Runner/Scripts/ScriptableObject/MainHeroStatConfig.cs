using UnityEngine;

namespace ScriptableObj
{
    [CreateAssetMenu(fileName = "MainHeroStatConfig", menuName = "Configs/MainHeroStatConfig")]
    public class MainHeroStatConfig : ScriptableObject
    {
        [field: SerializeField, Range(1f, 20f)] public float Speed { get; private set; }
        [field: SerializeField, Range(1, 50)] public int Health { get; private set; }
        [field: SerializeField, Range(0.1f, 5f)] public float JumpHeight { get; private set; }

        [field: Tooltip("Jump Arc Length Reduction Multiplier"),
                SerializeField, Range(0.1f, 5f)] public float GravityScale { get; private set; }
        [field: SerializeField] public Gradient GradientHealth { get; private set; }
    }
}
