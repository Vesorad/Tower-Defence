using Projectiles;
using Roof;
using Tower;
using Units.Enemy;
using Units.Player;
using UnityEngine;

namespace Zenject
{
    public class GameFactores
    {
        public void BindFactores(DiContainer Container, Settings settings)
        {
            Transform poolsHolder = new GameObject("---POOLS---").transform;

            Container.BindFactory<Vector2, RoofFacade, RoofFacade.Factory>().FromPoolableMemoryPool<Vector2, RoofFacade, RoofPool>
                (poolBinder => poolBinder.WithInitialSize(settings.Roof.PoolSize).FromComponentInNewPrefab
                (settings.Roof.Prefab).UnderTransform(CreateSubFolder(poolsHolder, settings.Roof.NameFolder)));

            Container.BindFactory<TowerOneSlotFacade, TowerOneSlotFacade.Factory>().FromPoolableMemoryPool
                <TowerOneSlotFacade, TowerOneSlotPool>(poolBinder => poolBinder.WithInitialSize
                (settings.PartTowerOneSlot.PoolSize).FromComponentInNewPrefab(settings.PartTowerOneSlot.Prefab)
                .UnderTransform(CreateSubFolder(poolsHolder, settings.PartTowerOneSlot.NameFolder)));

            Container.BindFactory<Vector2, ProjectileBase, ProjectileFacade, ProjectileFacade.Factory>().
                FromPoolableMemoryPool<Vector2, ProjectileBase, ProjectileFacade, ProjectilePool>
                (poolBinder => poolBinder.WithInitialSize(settings.Projectile.PoolSize).FromComponentInNewPrefab
                (settings.Projectile.Prefab).UnderTransform
                (CreateSubFolder(poolsHolder, settings.Projectile.NameFolder)));

            Container.BindFactory<Vector2, EnemyUnitBasicFacade, EnemyUnitBasicFacade.Factory>().FromPoolableMemoryPool
                <Vector2, EnemyUnitBasicFacade, EnemyBasicPool>(poolBinder => poolBinder.
                WithInitialSize(settings.EnemyBasic.PoolSize).FromComponentInNewPrefab(settings.EnemyBasic.Prefab)
                .UnderTransform(CreateSubFolder(poolsHolder, settings.EnemyBasic.NameFolder)));

            Container.BindFactory<Vector2, EnemyUnitShieldFacade, EnemyUnitShieldFacade.Factory>().FromPoolableMemoryPool
               <Vector2, EnemyUnitShieldFacade, EnemyShieldPool>(poolBinder => poolBinder.
               WithInitialSize(settings.EnemyShield.PoolSize).FromComponentInNewPrefab(settings.EnemyShield.Prefab)
               .UnderTransform(CreateSubFolder(poolsHolder, settings.EnemyShield.NameFolder)));

            Container.BindFactory<Vector2, PlayerUnitBasicFacade, PlayerUnitBasicFacade.Factory>().FromPoolableMemoryPool
               <Vector2, PlayerUnitBasicFacade, PlayerBasicPool>(poolBinder => poolBinder.
               WithInitialSize(settings.PlayerBasic.PoolSize).FromComponentInNewPrefab(settings.PlayerBasic.Prefab)
               .UnderTransform(CreateSubFolder(poolsHolder, settings.PlayerBasic.NameFolder)));
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
            [field: SerializeField] public ObjectPool Projectile { private set; get; } = null;

            [field: SerializeField] public ObjectPool EnemyBasic { private set; get; } = null;
            [field: SerializeField] public ObjectPool EnemyShield { private set; get; } = null;

            [field: SerializeField] public ObjectPool PlayerBasic { private set; get; } = null;
        }

        private class RoofPool : MonoPoolableMemoryPool<Vector2, IMemoryPool, RoofFacade> { }
        private class TowerOneSlotPool : MonoPoolableMemoryPool<IMemoryPool, TowerOneSlotFacade> { }
        private class ProjectilePool : MonoPoolableMemoryPool<Vector2, ProjectileBase, IMemoryPool, ProjectileFacade> { }
        private class EnemyBasicPool : MonoPoolableMemoryPool<Vector2, IMemoryPool, EnemyUnitBasicFacade> { }
        private class EnemyShieldPool : MonoPoolableMemoryPool<Vector2, IMemoryPool, EnemyUnitShieldFacade> { }
        private class PlayerBasicPool : MonoPoolableMemoryPool<Vector2, IMemoryPool, PlayerUnitBasicFacade> { }
    }
}