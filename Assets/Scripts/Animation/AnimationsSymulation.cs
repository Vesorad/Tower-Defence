using UnityEngine;

namespace Assets.Scripts.Animation
{
    public class AnimationsSymulation
    {
        private bool backToZero;
        private float value;

        public float LerpValue(float speed) //TODO NEED TO MAKE STATIC
        {
            if (backToZero)
            {
                value += speed * Time.deltaTime;
                if (value > 1.0f)
                    backToZero = false;
            }
            else
            {
                value -= speed * Time.deltaTime;
                if (value < 0f)
                    backToZero = true;
            }
            return value;
        }

        public static Quaternion LookAtTarget(Vector3 objectPos, Vector3 targetPos)
        {
            return Quaternion.Euler(0f, 0f, Mathf.Atan2((targetPos - objectPos).y, (targetPos - objectPos).x) * Mathf.Rad2Deg - 90);
        }
    }
}