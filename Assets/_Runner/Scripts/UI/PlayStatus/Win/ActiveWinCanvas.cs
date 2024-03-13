using MainHero;
using System;
using Zenject;

namespace UI
{
    public class ActiveWinCanvas : IInitializable, IDisposable
    {
        private readonly WinCanvasView _winCanvasView;
        private readonly CollidingWithFinalBlock _collidingWithFinalBlock;

        public ActiveWinCanvas(WinCanvasView winCanvasView,
                               CollidingWithFinalBlock collidingWithFinalBlock)
        {
            _winCanvasView = winCanvasView;
            _collidingWithFinalBlock = collidingWithFinalBlock;
        }

        public void Initialize()
        {
            _collidingWithFinalBlock.Collided += Activate;
        }

        public void Dispose()
        {
            _collidingWithFinalBlock.Collided -= Activate;
        }

        private void Activate()
        {
            _winCanvasView.WinObj.SetActive(true);
        }
    }
}
