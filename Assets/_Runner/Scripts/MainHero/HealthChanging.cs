using ScriptableObj;
using System;

namespace MainHero
{
    public class HealthChanging
    {
        public event Action<int> HealthChanged;

        private const int MinHealth = 0;

        private int _currentHealth;

        public HealthChanging(MainHeroStatConfig mainHeroStatConfig)
        {
            MaxHealth = mainHeroStatConfig.Health;
            _currentHealth = MaxHealth;
        }

        public int MaxHealth { get; }

        public void TakeDamage(int value)
        {
            if (value <= 0) return;

            _currentHealth -= value;

            if (_currentHealth < MinHealth)
            {
                _currentHealth = MinHealth;
            }

            HealthChanged?.Invoke(_currentHealth);
        }

        public void TakeHeal(int value)
        {
            if (value <= 0) return;
            if (_currentHealth >= MaxHealth) return;

            _currentHealth += value;

            if (_currentHealth > MaxHealth)
            {
                _currentHealth = MaxHealth;
            }

            HealthChanged?.Invoke(_currentHealth);
        }
    }
}
