using System;
using MainHero;
using Road;
using Zenject;

namespace UI
{
    public class ShowingScoringInDefeat: IInitializable, IDisposable
    {
        private const string Format = "Ваш счёт: {0}";
        
        private readonly ObstacleCounting _obstacleCounting;
        private readonly DefeatCanvasView _defeatCanvasView;
        private readonly HealthChanging _healthChanging;

        public ShowingScoringInDefeat(ObstacleCounting obstacleCounting,
                                      DefeatCanvasView defeatCanvasView,
                                      HealthChanging healthChanging)
        {
            _obstacleCounting = obstacleCounting;
            _defeatCanvasView = defeatCanvasView;
            _healthChanging = healthChanging;
        }

        public void Initialize()
            => _healthChanging.Dead += Show;

        public void Dispose()
            => _healthChanging.Dead -= Show;

        private void Show()
            => _defeatCanvasView.Scoring.text = string.Format(Format, _obstacleCounting.Counter);
    }
}