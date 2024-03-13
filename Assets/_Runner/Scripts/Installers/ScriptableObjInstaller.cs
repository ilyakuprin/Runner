using ScriptableObj;
using UnityEngine;
using Zenject;

namespace Installer
{
    public class ScriptableObjInstaller : MonoInstaller
    {
        [SerializeField] private RoadConfig _roadConfig;
        [SerializeField] private MainHeroStatConfig _mainHeroStatConfig;
        [SerializeField] private ObstacleDamageConfig _obstacleDamageConfig;
        [SerializeField] private BoostConfig _boostConfig;
        [SerializeField] private HealConfig _healConfig;
        [SerializeField] private SpeedConfig _speedConfig;
        [SerializeField] private InvulnerabilityConfig _invulnerabilityConfig;
        [SerializeField] private MovementAfterAdConfig _movementAfterAdConfig;

        public override void InstallBindings()
        {
            Container.Bind<RoadConfig>().FromInstance(_roadConfig).AsSingle();
            Container.Bind<MainHeroStatConfig>().FromInstance(_mainHeroStatConfig).AsSingle();
            Container.Bind<ObstacleDamageConfig>().FromInstance(_obstacleDamageConfig).AsSingle();
            Container.Bind<BoostConfig>().FromInstance(_boostConfig).AsSingle();
            Container.Bind<HealConfig>().FromInstance(_healConfig).AsSingle();
            Container.Bind<SpeedConfig>().FromInstance(_speedConfig).AsSingle();
            Container.Bind<InvulnerabilityConfig>().FromInstance(_invulnerabilityConfig).AsSingle();
            Container.Bind<MovementAfterAdConfig>().FromInstance(_movementAfterAdConfig).AsSingle();
        }
    }
}
