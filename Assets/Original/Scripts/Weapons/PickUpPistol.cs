using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPistol : MonoBehaviour
{
    [SerializeField] private GameObject pistol = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Skills>())
        {
            gameObject.SetActive(false);
            collision.gameObject.GetComponent<Skills>().Acquire(pistol, Skill.Pistol);
        }
    }
}
