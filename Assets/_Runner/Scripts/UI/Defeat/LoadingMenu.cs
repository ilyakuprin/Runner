using UnityEngine.SceneManagement;
using Zenject;

namespace UI
{
    public class LoadingMenu : IInitializable
    {
        private readonly DefeatCanvasView _defeatCanvasView;

        public LoadingMenu(DefeatCanvasView defeatCanvasView)
        {
            _defeatCanvasView = defeatCanvasView;
        }

        public void Initialize()
            => _defeatCanvasView.MenuButton.onClick.AddListener(Restart);

        public void Dispose()
            => _defeatCanvasView.MenuButton.onClick.RemoveListener(Restart);

        private static void Restart()
            => SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
    }
}