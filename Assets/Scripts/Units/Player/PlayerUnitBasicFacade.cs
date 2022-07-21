using UnityEngine;
using Zenject;

namespace Assets.Scripts.Units.Player
{
    public class PlayerUnitBasicFacade : HealthBaseFacade
    {
        [Inject]
        public void Construct(HealthController healthController)
        {
            HealthController = healthController;
        }

        public override void OnSpawned(Vector2 startPos, IMemoryPool p1) => transform.position = startPos;
        public override void OnDespawned() { }
        public override void OnDeath() { }

        public class Factory : PlaceholderFactory<Vector2, PlayerUnitBasicFacade> { }
    }
}