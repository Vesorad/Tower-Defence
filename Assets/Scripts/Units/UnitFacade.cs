using UnityEngine;
using Zenject;

namespace Assets.Scripts.Units
{
    public abstract class UnitFacade : MonoBehaviour, IPoolable<Vector2, IMemoryPool>
    {
        protected HealthController HealthController;

        public abstract void Die();
        public abstract void OnDespawned();
        public abstract void OnSpawned(Vector2 p1, IMemoryPool p2);

        public void Hit(int damage) => HealthController.Hit(damage);
    }
}