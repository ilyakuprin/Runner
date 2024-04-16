using System;
using Road;
using Zenject;

namespace UI
{
    public class ShowingScoringInGame : IInitializable, IDisposable
    {
        private const string Format = "score: {0}";
        
        private readonly ObstacleCounting _obstacleCounting;
        private readonly GameCanvasView _gameCanvasView;

        public ShowingScoringInGame(ObstacleCounting obstacleCounting,
                                 GameCanvasView gameCanvasView)
        {
            _obstacleCounting = obstacleCounting;
            _gameCanvasView = gameCanvasView;
        }

        public void Initialize()
            => _obstacleCounting.Added += Show;

        public void Dispose()
            => _obstacleCounting.Added -= Show;

        private void Show()
            => _gameCanvasView.Scoring.text = string.Format(Format, _obstacleCounting.Counter);
    }
}