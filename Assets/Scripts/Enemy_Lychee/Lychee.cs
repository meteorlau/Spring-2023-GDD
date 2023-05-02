using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lychee : MonoBehaviour
{
    #region movement_variables
    public float movespeed;
    #endregion 

    #region targeting_variables
    public Transform player;
    #endregion

    #region attack_variables
    public float explosionDamage;
    public float explosionRadius;
    public GameObject explosionPrefab;

    #endregion
   
    #region health_variables
    public float maxHealth;
    float currHealth;
    #endregion

    #region physics_components
    Rigidbody2D EnemyRB;
    #endregion
    
    #region animation_components
    Animator Anim;
    #endregion

    #region unity_functions
    private void Awake() {
        EnemyRB = GetComponent<Rigidbody2D>();
        // Anim = GetComponent<Animator>();
        currHealth = maxHealth;
    }

    private void Update()
    {
        //check if we know where player is
        if (player == null) {
            return;
        }

        Move();        
    }
    #endregion

    #region health_functions
    public void TakeDamage(float value) 
    {
        //decrement health
        currHealth -= value;

        Debug.Log("Enemy Health is now " + currHealth.ToString());

        //check if dead
        if (currHealth <= 0)
        {
            Die();
        }
    }

    private void Die() 
    {
        Destroy(this.gameObject);
    }
    #endregion
    
    #region movement_functions
    private void Move() {
        //calculate movement vector player pos - enemy pos = direction of player relative to enemy
        //have to call normalization
        Vector2 direction = player.position - transform.position;
        EnemyRB.velocity = direction.normalized * movespeed;

    }
    #endregion

    #region attack_functions
    private void Explode() {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, explosionRadius, Vector2.zero);
        foreach (RaycastHit2D hit in hits) {
            if (hit.transform.CompareTag("Player")) {
                //cause damage
                Debug.Log("hit player with explosion");
                hit.transform.GetComponent<Health>().TakeDamage((int)explosionDamage);

                //spawn explosion prefab
                Instantiate(explosionPrefab, transform.position, transform.rotation);
                
            }
        }
        //deactivate object
        Destroy(this.gameObject);

        //onemore line for paralizing player
        Debug.Log("now, player is temporarily paralyzed");
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.CompareTag("Player")) {
            Explode();
        }
    }
    #endregion
}
