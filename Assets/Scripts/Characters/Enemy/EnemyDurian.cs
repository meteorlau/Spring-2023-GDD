using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDurian : EnemyBase
{
    [SerializeField] protected int damage; // damage per tick
    [SerializeField] protected float range;
    [SerializeField] protected float rate; // Number of hits per second
    [SerializeField] protected double threshold; // Slows player when under 70% health? Or is there a way to see if it's been damaged
    [SerializeField] protected bool harmed;
    [SerializeField] protected GameObject poisonCloud;
    [SerializeField] private double slowMultiplier;

    // Start is called before the first frame update
    protected override void Start() {
        base.Start();
        // Set up properties for AoE, arbitrary numbers rn
        damage = 4;
        range = 7;
        rate = 1;
        threshold = 0.7;
        slowMultiplier = 0.8;
        harmed = false;

        // Not sure if this works
        poisonCloud = Instantiate(GameObject.Find("PoisonCloud"));
    }

    protected override void Update() {
        base.Update();
        
        poisonCloud.GetComponent<Transform>().position = base.GetComponent<Transform>().position;
        harmed = (base.GetComponent<Health>().GetCurrentHealth() / base.GetComponent<Health>().GetMaxHealth()) < threshold;
    }

    private void applyEffects() {
        player.GetComponent<Health>().TakeDamage(damage);
        if (harmed) {
            Vector3 var = player.GetComponent<Rigidbody2D>().velocity;
            player.GetComponent<Rigidbody2D>().velocity = var * slowMultiplier;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            applyEffects();
            GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
            vfx.layer = gameObject.layer;
            Destroy(vfx, 5f);
            Destroy(transform.parent.gameObject);
        }
    }

    
}
