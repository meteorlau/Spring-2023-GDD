using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigun : Gun
{
    public Transform firingOrigin = null;
    public GameObject bulletPrefab = null;
    public float bulletForce = 20f;

    private float fireDelay = 0.05f;
    private float fireDelayStart = 0f;

    public override void Apply()
    {
        if (Input.GetButton("Fire1"))
        {
            if (ammo > 0)
            {
                Shoot();
            }
            else
            {
                //Debug.Log("Out of Ammo");
            }
        }
    }

    public void Shoot()
    {
        if (Time.time < fireDelayStart) {return;}
        GameObject bulletInstance = Instantiate(bulletPrefab, firingOrigin.position, firingOrigin.rotation);
        Rigidbody2D rb = bulletInstance.GetComponent<Rigidbody2D>();
        rb.AddForce(-1 * firingOrigin.up * bulletForce, ForceMode2D.Impulse);
        ammo -= 1;
        fireDelayStart = Time.time + fireDelay;
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
