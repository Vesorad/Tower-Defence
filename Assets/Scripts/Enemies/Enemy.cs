using UnityEngine;
using Zenject;

namespace Assets.Scripts.Enemies
{
    public class Enemy : ITickable
    {
        private readonly Settings settings;
        private readonly Transform transform;
        private readonly GameManager gameManager;

        public Enemy(Settings settings, Transform transform, GameManager gameManager)
        {
            this.settings = settings;
            this.transform = transform;
            this.gameManager = gameManager;
        }

        public void Tick()
        {
            Movement();
            if (transform.position.y >= gameManager.HighRoof.y)
            {
                Debug.Log("Damage");
            }
        }

        public void Movement()
        {
            settings.MovementType.Movement(settings.Speed, transform);
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