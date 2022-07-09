using UnityEngine;
using Zenject;

namespace Assets.Scripts.Units
{
    public abstract class UnitFacade : MonoBehaviour, IPoolable<IMemoryPool>
    {
        public abstract void Die();

        public abstract void OnDespawned();
        public abstract void OnSpawned(IMemoryPool p1);
    }
}