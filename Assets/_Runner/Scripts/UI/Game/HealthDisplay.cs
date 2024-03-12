using System;
using MainHero;
using ScriptableObj;
using UnityEngine;
using Zenject;

namespace UI
{
    public class HealthDisplay : IInitializable, IDisposable
    {
        private const float StartValue = 1f;

        private readonly HealthBarView _healthBarView;
        private readonly HealthChanging _healthChanging;
        private readonly Gradient _gradient;

        public HealthDisplay(HealthBarView healthBarView,
                             HealthChanging healthChanging,
                             MainHeroStatConfig heroStat)
        {
            _healthBarView = healthBarView;
            _healthChanging = healthChanging;
            _gradient = heroStat.GradientHealth;
        }

        public void Initialize()
        {
            SetHealBar(StartValue);

            _healthChanging.HealthChanged += ChangeHealBar;
        }

        public void Dispose()
        {
            _healthChanging.HealthChanged -= ChangeHealBar;
        }

        private void ChangeHealBar(int currentHealth)
        {
            var valueCurrentHealth = (float)currentHealth / _healthChanging.MaxHealth;
            SetHealBar(valueCurrentHealth);
        }

        private void SetHealBar(float value)
        {
            _healthBarView.Bar.fillAmount = value;
            _healthBarView.Bar.color = _gradient.Evaluate(value);
        }
    }
}
