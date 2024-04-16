using System;
using MainHero;
using ScriptableObj;
using UnityEngine;
using Zenject;

namespace UI
{
    public class HealthDisplaying : IInitializable, IDisposable
    {
        private readonly GameCanvasView _gameCanvasView;
        private readonly HealthChanging _healthChanging;
        private readonly MainHeroStatConfig _mainHeroStatConfig;

        public HealthDisplaying(GameCanvasView gameCanvasView,
                                HealthChanging healthChanging,
                                MainHeroStatConfig mainHeroStatConfig)
        {
            _gameCanvasView = gameCanvasView;
            _healthChanging = healthChanging;
            _mainHeroStatConfig = mainHeroStatConfig;
        }

        public void Initialize()
            => _healthChanging.HealthChanged += ChangeHealBar;

        public void Dispose()
            => _healthChanging.HealthChanged -= ChangeHealBar;

        private void ChangeHealBar(int currentHealth)
        {
            for (var i = 0; i < _gameCanvasView.LengthArrayHearts; i++)
            {
                if (currentHealth > 0)
                {
                    _gameCanvasView.GetHeart(i).sprite = _mainHeroStatConfig.HeartCompleted;
                    currentHealth--;
                }
                else
                {
                    _gameCanvasView.GetHeart(i).sprite = _mainHeroStatConfig.HeartEmpty;
                }
            }
        }
    }
}
