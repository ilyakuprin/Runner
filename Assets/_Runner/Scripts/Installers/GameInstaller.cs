using Block;
using Collision;
using Layer;
using MainHero;
using Road;
using ScriptableObj;
using UnityEngine;
using Zenject;

namespace Installer
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private StorageBlocksView _storageBlocksView;
        [SerializeField] private RoadView _roadView;
        [SerializeField] private RoadConfig _roadConfig;
        [SerializeField] private MainHeroView _mainHero;

        public override void InstallBindings()
        {
            Container.Bind<StorageBlocksView>().FromInstance(_storageBlocksView).AsSingle();
            Container.Bind<RoadView>().FromInstance(_roadView).AsSingle();
            Container.Bind<RoadConfig>().FromInstance(_roadConfig).AsSingle();
            Container.Bind<MainHeroView>().FromInstance(_mainHero).AsSingle();

            Container.BindInterfacesAndSelfTo<LayerCaching>().AsSingle();
            Container.BindInterfacesAndSelfTo<StorageBlocks>().AsSingle();
            Container.BindInterfacesAndSelfTo<ChangingParentRoadRotation>().AsSingle();
            Container.BindInterfacesAndSelfTo<CreatingRoad>().AsSingle();
            Container.BindInterfacesAndSelfTo<MovingRoad>().AsSingle();
            Container.BindInterfacesAndSelfTo<RoadRotation>().AsSingle();
            Container.BindInterfacesAndSelfTo<CollidingMainHero>().AsSingle();
        }
    }
}
