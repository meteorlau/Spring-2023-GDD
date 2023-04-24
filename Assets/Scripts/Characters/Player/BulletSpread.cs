using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpread : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab = null;
    [SerializeField] private int numBullets = 5;
    [SerializeField] private float bulletSpeed = 15f;
    [SerializeField] private float totalAngle = 90f;

    private void Start()
    {
        Spread();
    }

    private void Spread()
    {
        float angleInterval = totalAngle / (numBullets - 1);

        // left half of bullets
        for (int i = 0; i <= numBullets / 2; ++i)
        {
            GameObject bulletInstance = Instantiate(bulletPrefab,
                transform.position, transform.rotation);
            var currentRotation = bulletInstance.transform.rotation;
            bulletInstance.transform.rotation = currentRotation * 
                Quaternion.AngleAxis(i * angleInterval, Vector3.forward);

            Rigidbody2D rb = bulletInstance.GetComponent<Rigidbody2D>();
            rb.AddForce(-1 * bulletInstance.transform.up * bulletSpeed, ForceMode2D.Impulse);
        }

        // right half of bullets
        for (int i = numBullets / 2 + 1; i < numBullets; ++i)
        {
            int transformedIndex = i - numBullets / 2;
            GameObject bulletInstance = Instantiate(bulletPrefab,
                transform.position, transform.rotation);
            var currentRotation = bulletInstance.transform.rotation;
            bulletInstance.transform.rotation = currentRotation *
                Quaternion.AngleAxis(transformedIndex * -angleInterval, Vector3.forward);

            Rigidbody2D rb = bulletInstance.GetComponent<Rigidbody2D>();
            rb.AddForce(-1 * bulletInstance.transform.up * bulletSpeed, ForceMode2D.Impulse);
        }
    }
}
