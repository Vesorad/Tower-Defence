using UnityEngine;

namespace Assets.Scripts.EnemyMovementTypes
{
    public abstract class EnemyMovementType : ScriptableObject
    {
        public abstract void Movement(float speed, Transform transform);
    }
}