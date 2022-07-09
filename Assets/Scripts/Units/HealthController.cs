using Assets.Scripts.Units.Enemy;
using Zenject;

namespace Assets.Scripts.Units
{
    public class HealthController : IInitializable
    {
        private readonly EnemyUnitBasicInstaller.Settings settings;
        private readonly EnemyUnitBasicFacade enemyBasicFacade;

        private int currentHealth;
        private int maxHealth;

        public HealthController(EnemyUnitBasicInstaller.Settings settings, EnemyUnitBasicFacade enemyBasicFacade)
        {
            this.settings = settings;
            this.enemyBasicFacade = enemyBasicFacade;
            maxHealth = settings.Health;
        }

        public void Initialize()
        {
            currentHealth = maxHealth;
        }

        public void Hit(int damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
                Die();
        }

        public void Die()
        {

        }
    }
}