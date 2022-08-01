using Units.Enemy;
using UnityEngine;
using Zenject;

namespace Managers
{
    public class EnemySpawner : ITickable
    {
        private readonly Settings settings;
        private readonly EnemyUnitBasicFacade.Factory enemyBasicFactory;
        private readonly EnemyUnitShieldFacade.Factory enemyShieldFactory;
        private readonly SignalBus signalBus;

        private float timeToNextSpawn;
        public EnemySpawner(Settings settings, EnemyUnitBasicFacade.Factory enemyBasicFactory, EnemyUnitShieldFacade.Factory enemyShieldFactory,
            SignalBus signalBus)
        {
            this.settings = settings;
            this.enemyBasicFactory = enemyBasicFactory;
            this.enemyShieldFactory = enemyShieldFactory;
            this.signalBus = signalBus;
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
                signalBus.Fire(new MySignals.SpawnEnemyUnitSignal() { UnitNumber = Random.Range(0, 3) });
            }
        }

        public void ChooseEnemyToSpawn(int unitNumber)
        {
            switch (unitNumber)
            {
                case 0:
                    enemyBasicFactory.Create(settings.SpawnPlace);
                    break;
                case 1:
                    enemyShieldFactory.Create(settings.SpawnPlace);
                    break;
                case 2:
                    Debug.Log("brak");
                    break;
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
