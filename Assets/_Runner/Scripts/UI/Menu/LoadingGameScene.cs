using System;
using UnityEngine.SceneManagement;
using Zenject;

namespace UI
{
    public class LoadingGameScene: IInitializable, IDisposable
    {
        private readonly MenuCanvasView _defeatCanvasView;

        public LoadingGameScene(MenuCanvasView defeatCanvasView)
        {
            _defeatCanvasView = defeatCanvasView;
        }

        public void Initialize()
            => _defeatCanvasView.GameButton.onClick.AddListener(Restart);

        public void Dispose()
            => _defeatCanvasView.GameButton.onClick.RemoveListener(Restart);

        private static void Restart()
            => SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}