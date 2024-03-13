using Inputting;
using Zenject;

namespace Installer
{
    public class InputingInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerInput>().AsSingle();
        }
    }
}
