using UnityEngine;

namespace MovementTypes
{
    public abstract class EnemyMovementType : ScriptableObject
    {
        public abstract void Movement(float speed, Transform transform);
    }
}