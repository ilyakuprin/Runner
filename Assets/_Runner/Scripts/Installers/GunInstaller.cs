using Gun;
using ScriptableObj;
using UnityEngine;
using Zenject;

namespace Installer
{
    public class GunInstaller : MonoInstaller
    {
        [SerializeField] private GunConfig _gunConfig;
        [SerializeField] private GunView _gunView;

        public override void InstallBindings()
        {
            Container.Bind<GunConfig>().FromInstance(_gunConfig).AsSingle();
            Container.Bind<GunView>().FromInstance(_gunView).AsSingle();

            Container.BindInterfacesAndSelfTo<CallingVfx>().AsSingle();
            Container.BindInterfacesAndSelfTo<CallingAudio>().AsSingle();
        }
    }
}