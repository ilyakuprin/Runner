using Boosts;
using UnityEngine;
using Zenject;

namespace Installer
{
    public class BoostInstaller : MonoInstaller
    {
        [SerializeField] private StorageBoostView _storageBoostView;

        public override void InstallBindings()
        {
            Container.Bind<StorageBoostView>().FromInstance(_storageBoostView).AsSingle();

            Container.BindInterfacesAndSelfTo<CreatingBoost>().AsSingle();
            Container.BindInterfacesAndSelfTo<StorageBoost>().AsSingle();
            Container.BindInterfacesAndSelfTo<ReturningUntakenBoost>().AsSingle();
        }
    }
}
