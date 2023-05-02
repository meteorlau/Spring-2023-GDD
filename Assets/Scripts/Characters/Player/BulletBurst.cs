using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBurst : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab = null;
    [SerializeField] private int numBullets = 5;
    [SerializeField] private float bulletSpeed = 15f;
    [SerializeField] private float burstInterval = 0.2f;

    private WaitForSeconds waitFor;

    private void Start()
    {
        StartCoroutine(Burst());
        waitFor = new WaitForSeconds(burstInterval);
    }

    private IEnumerator Burst()
    {
        for (int i = 0; i < numBullets; ++i)
        {
            GameObject bulletInstance = Instantiate(bulletPrefab, 
                transform.position, transform.rotation);
            Rigidbody2D rb = bulletInstance.GetComponent<Rigidbody2D>();
            rb.AddForce(-1 * transform.up * bulletSpeed, ForceMode2D.Impulse);
            yield return waitFor;
        }
    }
}
