using ScriptableObj;

namespace MainHero
{
    public class GettingDamageCalculation
    {
        private const int StandardModificator = 1;

        private readonly int _damage;

        private int _modificator = StandardModificator;

        public GettingDamageCalculation(ObstacleDamageConfig config)
        {
            _damage = config.Damage;
        }

        public int GetDamage()
            => _damage * _modificator;

        public void EnabledInvulnerability()
            => _modificator = 0;

        public void ResetModificator()
            => _modificator = StandardModificator;
    }
}
