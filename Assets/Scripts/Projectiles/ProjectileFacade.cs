using Units;
using UnityEngine;
using Zenject;

namespace Projectiles
{
    public class ProjectileFacade : MonoBehaviour, IPoolable<Vector2, ProjectileBase, IMemoryPool>
    {
        private ProjectileController projectileController;
        private ProjectileBase projectile;
        private IMemoryPool pool;

        [Inject]
        public void Constructor(ProjectileController projectileController)
        {
            this.projectileController = projectileController;
        }

        public void OnSpawned(Vector2 startPos, ProjectileBase projectile, IMemoryPool pool)
        {
            this.projectile = projectile;
            this.pool = pool;

            transform.position = startPos;
            gameObject.layer = projectile.ProjectileLayerNumber;
            projectileController.UpdateSettings(projectile);
        }

        public void OnDespawned() { }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out HealthBaseFacade unit))
                unit.Hit(projectile.Damage);

            pool.Despawn(this);
        }

        public class Factory : PlaceholderFactory<Vector2, ProjectileBase, ProjectileFacade> { }
    }
}
