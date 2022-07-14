using Assets.Scripts.Managers;
using Zenject;

namespace Assets.Scripts.Units.Player
{
    public class PlayerUnitBasicFacade : UnitFacade
    {
        private GameManager gameManager;

        [Inject]
        public void Construct(HealthController healthController, GameManager gameManager)
        {
            HealthController = healthController;
            this.gameManager = gameManager;
        }

        public override void OnSpawned(IMemoryPool p1) => transform.position = gameManager.HighTower;
        public override void OnDespawned() { }
        public override void Die() { }

        public class Factory : PlaceholderFactory<PlayerUnitBasicFacade> { }
    }
}