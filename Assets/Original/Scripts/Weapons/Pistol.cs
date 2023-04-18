using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    public Transform firingOrigin = null;
    public GameObject bulletPrefab = null;
    public float bulletForce = 20f;

    [SerializeField] private int rechargeDelay = 2;

    private int rechargeRate = 1;
    private float chargeDelay = 0.5f;
    private float rechargeStart = 0f;

    public override void Apply()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (ammo > 0)
            {
                Shoot();
            }
        }
        Recharge();
    }

    public void Shoot()
    {
        GameObject bulletInstance = Instantiate(bulletPrefab, firingOrigin.position, firingOrigin.rotation);
        Rigidbody2D rb = bulletInstance.GetComponent<Rigidbody2D>();
        rb.AddForce(-1 * firingOrigin.up * bulletForce, ForceMode2D.Impulse);
        ammo -= 1;
        rechargeStart = Time.time + rechargeDelay;

    }

    private void Recharge()
    {
        if (Time.time > rechargeStart && ammo < maxAmmo)
        {
            ammo = Mathf.Min(maxAmmo, ammo + rechargeRate);
            rechargeStart = Time.time + chargeDelay;
        }
    }

    public override void Reload() {
        ammo = Mathf.Min(ammo + reloadAmount, maxAmmo);
    }

    public override int ammoCount() {
        return ammo;
    }

    public override int maxAmmoCount() {
        return maxAmmo;
    }
}
