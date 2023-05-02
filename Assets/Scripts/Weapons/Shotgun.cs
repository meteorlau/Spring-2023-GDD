using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    public Transform firingOrigin = null;
    public GameObject bulletPrefab = null;
    public float bulletForce = 20f;

    private float fireDelay = 0.7f;
    private float fireDelayStart = 0f;

    public override void Apply()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (ammo > 0)
            {
                Shoot();
            }
            else
            {
                Debug.Log("Out of Ammo");
            }
        }
    }

    public void Shoot()
    {
        if (Time.time < fireDelayStart) {return;}
        GameObject bulletInstance_right = Instantiate(bulletPrefab, firingOrigin.position, firingOrigin.rotation * Quaternion.AngleAxis(-25, Vector3.forward));
        Rigidbody2D rb_right = bulletInstance_right.GetComponent<Rigidbody2D>();
        Vector3 v3_right = firingOrigin.up + (0.466f)*firingOrigin.right;
        v3_right.Normalize();
        rb_right.AddForce(-1 * v3_right * bulletForce, ForceMode2D.Impulse);

        GameObject bulletInstance_left = Instantiate(bulletPrefab, firingOrigin.position, firingOrigin.rotation * Quaternion.AngleAxis(25, Vector3.forward));
        Rigidbody2D rb_left = bulletInstance_left.GetComponent<Rigidbody2D>();
        Vector3 v3_left = firingOrigin.up - (0.466f)*firingOrigin.right;
        v3_left.Normalize();
        rb_left.AddForce(-1 * v3_left * bulletForce, ForceMode2D.Impulse);

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
