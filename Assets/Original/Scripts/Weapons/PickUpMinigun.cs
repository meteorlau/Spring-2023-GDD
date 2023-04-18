using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpMinigun : MonoBehaviour
{
    [SerializeField] private GameObject minigun = null;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Skills>())
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<Skills>().Acquire(minigun, Skill.Minigun);
        }
    }
}
