using UnityEngine;
using Zenject;

namespace Assets.Scripts.Units
{
    public abstract class HealthBaseFacade : MonoBehaviour, IPoolable<Vector2, IMemoryPool>
    {
        protected HealthController HealthController;

        public abstract void OnDeath();
        public abstract void OnDespawned();
        public abstract void OnSpawned(Vector2 spawnPoint, IMemoryPool pool);

        public void Hit(int damage) => HealthController.Hit(damage);
    }
}