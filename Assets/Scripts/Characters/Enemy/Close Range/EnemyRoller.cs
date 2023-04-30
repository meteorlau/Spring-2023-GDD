using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoller : EnemyBase
{
    [SerializeField] private int collisionDamage = 5;
    [SerializeField] private float extraRollDistance = 10f;

    private Animator animator;
    private bool launched = false;
    private Transform aimTransform;

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        GameObject aimObj = new GameObject();
        aimTransform = aimObj.transform;
    }

    protected override void Update()
    {
        base.Update();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(collisionDamage);
        }
    }

    public override string ToString()
    {
        return "EnemyBomber";
    }

    public override void ExecuteChaseState()
    {
        if (!launched)
        {
            // launch enemy rolling towards player
            var faceDir = player.transform.position - transform.position;
            faceDir.z = 0f;
            float angle = (Mathf.PI/2f + Mathf.Atan2(faceDir.y, faceDir.x)) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            aimTransform.position = player.transform.position;
            var direction = (aimTransform.position - transform.position).normalized;
            aimTransform.position = aimTransform.position + direction * extraRollDistance;
            enemyMovement.MoveTo(aimTransform, true);
            launched = true;
            animator.SetBool("Roll", true);
        }
        else if (enemyMovement.GetFinishedPath()) 
        {
            // reaim 
            launched = false;
            animator.SetBool("Roll", false);
        }
        else if (launched)
        {
            // keep rolling in that direction
            enemyMovement.MoveTo(aimTransform, true);
        }
    }
}