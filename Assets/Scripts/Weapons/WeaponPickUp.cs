using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    [SerializeField] private GameObject weapon = null;
    [SerializeField] private SkillType skillType;

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    public SkillType GetSkillType()
    {
        return skillType;
    }
}
