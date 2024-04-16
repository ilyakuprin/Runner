using ScriptableObj;
using System;
using UI;

namespace MainHero
{
    public class HealthChanging
    {
        public event Action Dead;
        public event Action TakenDamage;
        public event Action<int> HealthChanged;

        private const int MinHealth = 0;

        private int _currentHealth;

        public HealthChanging(GameCanvasView gameCanvasView)
        {
            MaxHealth = gameCanvasView.LengthArrayHearts;
            _currentHealth = MaxHealth;
        }

        public int MaxHealth { get; }

        public void TakeDamage(int value)
        {
            if (value <= 0) return;

            _currentHealth -= value;

            if (_currentHealth <= MinHealth)
            {
                _currentHealth = MinHealth;
                Dead?.Invoke();
            }

            HealthChanged?.Invoke(_currentHealth);
            TakenDamage?.Invoke();
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
