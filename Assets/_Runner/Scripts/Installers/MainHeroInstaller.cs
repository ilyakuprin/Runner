using Boost;
using MainHero;
using UnityEngine;
using Zenject;

namespace Installer
{
    public class MainHeroInstaller : MonoInstaller
    {
        [SerializeField] private MainHeroView _mainHero;

        public override void InstallBindings()
        {
            Container.Bind<MainHeroView>().FromInstance(_mainHero).AsSingle();

            Container.BindInterfacesAndSelfTo<SpeedCalculation>().AsSingle();
            Container.BindInterfacesAndSelfTo<RoadRotation>().AsSingle();
            Container.BindInterfacesAndSelfTo<HealthChanging>().AsSingle();
            Container.BindInterfacesAndSelfTo<CollidingWithObstacle>().AsSingle();
            Container.BindInterfacesAndSelfTo<GettingHeal>().AsSingle();
            Container.BindInterfacesAndSelfTo<GettingSpeed>().AsSingle();
            Container.BindInterfacesAndSelfTo<GettingDamageCalculation>().AsSingle();
            Container.BindInterfacesAndSelfTo<GettingInvulnerability>().AsSingle();
            Container.BindInterfacesAndSelfTo<DeathMainHeroAnim>().AsSingle();
            Container.BindInterfacesAndSelfTo<MovingLeftRight>().AsSingle();
            Container.BindInterfacesAndSelfTo<Shooting>().AsSingle();
            Container.BindInterfacesAndSelfTo<GettingBullet>().AsSingle();
        }
    }
}
