using UnityEngine;
using Zenject;

namespace Tower
{

    public class TowerOneSlotFacade : MonoBehaviour, IPoolable<IMemoryPool>
    {
        public void OnDespawned()
        {

        }

        public void OnSpawned(IMemoryPool p1)
        {

        }

        public class Factory : PlaceholderFactory<TowerOneSlotFacade> { }
    }
}
