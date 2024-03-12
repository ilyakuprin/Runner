using Collision;
using ScriptableObj;
using StringValues;

namespace MainHero
{
    public class GettingHeal : GettingBoost
    {
        private readonly HealConfig _healConfig;
        private readonly HealthChanging _healthChanging;

        public GettingHeal(HealConfig healConfig,
                           Tags tags,
                           HealthChanging healthChanging,
                           CollidingWithBoost collidingWithBoost) :
            base(collidingWithBoost, tags.Heal)
        {
            _healConfig = healConfig;
            _healthChanging = healthChanging;
        }

        protected override void Get()
        {
            _healthChanging.TakeHeal(_healConfig.Heal);
        }
    }
}
