using UnityEngine;
using Zenject;

namespace Assets.Scripts.Units
{
    public abstract class UnitFacade : MonoBehaviour, IPoolable<IMemoryPool>
    {
        protected HealthController HealthController;

        public abstract void Die();
        public abstract void OnDespawned();
        public abstract void OnSpawned(IMemoryPool p1);

        public void Hit(int damage) => HealthController.Hit(damage);
    }
}