using UI;
using UnityEngine;
using Zenject;

namespace Installer
{
    public class UiInstaller : MonoInstaller
    {
        [SerializeField] private HealthBarView _healthBarView;
        [SerializeField] private DefeatCanvasView _defeatCanvasView;
        [SerializeField] private ObstacleCountingView _obstacleCountingView;
        [SerializeField] private ResultCanvasView _resultCanvasView;
        [SerializeField] private WinCanvasView _winCanvasView;

        public override void InstallBindings()
        {
            Container.Bind<HealthBarView>().FromInstance(_healthBarView).AsSingle();
            Container.Bind<DefeatCanvasView>().FromInstance(_defeatCanvasView).AsSingle();
            Container.Bind<ObstacleCountingView>().FromInstance(_obstacleCountingView).AsSingle();
            Container.Bind<ResultCanvasView>().FromInstance(_resultCanvasView).AsSingle();
            Container.Bind<WinCanvasView>().FromInstance(_winCanvasView).AsSingle();

            Container.BindInterfacesAndSelfTo<HealthDisplay>().AsSingle();
            Container.BindInterfacesAndSelfTo<SettingActivePauseResult>().AsSingle();
            Container.BindInterfacesAndSelfTo<SettingActiveDefeatCanvas>().AsSingle();
            Container.BindInterfacesAndSelfTo<Restarting>().AsSingle();
            Container.BindInterfacesAndSelfTo<ContinuationGameForAd>().AsSingle();
            Container.BindInterfacesAndSelfTo<ActiveWinCanvas>().AsSingle();
        }
    }
}
