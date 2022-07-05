using UnityEngine;
using Zenject;

namespace Assets.Scripts.Tower
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
