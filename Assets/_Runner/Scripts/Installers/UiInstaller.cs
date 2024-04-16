using UI;
using UnityEngine;
using Zenject;

namespace Installer
{
    public class UiInstaller : MonoInstaller
    {
        [SerializeField] private GameCanvasView _gameCanvasView;
        [SerializeField] private DefeatCanvasView _defeatCanvasView;

        public override void InstallBindings()
        {
            Container.Bind<GameCanvasView>().FromInstance(_gameCanvasView).AsSingle();
            Container.Bind<DefeatCanvasView>().FromInstance(_defeatCanvasView).AsSingle();

            Container.BindInterfacesAndSelfTo<HealthDisplaying>().AsSingle();
            Container.BindInterfacesAndSelfTo<ShowingDefeatCanvas>().AsSingle();
            Container.BindInterfacesAndSelfTo<Restarting>().AsSingle();
            Container.BindInterfacesAndSelfTo<VignetteDisplaying>().AsSingle();
            Container.BindInterfacesAndSelfTo<AmmoDisplaying>().AsSingle();
            Container.BindInterfacesAndSelfTo<ShowingScoringInGame>().AsSingle();
            Container.BindInterfacesAndSelfTo<ShowingScoringInDefeat>().AsSingle();
            Container.BindInterfacesAndSelfTo<ShowingNewRecordMessage>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingMenu>().AsSingle();
        }
    }
}
