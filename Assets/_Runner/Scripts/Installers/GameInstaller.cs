using Block;
using Collision;
using Inputting;
using StringValues;
using MainHero;
using Road;
using ScriptableObj;
using UnityEngine;
using Zenject;
using UI;
using Boosts;

namespace Installer
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private StorageBlocksView _storageBlocksView;
        [SerializeField] private RoadView _roadView;
        [SerializeField] private RoadConfig _roadConfig;
        [SerializeField] private MainHeroView _mainHero;
        [SerializeField] private MainHeroStatConfig _mainHeroStatConfig;
        [SerializeField] private ObstacleDamageConfig _obstacleDamageConfig;
        [SerializeField] private HealthBarView _healthBarView;
        [SerializeField] private BoostConfig _boostConfig;
        [SerializeField] private StorageBoostView _storageBoostView;
        [SerializeField] private HealConfig _healConfig;
        [SerializeField] private SpeedConfig _speedConfig;
        [SerializeField] private InvulnerabilityConfig _invulnerabilityConfig;
        [SerializeField] private DefeatCanvasView _defeatCanvasView;
        [SerializeField] private MovementAfterAdConfig _movementAfterAdConfig;

        public override void InstallBindings()
        {
            Container.Bind<StorageBlocksView>().FromInstance(_storageBlocksView).AsSingle();
            Container.Bind<RoadView>().FromInstance(_roadView).AsSingle();
            Container.Bind<RoadConfig>().FromInstance(_roadConfig).AsSingle();
            Container.Bind<MainHeroView>().FromInstance(_mainHero).AsSingle();
            Container.Bind<MainHeroStatConfig>().FromInstance(_mainHeroStatConfig).AsSingle();
            Container.Bind<ObstacleDamageConfig>().FromInstance(_obstacleDamageConfig).AsSingle();
            Container.Bind<HealthBarView>().FromInstance(_healthBarView).AsSingle();
            Container.Bind<BoostConfig>().FromInstance(_boostConfig).AsSingle();
            Container.Bind<StorageBoostView>().FromInstance(_storageBoostView).AsSingle();
            Container.Bind<HealConfig>().FromInstance(_healConfig).AsSingle();
            Container.Bind<SpeedConfig>().FromInstance(_speedConfig).AsSingle();
            Container.Bind<InvulnerabilityConfig>().FromInstance(_invulnerabilityConfig).AsSingle();
            Container.Bind<DefeatCanvasView>().FromInstance(_defeatCanvasView).AsSingle();
            Container.Bind<MovementAfterAdConfig>().FromInstance(_movementAfterAdConfig).AsSingle();

            Container.BindInterfacesAndSelfTo<LayerCaching>().AsSingle();
            Container.BindInterfacesAndSelfTo<AnimCaching>().AsSingle();
            Container.BindInterfacesAndSelfTo<Tags>().AsSingle();

            Container.BindInterfacesAndSelfTo<StorageBlocks>().AsSingle();
            Container.BindInterfacesAndSelfTo<ChangingParentRoadRotation>().AsSingle();
            Container.BindInterfacesAndSelfTo<GettingRandomBlock>().AsSingle();
            Container.BindInterfacesAndSelfTo<CreatingRoad>().AsSingle();
            Container.BindInterfacesAndSelfTo<BlockState>().AsSingle();
            Container.BindInterfacesAndSelfTo<SpeedCalculation>().AsSingle();
            Container.BindInterfacesAndSelfTo<MovingRoad>().AsSingle();
            Container.BindInterfacesAndSelfTo<RoadRotation>().AsSingle();
            Container.BindInterfacesAndSelfTo<CollidingMainHero>().AsSingle();
            Container.BindInterfacesAndSelfTo<HealthChanging>().AsSingle();
            Container.BindInterfacesAndSelfTo<CollidingWithObstacle>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerInput>().AsSingle();
            Container.BindInterfacesAndSelfTo<JumpingMainHero>().AsSingle();
            Container.BindInterfacesAndSelfTo<JumpingMainHeroAnim>().AsSingle();
            Container.BindInterfacesAndSelfTo<HealthDisplay>().AsSingle();
            Container.BindInterfacesAndSelfTo<CreatingBoost>().AsSingle();
            Container.BindInterfacesAndSelfTo<StorageBoost>().AsSingle();
            Container.BindInterfacesAndSelfTo<CollidingWithBoost>().AsSingle();
            Container.BindInterfacesAndSelfTo<GettingHeal>().AsSingle();
            Container.BindInterfacesAndSelfTo<GettingSpeed>().AsSingle();
            Container.BindInterfacesAndSelfTo<GettingDamageCalculation>().AsSingle();
            Container.BindInterfacesAndSelfTo<GettingInvulnerability>().AsSingle();
            Container.BindInterfacesAndSelfTo<SettingActivePauseDefeat>().AsSingle();
            Container.BindInterfacesAndSelfTo<DeathMainHeroAnim>().AsSingle();
            Container.BindInterfacesAndSelfTo<SettingActiveDefeatCanvas>().AsSingle();
            Container.BindInterfacesAndSelfTo<Restarting>().AsSingle();
            Container.BindInterfacesAndSelfTo<ContinueRunningAnim>().AsSingle();
            Container.BindInterfacesAndSelfTo<ShiftingRoadBack>().AsSingle();
            Container.BindInterfacesAndSelfTo<MovementAfterAd>().AsSingle();
            Container.BindInterfacesAndSelfTo<ContinuationGameForAd>().AsSingle();
        }
    }
}
