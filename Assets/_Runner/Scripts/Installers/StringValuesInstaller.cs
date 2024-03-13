using StringValues;
using Zenject;

namespace Installer
{
    public class StringValuesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LayerCaching>().AsSingle();
            Container.BindInterfacesAndSelfTo<AnimCaching>().AsSingle();
            Container.BindInterfacesAndSelfTo<Tags>().AsSingle();
        }
    }
}
