using ScriptableObj;

namespace MainHero
{
    public class SpeedCalculation
    {
        private const float StandardModificator = 1f;

        private readonly float _speed;

        private float _modificator = StandardModificator;

        public SpeedCalculation(MainHeroStatConfig heroStatConfig)
        {
            _speed = heroStatConfig.Speed;
        }

        public float GetSpeed()
            => _speed * _modificator;

        public void SetModificator(float value)
        {
            if (value < 0)
                value = 0;

            _modificator = value;
        }

        public void ResetModificator()
            => _modificator = StandardModificator;
    }
}
