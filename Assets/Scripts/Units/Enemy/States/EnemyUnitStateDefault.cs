using Assets.Scripts.Managers;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Units.Enemy.States
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

        public void ExitState() { }

        public void FixedUpdate()
        {
            enemySettings.MovementType.Movement(enemySettings.Speed, transform);
            if (transform.position.y >= gameManager.HighRoof.y)
            {
                signalBus.Fire(new Signals.DealDamageUnitSignal() { Damage = 1 });
            }
        }

        public void Update() { }
    }
}