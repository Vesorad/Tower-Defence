using Assets.Scripts.Managers;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Units.Enemy
{
    public class EnemyUnitBasicFacade : UnitFacade
    {
        private IMemoryPool pool;
        private EnemySpawner.Settings enemySpawnerSettings;

        [Inject]
        public void Construct(EnemySpawner.Settings enemySpawnerSettings)
        {
            this.enemySpawnerSettings = enemySpawnerSettings;
        }

        public override void Die()
        {
            Debug.Log("Zabity");
            pool.Despawn(this);
        }

        public override void OnDespawned() { }
        public override void OnSpawned(IMemoryPool pool)
        {
            transform.position = enemySpawnerSettings.SpawnPlace;
            this.pool = pool;
        }
        public class Factory : PlaceholderFactory<EnemyUnitBasicFacade> { }
    }
}