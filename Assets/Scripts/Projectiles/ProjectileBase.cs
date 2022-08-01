using UnityEngine;

namespace Projectiles
{
    [System.Serializable]
    public class ProjectileBase
    {
        [field: SerializeField, Min(1)] public int Damage { private set; get; } = 1;
        [field: SerializeField, Min(0.1f)] public float Speed { private set; get; } = 0.1f;
        [field: SerializeField, Range(13,14)] public int ProjectileLayerNumber { private set; get; } = 13;

        public Transform Target { private set; get; }

        public void SetTarget(Transform target) => Target = target;
    }
}
