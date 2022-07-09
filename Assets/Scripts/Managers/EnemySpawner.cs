using Assets.Scripts.Units.Enemy;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Managers
{
    public class EnemySpawner: ITickable
    {
        private readonly Settings settings;
        private readonly EnemyUnitBasicFacade.Factory enemyBasicFactory;

        private float timeToNextSpawn;
        public EnemySpawner(Settings settings, EnemyUnitBasicFacade.Factory enemyBasicFactory)
        {
            this.settings = settings;
            this.enemyBasicFactory = enemyBasicFactory;
        }

        public void Tick()
        {
            SpawnEnemy();
        }

        public void SpawnEnemy()
        {
            if (Time.time >= timeToNextSpawn)
            {
                timeToNextSpawn = Time.time + settings.TimeToSpawn;
                enemyBasicFactory.Create();
            }

        }

        [System.Serializable]
        public class Settings
        {
            [field: SerializeField] public Vector2 SpawnPlace { private set; get; } = Vector2.zero;
            [field: SerializeField, Min(0.1f)] public float TimeToSpawn { private set; get; } = 0.1f;
        }
    }
}
