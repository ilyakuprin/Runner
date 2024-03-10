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
            if (value > 0)
            {
                _currentHealth -= value;

                if (_currentHealth < MinHealth)
                {
                    _currentHealth = MinHealth;
                }

                HealthChanged?.Invoke(_currentHealth);
            }
            else
            {
                ReturnError();
            }
        }

        public void TakeHeal(int value)
        {
            if (value > 0 && _currentHealth < MaxHealth)
            {
                _currentHealth += value;

                if (_currentHealth > MaxHealth)
                {
                    _currentHealth = MaxHealth;
                }

                HealthChanged?.Invoke(_currentHealth);
            }
            else
            {
                ReturnError();
            }
        }

        private void ReturnError()
            => throw new NotImplementedException("не положительное значение");
    }
}
