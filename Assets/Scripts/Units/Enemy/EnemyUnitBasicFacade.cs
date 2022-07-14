using Assets.Scripts.Managers;
using Zenject;

namespace Assets.Scripts.Units.Enemy
{
    public class EnemyUnitBasicFacade : UnitFacade
    {
        private IMemoryPool pool;
        private EnemySpawner.Settings enemySpawnerSettings;

        [Inject]
        public void Construct(EnemySpawner.Settings enemySpawnerSettings, HealthController healthController)
        {
            this.enemySpawnerSettings = enemySpawnerSettings;
            HealthController = healthController;
        }

        public override void OnSpawned(IMemoryPool pool)
        {
            transform.position = enemySpawnerSettings.SpawnPlace;
            this.pool = pool;
        }

        public override void OnDespawned() { }

        public override void Die()
        {
            pool.Despawn(this);
        }

        public class Factory : PlaceholderFactory<EnemyUnitBasicFacade> { }
    }
}