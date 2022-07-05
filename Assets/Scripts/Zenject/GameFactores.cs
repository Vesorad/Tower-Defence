using Assets.Scripts.Enemies;
using Assets.Scripts.Roof;
using Assets.Scripts.Tower;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Zenject
{
    public class GameFactores
    {
        public void BindFactores(DiContainer Container, Settings settings, Transform poolsHolder)
        {

            Container.BindFactory<RoofFacade, RoofFacade.Factory>().FromPoolableMemoryPool<RoofFacade, RoofPool>(poolBinder => poolBinder.WithInitialSize(settings.Roof.PoolSize)
                 .FromComponentInNewPrefab(settings.Roof.Prefab).UnderTransform(poolsHolder));
            Container.BindFactory<TowerOneSlot, TowerOneSlot.Factory>().FromPoolableMemoryPool<TowerOneSlot, TowerOneSlotPool>(poolBinder => poolBinder.WithInitialSize(settings.PartTowerOneSlot.PoolSize)
                  .FromComponentInNewPrefab(settings.PartTowerOneSlot.Prefab).UnderTransformGroup(settings.PartTowerOneSlot.NameFolder));

            Container.BindFactory<EnemyBasicFacade, EnemyBasicFacade.Factory>().FromPoolableMemoryPool<EnemyBasicFacade, EnemyBasicPool>(poolBinder => poolBinder.WithInitialSize(settings.EnemyBasic.PoolSize)
                  .FromComponentInNewPrefab(settings.EnemyBasic.Prefab).UnderTransformGroup(settings.EnemyBasic.NameFolder));


/*            foreach (var item in settings.list) // TODO
            {
                if (item.factory is IPoolable<IMemoryPool> pool)
                {
                         Container.BindFactory< typeof(item.mono), item.factory>().FromPoolableMemoryPool<item.mono, EnemyBasicPool>(poolBinder => poolBinder.WithInitialSize(settings.EnemyBasic.PoolSize)
                  .FromComponentInNewPrefab(settings.EnemyBasic.Prefab).UnderTransformGroup(settings.EnemyBasic.NameFolder));
                }
               
            }*/
        }

        [System.Serializable]
        public class Settings
        {
            [field: SerializeField] public ObjectPool Roof { private set; get; } = null;
            [field: SerializeField] public ObjectPool PartTowerOneSlot { private set; get; } = null;

            [field: SerializeField] public ObjectPool EnemyBasic { private set; get; } = null;

            [field: SerializeField] public List<ObjectPool> list { private set; get; } = null;
        }

        private class RoofPool : MonoPoolableMemoryPool<IMemoryPool, RoofFacade> { }
        private class TowerOneSlotPool : MonoPoolableMemoryPool<IMemoryPool, TowerOneSlot> { }
        private class EnemyBasicPool : MonoPoolableMemoryPool<IMemoryPool, EnemyBasicFacade> { }
    }
}