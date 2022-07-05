using UnityEngine;
using Zenject;

namespace Assets.Scripts.Enemies
{
    public class EnemyBasicFacade : MonoBehaviour, IPoolable<IMemoryPool>
    {
        private IMemoryPool pool;
        public void Die()
        {
            Debug.Log("Zabity");
            pool.Despawn(this);
        }

        public void OnDespawned() { }
        public void OnSpawned(IMemoryPool pool)
        {
            transform.position = Vector3.zero;
            this.pool = pool;
        }

        public class Factory : PlaceholderFactory<EnemyBasicFacade> { }
    }
}