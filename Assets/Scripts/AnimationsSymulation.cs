using UnityEngine;

public class AnimationsSymulation
{
    private bool backToZero;
    private float value;

    public float LerpValue(float speed)
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
}