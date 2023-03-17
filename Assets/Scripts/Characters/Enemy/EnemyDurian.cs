using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDurian : EnemyBase
{
    protected float damage; // damage per tick
    protected float range;
    protected float rate; // Number of hits per second
    protected float threshold = 0.7; // Slows player when under 70% health? Or is there a way to see if it's been damaged
    protected bool harmed;

    // Start is called before the first frame update
    override void Start() {
        base.Start();
        // Set up properties for AoE, arbitrary numbers rn
        damage = 5;
        range = 80;
        rate = 1;
        harmed = false;
    }

    // Update is called once per frame
    override void Update() {
        base.Update();
        if (GetComponent<Health>().) { // measure health compared to threshold OR see it's been damaged

        }
        if (playerInRange()) {
            applyEffects();
        }
    }

    private bool playerInRange() {
        // Returns if player is in range of AoE
    }

    private void applyEffects() {
        // damages target player
        // if harmed, also slows player
    }

    
}
