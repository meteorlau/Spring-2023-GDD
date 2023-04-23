using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpRocket : MonoBehaviour
{
    [SerializeField] private GameObject rocket = null;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Skills>())
        {
            Destroy(gameObject);
            //collision.gameObject.GetComponent<Skills>().Acquire(rocket, Skill.Rocket);
        }
    }
}
