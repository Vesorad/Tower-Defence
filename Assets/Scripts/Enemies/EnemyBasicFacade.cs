using UnityEngine;
using Zenject;

namespace Assets.Scripts.Enemies
{
    public class EnemyBasicFacade : MonoBehaviour, IPoolable<IMemoryPool>
    {
        public void OnDespawned()
        {

        }

        public void OnSpawned(IMemoryPool p1)
        {

        }

        public class Factory : PlaceholderFactory<EnemyBasicFacade> { }
    }
}