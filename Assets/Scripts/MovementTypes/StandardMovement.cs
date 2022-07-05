using UnityEngine;

namespace Assets.Scripts.EnemyMovementTypes
{
    [CreateAssetMenu(menuName = "ScriptableObject/Movement/Standard")]
    public class StandardMovement : EnemyMovementType
    {
        public override void Movement(float speed, Transform transform) => transform.position += transform.up * speed * Time.deltaTime;
    }
}