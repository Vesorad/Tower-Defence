using UnityEngine;
using Zenject;

namespace Assets.Scripts.Enemies
{
    public abstract class EnemyFacade : MonoBehaviour, IPoolable<IMemoryPool>
    {
        public abstract void Die();

        public abstract void OnDespawned();
        public abstract void OnSpawned(IMemoryPool p1);
    }
}