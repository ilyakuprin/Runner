using UnityEngine;

namespace ScriptableObj
{
    [CreateAssetMenu(fileName = "MainHeroStatConfig", menuName = "Configs/MainHeroStatConfig")]
    public class MainHeroStatConfig : ScriptableObject
    {
        [field: SerializeField, Range(1f, 20f)] public float StartSpeedRun { get; private set; }
        [field: SerializeField] public Sprite HeartCompleted { get; private set; }
        [field: SerializeField] public Sprite HeartEmpty { get; private set; }
        [field: SerializeField] public float OffsetToSide { get; private set; }
        [field: SerializeField, Range(1f, 10f)] public float HorizontalSpeed { get; private set; }
        [field: SerializeField] public AnimationCurve GameSpeedCurve { get; private set; }
        [field: SerializeField, Range(1f, 200f)] public float TimeToReachMaxSpeedInSec { get; private set; }
        [field: SerializeField, Range(0f, 1f)] public float MaxSpeedModificator { get; private set; }
    }
}
