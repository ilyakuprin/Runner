using System;
using MainHero;
using Zenject;

namespace UI
{
    public class SettingActiveDefeatCanvas : IInitializable, IDisposable
    {
        private readonly DefeatCanvasView _defeatCanvasView;
        private readonly HealthChanging _healthChanging;
        private readonly ContinuationGameForAd _continuationGameForAd;

        public SettingActiveDefeatCanvas(DefeatCanvasView defeatCanvasView,
                                         HealthChanging healthChanging,
                                         ContinuationGameForAd continuationGameForAd)
        {
            _defeatCanvasView = defeatCanvasView;
            _healthChanging = healthChanging;
            _continuationGameForAd = continuationGameForAd;
        }

        public void Initialize()
        {
            _healthChanging.Dead += Activate;
            _continuationGameForAd.Continued += Deactivate;
        }

        public void Dispose()
        {
            _healthChanging.Dead -= Activate;
            _continuationGameForAd.Continued -= Deactivate;
        }

        private void Activate()
            => SetActive(true);

        private void Deactivate()
            => SetActive(false);

        private void SetActive(bool value)
            => _defeatCanvasView.DefeatCanvas.gameObject.SetActive(value);
    }
}
