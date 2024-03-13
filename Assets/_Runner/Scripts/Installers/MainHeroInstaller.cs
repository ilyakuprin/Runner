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
            Container.BindInterfacesAndSelfTo<JumpingMainHero>().AsSingle();
            Container.BindInterfacesAndSelfTo<JumpingMainHeroAnim>().AsSingle();
            Container.BindInterfacesAndSelfTo<GettingHeal>().AsSingle();
            Container.BindInterfacesAndSelfTo<GettingSpeed>().AsSingle();
            Container.BindInterfacesAndSelfTo<GettingDamageCalculation>().AsSingle();
            Container.BindInterfacesAndSelfTo<GettingInvulnerability>().AsSingle();
            Container.BindInterfacesAndSelfTo<DeathMainHeroAnim>().AsSingle();
            Container.BindInterfacesAndSelfTo<ContinueRunningAnim>().AsSingle();
            Container.BindInterfacesAndSelfTo<CollidingWithFinalBlock>().AsSingle();
            Container.BindInterfacesAndSelfTo<IdleMainHeroAnim>().AsSingle();
        }
    }
}
