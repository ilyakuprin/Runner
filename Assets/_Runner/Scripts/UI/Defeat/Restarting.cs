using System;
using UnityEngine.SceneManagement;
using Zenject;

namespace UI
{
    public class Restarting : IInitializable, IDisposable
    {
        private readonly DefeatCanvasView _defeatCanvasView;

        public Restarting(DefeatCanvasView defeatCanvasView)
        {
            _defeatCanvasView = defeatCanvasView;
        }

        public void Initialize()
            => _defeatCanvasView.RestartButton.onClick.AddListener(Restart);

        public void Dispose()
            => _defeatCanvasView.RestartButton.onClick.RemoveListener(Restart);

        private static void Restart()
            => SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
