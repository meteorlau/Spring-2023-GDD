using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpShotgun : MonoBehaviour
{
    [SerializeField] private GameObject shotgun = null;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Skills>())
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<Skills>().Acquire(shotgun, Skill.Shotgun);
        }
    }
}
