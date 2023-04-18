using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform firingOrigin = null;
    [SerializeField] private GameObject bulletPrefab = null;
    [SerializeField] private GameObject rocketAmmoPrefab = null;
    [SerializeField] private GameObject pistolPrefab = null;
    [SerializeField] private GameObject minigunPrefab = null;
    [SerializeField] private GameObject shotgunPrefab = null;
    [SerializeField] private GameObject rocketPrefab = null;

    private Gun currentGun;
    private Skills skills;

/*    private void Start() {
        skills = gameObject.GetComponent<Skills>();
        currentGun = skills.GetCurrentSkill();
    }

    private void Update() {
        // check for skill keypress
        skills.ApplyCurrentSkill();
    }

    public void Reload() {
        currentGun.Reload();
    }*/

   /* public void switchMinigun() {
        currentGun = new Minigun(firingOrigin, bulletPrefab, minigunPrefab, FindObjectOfType<GameManager>().minigunAmmo);
        FindObjectOfType<CurrentGunUI>().switchMinigun();
    }

    public void switchPistol() {
        currentGun = new Pistol(firingOrigin, bulletPrefab, pistolPrefab);
        FindObjectOfType<CurrentGunUI>().switchPistol();
    }

    public void switchShotgun() {
        currentGun = new Shotgun(firingOrigin, bulletPrefab, shotgunPrefab, FindObjectOfType<GameManager>().shotgunAmmo);
        FindObjectOfType<CurrentGunUI>().switchShotgun();
    }

    public void switchRocket() {
        currentGun = new Rocket(firingOrigin, rocketAmmoPrefab, rocketPrefab, FindObjectOfType<GameManager>().rocketAmmo);
        FindObjectOfType<CurrentGunUI>().switchRocket();
    }*/

/*    public int ammoCount() {
        return currentGun.ammoCount();
    }

    public int maxAmmoCount() {
        return currentGun.maxAmmoCount();
    }*/
}
