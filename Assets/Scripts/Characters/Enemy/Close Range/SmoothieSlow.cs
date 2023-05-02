using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothieSlow : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement movement = collision.gameObject.GetComponent<PlayerMovement>();
        if (movement)
        {
            if (!movement.GetSlowed())
            {
                collision.gameObject.GetComponent<Rigidbody2D>().drag *= 3f;
                movement.SetSlowed(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerMovement movement = collision.gameObject.GetComponent<PlayerMovement>();
        if (movement)
        {
            if (movement.GetSlowed())
            {
                collision.gameObject.GetComponent<Rigidbody2D>().drag /= 3f;
                movement.SetSlowed(false);
            }
        }
    }
}
