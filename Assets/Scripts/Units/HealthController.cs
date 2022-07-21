using Zenject;

namespace Assets.Scripts.Units
{
    public class HealthController : IInitializable
    {
        private readonly int maxHealth;
        private readonly HealthBaseFacade unitFacade;

        private int currentHealth;

        public HealthController(int health, HealthBaseFacade unitFacade)
        {
            maxHealth = health;
            this.unitFacade = unitFacade;
        }

        public void Initialize()
        {
            currentHealth = maxHealth;
        }

        public void Hit(int damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
                unitFacade.OnDeath();
        }
    }
}