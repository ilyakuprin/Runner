using System;
using UnityEngine.SceneManagement;
using Zenject;

namespace UI
{
    public class Restarting : IInitializable, IDisposable
    {
        private readonly DefeatCanvasView _defeatCanvasView;
        private readonly WinCanvasView _winCanvasView;

        public Restarting(DefeatCanvasView defeatCanvasView,
                          WinCanvasView winCanvasView)
        {
            _defeatCanvasView = defeatCanvasView;
            _winCanvasView = winCanvasView;
        }

        public void Initialize()
        {
            _defeatCanvasView.RestartButton.onClick.AddListener(Restart);
            _winCanvasView.NextLvlButton.onClick.AddListener(Restart);
        }

        public void Dispose()
        {
            _defeatCanvasView.RestartButton.onClick.RemoveListener(Restart);
            _winCanvasView.NextLvlButton.onClick.RemoveListener(Restart);
        }

        private static void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
