using Managers;
using MySignals;
using UnityEngine;
using Zenject;

namespace Units.Enemy.States
{
    public class EnemyUnitStateDefault : IUnitState
    {
        private readonly Transform transform;
        private readonly EnemyUnitBasicInstaller.Settings enemySettings;
        private readonly GameManager gameManager;
        private readonly SignalBus signalBus;

        public EnemyUnitStateDefault(EnemyUnitBasicInstaller.Settings enemySettings, Transform transform, GameManager gameManager,
            SignalBus signalBus)
        {
            this.transform = transform;
            this.enemySettings = enemySettings;
            this.gameManager = gameManager;
            this.signalBus = signalBus;
        }

        public void EnterState() { }

        public void FixedUpdate()
        {
            enemySettings.MovementType.Movement(enemySettings.Speed, transform);
            HitRoof();
        }

        public void Update() { }
        public void ExitState() { }

        private void HitRoof()
        {
            if (transform.position.y >= gameManager.HighRoof.y)
            {
                signalBus.Fire(new HitRoofSignal() { Damage = 1 });
                signalBus.Fire(new DealDamageUnitSignal() { Damage = enemySettings.Health }); //TODO FOR NOW
            }
        }
    }
}