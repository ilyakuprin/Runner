using GameStatus;
using Zenject;

namespace UI
{
    public class ShowingBestScoring : IInitializable
    {
        private const string Format = "Рекорд: {0}";
        
        private readonly MenuCanvasView _menuCanvasView;
        private readonly LoadingSaves _loadingSaves;
        
        public ShowingBestScoring(MenuCanvasView menuCanvasView,
                                  LoadingSaves loadingSaves)
        {
            _menuCanvasView = menuCanvasView;
            _loadingSaves = loadingSaves;
        }

        public void Initialize()
            => _menuCanvasView.Scoring.text = string.Format(Format, _loadingSaves.GameData.Scoring);
    }
}