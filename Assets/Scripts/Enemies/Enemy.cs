using Assets.Scripts.MonoInstallers;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Enemies
{
    public class Enemy : ITickable
    {
        private readonly EnemyInstaller.Settings objectSettings;
        private readonly Settings settings;
        private readonly GameManager gameManager;

        public Enemy(EnemyInstaller.Settings objectSettings,Settings settings, GameManager gameManager)
        {
            this.objectSettings = objectSettings;
            this.settings = settings;
            this.gameManager = gameManager;
        }

        public void Tick()
        {
            Movement();
            if (objectSettings.MyTransform.position.y >= gameManager.HighRoof.y)
            {
                objectSettings.EnemyFacade.Die();
            }
        }

        public void Movement()
        {
            settings.MovementType.Movement(settings.Speed, objectSettings.MyTransform);
        }

        public void Attack()
        {

        }

        [System.Serializable]
        public class Settings
        {
            [field: SerializeField, Min(1)] public int Health { private set; get; } = 1;
            [field: SerializeField, Min(1)] public EnemyMovementTypes.EnemyMovementType MovementType { private set; get; } = null;
            [field: SerializeField, Min(0.1f)] public float Speed { private set; get; } = 0.1f;
            [field: SerializeField, Min(1)] public int DamageOnRoof { private set; get; } = 1;
        }
    }
}