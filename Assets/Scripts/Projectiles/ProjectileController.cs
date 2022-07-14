using UnityEngine;
using Zenject;

namespace Assets.Scripts.Projectiles
{
    public class ProjectileController : ITickable
    {
        private readonly Transform transform;

        private ProjectileBase projectile;

        public ProjectileController(Transform transform)
        {
            this.transform = transform;
        }

        public void UpdateSettings(ProjectileBase projectile)
        {
            this.projectile = projectile;
            transform.rotation = Animation.AnimationsSymulation.LookAtTarget(transform.position, projectile.Target.position);
        }

        public void Tick()
        {
            transform.position += transform.up * projectile.Speed * Time.deltaTime;
        }
    }
}