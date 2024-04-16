using System;
using GameStatus;
using Zenject;

namespace UI
{
    public class ShowingNewRecordMessage : IInitializable, IDisposable
    {
        private readonly DefeatCanvasView _defeatCanvasView;
        private readonly SavingScoring _savingScoring;

        public ShowingNewRecordMessage(DefeatCanvasView defeatCanvasView,
                                       SavingScoring savingScoring)
        {
            _defeatCanvasView = defeatCanvasView;
            _savingScoring = savingScoring;
        }

        public void Initialize()
            => _savingScoring.ScoringUpdated += Show;

        public void Dispose()
            => _savingScoring.ScoringUpdated -= Show;

        private void Show()
            => _defeatCanvasView.NewRecordMessage.gameObject.SetActive(true);
    }
}