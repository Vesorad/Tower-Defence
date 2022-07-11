using Zenject;

namespace Assets.Scripts.Units
{
    public class HealthController : IInitializable
    {
        private readonly int maxHealth;
        private readonly UnitFacade unitFacade;

        private int currentHealth;

        public HealthController(int health, UnitFacade unitFacade)
        {
            maxHealth = health;
            this.unitFacade = unitFacade;
        }

        public void Initialize()
        {
            currentHealth = maxHealth;
            UnityEngine.Debug.Log(currentHealth);
        }

        public void Hit(int damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
                unitFacade.Die();
        }
    }
}