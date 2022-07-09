using Assets.Scripts.Roof;
using Assets.Scripts.Tower;
using Assets.Scripts.Units.Enemy;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Zenject
{
    public class GameFactores
    {
        public void BindFactores(DiContainer Container, Settings settings, Transform poolsHolder)
        {
            Container.BindFactory<RoofFacade, RoofFacade.Factory>().FromPoolableMemoryPool<RoofFacade, RoofPool>(poolBinder => poolBinder.WithInitialSize(settings.Roof.PoolSize)
                 .FromComponentInNewPrefab(settings.Roof.Prefab).UnderTransform(CreateSubFolder(poolsHolder,settings.Roof.NameFolder)));
            Container.BindFactory<TowerOneSlotFacade, TowerOneSlotFacade.Factory>().FromPoolableMemoryPool<TowerOneSlotFacade, TowerOneSlotPool>(poolBinder => poolBinder.WithInitialSize(settings.PartTowerOneSlot.PoolSize)
                  .FromComponentInNewPrefab(settings.PartTowerOneSlot.Prefab).UnderTransform(CreateSubFolder(poolsHolder,settings.PartTowerOneSlot.NameFolder)));

            Container.BindFactory<EnemyUnitBasicFacade, EnemyUnitBasicFacade.Factory>().FromPoolableMemoryPool<EnemyUnitBasicFacade, EnemyBasicPool>(poolBinder => poolBinder.WithInitialSize(settings.EnemyBasic.PoolSize)
                  .FromComponentInNewPrefab(settings.EnemyBasic.Prefab).UnderTransform(CreateSubFolder(poolsHolder, settings.EnemyBasic.NameFolder)));
        }

        private Transform CreateSubFolder(Transform poolsHolder, string nameFolder)
        {
            Transform transform = new GameObject(nameFolder).transform;
            transform.transform.parent = poolsHolder;
            return transform;
        }


        [System.Serializable]
        public class Settings
        {
            [field: SerializeField] public ObjectPool Roof { private set; get; } = null;
            [field: SerializeField] public ObjectPool PartTowerOneSlot { private set; get; } = null;

            [field: SerializeField] public ObjectPool EnemyBasic { private set; get; } = null;
        }

        private class RoofPool : MonoPoolableMemoryPool<IMemoryPool, RoofFacade> { }
        private class TowerOneSlotPool : MonoPoolableMemoryPool<IMemoryPool, TowerOneSlotFacade> { }
        private class EnemyBasicPool : MonoPoolableMemoryPool<IMemoryPool, EnemyUnitBasicFacade> { }
    }
}