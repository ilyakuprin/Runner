using Collision;
using Zenject;

public class CollisionInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<CollidingMainHero>().AsSingle();
        Container.BindInterfacesAndSelfTo<CollidingWithBoost>().AsSingle();
    }
}
