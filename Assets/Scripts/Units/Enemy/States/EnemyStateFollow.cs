using UnityEngine;

namespace Assets.Scripts.Units.Enemy.States
{
    public class EnemyStateFollow : IUnitState
    {
        private readonly Transform transform;
        private readonly EnemyBasicInstaller.Settings enemySettings;

        public EnemyStateFollow(EnemyBasicInstaller.Settings enemySettings, Transform transform)
        {
            this.transform = transform;
            this.enemySettings = enemySettings;
        }

        public void EnterState() { }

        public void ExitState() { }

        public void FixedUpdate()
        {
            enemySettings.MovementType.Movement(enemySettings.Speed, transform);
        }

        public void Update() { }
    }
}