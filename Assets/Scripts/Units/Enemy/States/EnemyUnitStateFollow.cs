using UnityEngine;

namespace Assets.Scripts.Units.Enemy.States
{
    public class EnemyUnitStateFollow : IUnitState
    {
        private readonly Transform transform;
        private readonly EnemyUnitBasicInstaller.Settings enemySettings;

        public EnemyUnitStateFollow(EnemyUnitBasicInstaller.Settings enemySettings, Transform transform)
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