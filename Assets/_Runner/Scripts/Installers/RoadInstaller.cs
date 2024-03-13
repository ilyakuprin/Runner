using Road;
using UnityEngine;
using Zenject;

namespace Installer
{
    public class RoadInstaller : MonoInstaller
    {
        [SerializeField] private RoadView _roadView;

        public override void InstallBindings()
        {
            Container.Bind<RoadView>().FromInstance(_roadView).AsSingle();

            Container.BindInterfacesAndSelfTo<ChangingParentRoadRotation>().AsSingle();
            Container.BindInterfacesAndSelfTo<CreatingRoad>().AsSingle();
            Container.BindInterfacesAndSelfTo<MovingRoad>().AsSingle();
            Container.BindInterfacesAndSelfTo<ShiftingRoadBack>().AsSingle();
            Container.BindInterfacesAndSelfTo<MovementAfterAd>().AsSingle();
            Container.BindInterfacesAndSelfTo<ObstacleCounting>().AsSingle();
        }
    }
}
