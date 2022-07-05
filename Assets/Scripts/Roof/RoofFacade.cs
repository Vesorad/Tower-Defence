using UnityEngine;
using Zenject;

namespace Assets.Scripts.Roof
{
    public class RoofFacade : MonoBehaviour, IPoolable<IMemoryPool>
    {
        public void OnDespawned()
        {

        }

        public void OnSpawned(IMemoryPool p1)
        {

        }

        public class Factory : PlaceholderFactory<RoofFacade> { }
    }
}