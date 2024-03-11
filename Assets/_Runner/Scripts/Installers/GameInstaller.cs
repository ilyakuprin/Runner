using Block;
using Collision;
using Inputting;
using Caching;
using MainHero;
using Road;
using ScriptableObj;
using UnityEngine;
using Zenject;
using UI;

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

        public override void InstallBindings()
        {
            Container.Bind<StorageBlocksView>().FromInstance(_storageBlocksView).AsSingle();
            Container.Bind<RoadView>().FromInstance(_roadView).AsSingle();
            Container.Bind<RoadConfig>().FromInstance(_roadConfig).AsSingle();
            Container.Bind<MainHeroView>().FromInstance(_mainHero).AsSingle();
            Container.Bind<MainHeroStatConfig>().FromInstance(_mainHeroStatConfig).AsSingle();
            Container.Bind<ObstacleDamageConfig>().FromInstance(_obstacleDamageConfig).AsSingle();
            Container.Bind<HealthBarView>().FromInstance(_healthBarView).AsSingle();

            Container.BindInterfacesAndSelfTo<LayerCaching>().AsSingle();
            Container.BindInterfacesAndSelfTo<AnimCaching>().AsSingle();

            Container.BindInterfacesAndSelfTo<StorageBlocks>().AsSingle();
            Container.BindInterfacesAndSelfTo<ChangingParentRoadRotation>().AsSingle();
            Container.BindInterfacesAndSelfTo<GettingRandomBlock>().AsSingle();
            Container.BindInterfacesAndSelfTo<CreatingRoad>().AsSingle();
            Container.BindInterfacesAndSelfTo<BlockState>().AsSingle();
            Container.BindInterfacesAndSelfTo<MovingRoad>().AsSingle();
            Container.BindInterfacesAndSelfTo<RoadRotation>().AsSingle();
            Container.BindInterfacesAndSelfTo<CollidingMainHero>().AsSingle();
            Container.BindInterfacesAndSelfTo<HealthChanging>().AsSingle();
            Container.BindInterfacesAndSelfTo<CollidingWithObstacle>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerInput>().AsSingle();
            Container.BindInterfacesAndSelfTo<JumpingMainHero>().AsSingle();
            Container.BindInterfacesAndSelfTo<JumpingMainHeroAnim>().AsSingle();
            Container.BindInterfacesAndSelfTo<HealthDisplay>().AsSingle();
        }
    }
}
