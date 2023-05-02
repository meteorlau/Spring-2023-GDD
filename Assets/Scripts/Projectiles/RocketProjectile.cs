using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketProjectile : Bullet
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var tag in tagsToAvoid)
        {
            if (collision.gameObject.CompareTag(tag))
            {
                return;
            }
        }

        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.layer = gameObject.layer;
        vfx.GetComponent<SpriteRenderer>().sortingLayerName = GetComponent<SpriteRenderer>().sortingLayerName;
        if (collision.gameObject.GetComponent<Health>())
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damageDealt, BulletType.Rocket);
        }

        Destroy(vfx, 1f);
        Destroy(gameObject);
    }
}
