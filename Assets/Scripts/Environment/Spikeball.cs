using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikeball : MonoBehaviour
{
    [SerializeField] public readonly static int damageDealt = 5;

    public static bool collected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // collected by player
        if (collision.gameObject.tag == "Player" && !Spikeball.collected)
        {
            Spikeball.collected = true;
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            gameObject.SetActive(false);
        }
    }
}
