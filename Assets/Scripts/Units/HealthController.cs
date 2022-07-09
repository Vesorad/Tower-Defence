using Assets.Scripts.Units.Enemy;
using Zenject;

namespace Assets.Scripts.Units
{
    public class HealthController : IInitializable
    {
        private readonly EnemyBasicInstaller.Settings settings;
        private readonly EnemyBasicFacade enemyBasicFacade;

        private int currentHealth;
        private int maxHealth;

        public HealthController(EnemyBasicInstaller.Settings settings, EnemyBasicFacade enemyBasicFacade)
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