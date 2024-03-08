using ScriptableObj;
using System;

namespace MainHero
{
    public class HealthChanging
    {
        public event Action Died;
        public event Action<int> TakenDamage;
        public event Action<int> TakenHeal;

        private const int MinHealth = 0;

        private readonly int _maxHealth;

        private int _currentHealth;

        public HealthChanging(MainHeroStatConfig mainHeroStatConfig)
        {
            _maxHealth = mainHeroStatConfig.Health;
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(int value)
        {
            if (value > 0)
            {
                _currentHealth -= value;

                if (_currentHealth <= MinHealth)
                {
                    _currentHealth = MinHealth;
                    Died?.Invoke();
                }
                else
                {
                    TakenDamage?.Invoke(value);
                }
            }
            else
            {
                ReturnError();
            }
        }

        public void TakeHeal(int value)
        {
            if (value > 0 && _currentHealth < _maxHealth)
            {
                _currentHealth += value;

                if (_currentHealth > _maxHealth)
                {
                    _currentHealth = _maxHealth;
                }
                else
                {
                    TakenHeal?.Invoke(value);
                }
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
