using Assets.Scripts.Managers;
using UnityEngine;
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

        public override void OnSpawned(Vector2 startPos, IMemoryPool p1) => transform.position = startPos;
        public override void OnDespawned() { }
        public override void Die() { }

        public class Factory : PlaceholderFactory<Vector2, PlayerUnitBasicFacade> { }
    }
}