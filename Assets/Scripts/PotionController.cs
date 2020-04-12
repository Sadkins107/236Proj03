using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionController : MonoBehaviour
{
    public enum PotionType
    {
        Jump,
        Speed
    }

    public PotionType potionType;
    public float modAmount = 0f;

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            if (potionType == PotionType.Jump)
            {
                collision.gameObject.GetComponent<PlayerMovement>().hasJumpPotion = true;
            }
            else if ( potionType == PotionType.Speed)
            {
                collision.gameObject.GetComponent<PlayerMovement>().hasSpeedPotion = true;
            }

            collision.gameObject.GetComponent<PlayerMovement>().modAmount = modAmount;

            Destroy(this.gameObject);
        }
    }
}
