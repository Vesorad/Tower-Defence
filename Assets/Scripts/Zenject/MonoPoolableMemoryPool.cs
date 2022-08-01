using UnityEngine;

namespace Zenject
{
    public class MonoPoolableMemoryPool<TParam1, TValue> : MemoryPool<TParam1, TValue> where TValue : Component, IPoolable<TParam1>
    {
        private Transform originalParent;

        [Inject] public MonoPoolableMemoryPool() { }

        protected override void OnCreated(TValue item)
        {
            item.gameObject.SetActive(false);
            originalParent = item.transform.parent;
        }

        protected override void OnDespawned(TValue item)
        {
            item.OnDespawned();
            item.gameObject.SetActive(false);

            if (item.transform.parent != originalParent)
                item.transform.SetParent(originalParent, false);
        }

        protected override void Reinitialize(TParam1 p1, TValue item)
        {
            item.gameObject.SetActive(true);
            item.OnSpawned(p1);
        }
    }
}