using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int ammo;
    public int reloadAmount;
    public int maxAmmo;

    [SerializeField] private SkillType skill;

    // Update is called once per frame
    public virtual void Apply()
    {
        //to be overwritten
    }

    public virtual void Reload()
    {
        ammo = Mathf.Min(ammo + reloadAmount, maxAmmo);
    }

    public virtual int ammoCount() {
        return ammo;
    }

    public virtual int maxAmmoCount() {
        return maxAmmo;
    }

    public void DecreaseAmo()
    {
        ammo -= 1;
    }

    public SkillType GetSkillType()
    {
        return GetComponent<WeaponPickUp>().GetSkillType();
    }
}
