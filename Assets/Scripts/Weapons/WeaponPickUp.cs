using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    [SerializeField] private GameObject weapon = null;
    [SerializeField] private SkillType skillType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Skills>())
        {
            gameObject.SetActive(false);
            //collision.gameObject.GetComponent<Skills>().Acquire(weapon, skillType);
        }
    }

    public SkillType GetSkillType()
    {
        return skillType;
    }
}
