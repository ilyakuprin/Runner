using GameStatus;
using Zenject;

namespace Installer
{
    public class GameStatusInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InteractingWithSaves>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingSaves>().AsSingle();
            Container.BindInterfacesAndSelfTo<SavingScoring>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<SettingPause>().AsSingle();
        }
    }
}