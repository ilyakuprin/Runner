using System;
using DG.Tweening;
using MainHero;
using UnityEngine;
using Zenject;

namespace UI
{
    public class VignetteDisplaying : IInitializable, IDisposable
    {
        private const float TimeFade = 0.7f;
        private const float Transparency = 0f;

        private readonly HealthChanging _healthChanging;
        private readonly GameCanvasView _gameCanvasView;
        private Color _startColor;

        public VignetteDisplaying(HealthChanging healthChanging,
                                  GameCanvasView gameCanvasView)
        {
            _healthChanging = healthChanging;
            _gameCanvasView = gameCanvasView;
        }

        public void Initialize()
        {
            _startColor = _gameCanvasView.Vignette.color;
            SetColor(Color.clear);

            _healthChanging.TakenDamage += ShowVignette;
        }

        public void Dispose()
        {
            _healthChanging.TakenDamage -= ShowVignette;
        }

        private void ShowVignette()
        {
            SetColor(_startColor);
            _gameCanvasView.Vignette.DOFade(Transparency, TimeFade);
        }

        private void SetColor(Color color)
            => _gameCanvasView.Vignette.color = color;
    }
}
