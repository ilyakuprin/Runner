using System;
using MainHero;
using Zenject;

namespace UI
{
    public class ShowingDefeatCanvas : IInitializable, IDisposable
    {
        private readonly DefeatCanvasView _defeatCanvasView;
        private readonly HealthChanging _healthChanging;

        public ShowingDefeatCanvas(DefeatCanvasView defeatCanvasView,
                                   HealthChanging healthChanging)
        {
            _defeatCanvasView = defeatCanvasView;
            _healthChanging = healthChanging;
        }

        public void Initialize()
            => _healthChanging.Dead += Show;

        public void Dispose()
            => _healthChanging.Dead -= Show;

        private void Show()
            => _defeatCanvasView.DefeatObj.SetActive(true);
    }
}
