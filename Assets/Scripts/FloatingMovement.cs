using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingMovement : MonoBehaviour
{
    private float floatingTimer = 0f;
    public float floatingMax = 2.5f;
    public float floatingDir = 0.1f;

    private void FixedUpdate()
    {
        if (floatingTimer < floatingMax)
        {
            transform.position = new Vector2(transform.position.x, 
                transform.position.y + (floatingDir * Time.fixedDeltaTime));
            floatingTimer += Time.fixedDeltaTime;
        }
        else
        {
            floatingDir *= -1;
            floatingTimer = 0f;
        }
    }

}
