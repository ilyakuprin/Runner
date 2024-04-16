using GameStatus;
using UI;
using UnityEngine;
using Zenject;

namespace Installer
{
    public class MainMenuInstaller : MonoInstaller
    {
        [SerializeField] private MenuCanvasView _menuCanvasView; 
        
        public override void InstallBindings()
        {
            Container.Bind<MenuCanvasView>().FromInstance(_menuCanvasView).AsSingle();

            Container.BindInterfacesAndSelfTo<InteractingWithSaves>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingSaves>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingGameScene>().AsSingle();
            Container.BindInterfacesAndSelfTo<ShowingBestScoring>().AsSingle();
        }
    }
}