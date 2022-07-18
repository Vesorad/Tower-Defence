using UnityEngine;
using Zenject;

namespace Assets.Scripts.Units.Enemy
{
    public class EnemyUnitShieldFacade : UnitFacade
    {
        private IMemoryPool pool;

        [Inject]
        public void Construct(HealthController healthController)
        {
            HealthController = healthController;
        }

        public override void OnSpawned(Vector2 startPos, IMemoryPool pool)
        {
            transform.position = startPos;
            this.pool = pool;
        }

        public override void OnDespawned() { }

        public override void Die()
        {
            pool.Despawn(this);
        }

        public class Factory : PlaceholderFactory<Vector2, EnemyUnitShieldFacade> { }
    }
}
