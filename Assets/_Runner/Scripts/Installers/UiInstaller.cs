using UI;
using UnityEngine;
using Zenject;

namespace Installer
{
    public class UiInstaller : MonoInstaller
    {
        [SerializeField] private GameCanvasView _gameCanvasView;
        [SerializeField] private DefeatCanvasView _defeatCanvasView;
        [SerializeField] private ResultCanvasView _resultCanvasView;
        [SerializeField] private WinCanvasView _winCanvasView;

        public override void InstallBindings()
        {
            Container.Bind<GameCanvasView>().FromInstance(_gameCanvasView).AsSingle();
            Container.Bind<DefeatCanvasView>().FromInstance(_defeatCanvasView).AsSingle();
            Container.Bind<ResultCanvasView>().FromInstance(_resultCanvasView).AsSingle();
            Container.Bind<WinCanvasView>().FromInstance(_winCanvasView).AsSingle();

            Container.BindInterfacesAndSelfTo<HealthDisplay>().AsSingle();
            Container.BindInterfacesAndSelfTo<SettingActivePauseResult>().AsSingle();
            Container.BindInterfacesAndSelfTo<SettingActiveDefeatCanvas>().AsSingle();
            Container.BindInterfacesAndSelfTo<Restarting>().AsSingle();
            Container.BindInterfacesAndSelfTo<ContinuationGameForAd>().AsSingle();
            Container.BindInterfacesAndSelfTo<ActiveWinCanvas>().AsSingle();
            Container.BindInterfacesAndSelfTo<VignetteDisplaying>().AsSingle();
        }
    }
}
