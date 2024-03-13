using Block;
using UnityEngine;
using Zenject;

namespace Installer
{
    public class BlockInstaller : MonoInstaller
    {
        [SerializeField] private StorageBlocksView _storageBlocksView;

        public override void InstallBindings()
        {
            Container.Bind<StorageBlocksView>().FromInstance(_storageBlocksView).AsSingle();

            Container.BindInterfacesAndSelfTo<StorageBlocks>().AsSingle();
            Container.BindInterfacesAndSelfTo<GettingRandomBlock>().AsSingle();
            Container.BindInterfacesAndSelfTo<BlockState>().AsSingle();
        }
    }
}
