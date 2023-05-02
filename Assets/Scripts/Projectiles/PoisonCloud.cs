using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonCloud : MonoBehaviour
{
    [SerializeField] private int poisonDamage = 1;
    [SerializeField] private float damageInterval = 2f;
    [SerializeField] private float cloudPersistTime = 10f;

    private float timer;

    private void Start()
    {
        timer = 0f;
        Destroy(gameObject, cloudPersistTime);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (timer <= 0f)
            {
                // apply poison damage
                collision.gameObject.GetComponent<Health>().TakeDamage(poisonDamage);
                timer = damageInterval;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }     
    }
}
