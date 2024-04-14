using UnityEngine;

namespace ScriptableObj
{
    [CreateAssetMenu(fileName = "MainHeroStatConfig", menuName = "Configs/MainHeroStatConfig")]
    public class MainHeroStatConfig : ScriptableObject
    {
        [field: SerializeField, Range(1f, 20f)] public float StartSpeedRun { get; private set; }
        [field: SerializeField, Range(1, 50)] public int Health { get; private set; }
        [field: SerializeField] public Gradient GradientHealth { get; private set; }
        [field: SerializeField] public float OffsetToSide { get; private set; }
        [field: SerializeField, Range(1f, 10f)] public float HorizontalSpeed { get; private set; }
    }
}
