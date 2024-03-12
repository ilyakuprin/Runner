using System;
using Zenject;

namespace UI
{
    public class ContinuationGameForAd : IInitializable, IDisposable
    {
        public event Action Continued;

        private readonly DefeatCanvasView _defeatCanvasView;

        public ContinuationGameForAd(DefeatCanvasView defeatCanvasView)
        {
            _defeatCanvasView = defeatCanvasView;
        }

        public void Initialize()
        {
            _defeatCanvasView.AdButton.onClick.AddListener(Continue);
        }

        public void Dispose()
        {
            _defeatCanvasView.AdButton.onClick.RemoveListener(Continue);
        }

        private void Continue()
        {
            Continued?.Invoke();
        }
    }
}
