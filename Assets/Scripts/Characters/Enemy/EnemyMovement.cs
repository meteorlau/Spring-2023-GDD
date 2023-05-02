using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float patrolSpeed = 1.5f;
    [SerializeField] private float chaseMultiplier = 2f;
    [SerializeField] private float strafeMultiplier = 6f;
    [SerializeField] private float arrivalOffsetAllowed = 0.25f;
    [SerializeField] private float pauseTime = 2f;
    [SerializeField] private float wanderDistance = 5f;
    [SerializeField] private Transform wanderTarget = null;

    private Rigidbody2D rb;
    private EnemyBase enemy;
    private AIDestinationSetter destinationSetter;
    private AIPath path;
    private Vector2 targetWanderDestination;

    private bool startingMoving = true;

    private void Start()
    {
        FindObjectOfType<GameManager>().RegisterEnemy();

        GameObject wanderObj = new GameObject();
        wanderTarget = wanderObj.transform;
        RandomNavCircle(transform.position, wanderDistance);

        rb = GetComponentInChildren<Rigidbody2D>();
        enemy = GetComponentInChildren<EnemyBase>();
        destinationSetter = GetComponent<AIDestinationSetter>();
        path = GetComponent<AIPath>();
    }

    private void RandomNavCircle(Vector2 origin, float distance)
    {
        Vector2 randomDirection = UnityEngine.Random.insideUnitCircle * distance;
        randomDirection += origin;
        targetWanderDestination = randomDirection;
    }

    public void ExecutePatrolState()
    {
        if (path.reachedEndOfPath && startingMoving)
        {
            startingMoving = false;
            RandomNavCircle(transform.position, wanderDistance);
            StartCoroutine(PauseThenStart());
        }
        else if (startingMoving)
        {
            // move to next wander destination
            wanderTarget.position = targetWanderDestination;
            MoveTo(wanderTarget, false);
        }
    }

    public void AdjustFaceDirectionIfMelee(Vector3 facePos)
    {
        var faceDir = (facePos - transform.position).normalized;
        if (enemy.toString() == "EnemyMeleeBase")
        {
            if (faceDir.x < 0)
            {
                // make lookDirection.y negative
                faceDir = new Vector2(faceDir.x, -Mathf.Abs(faceDir.y));
            }
            else
            {
                // make lookDirection.y positive
                faceDir = new Vector2(faceDir.x, Mathf.Abs(faceDir.y));
            }
            Vector3 currScale = transform.localScale;
            float scaler = currScale.y;
            rb.transform.localScale =
                Mathf.Atan2(faceDir.y, faceDir.x) > 0 ?
                new Vector3(-1.0f, 1.0f, 1.0f) * scaler : new Vector3(1.0f, 1.0f, 1.0f) * scaler;
        }
    }

    public void MoveTo(Transform position, bool chase, bool strafe=false)
    {
        destinationSetter.target = position;
        if (chase)
        {
            path.maxSpeed = patrolSpeed * chaseMultiplier;
        }
        else if (strafe)
        {
            path.maxSpeed = patrolSpeed * strafeMultiplier;
        }
        else
        {
            path.maxSpeed = patrolSpeed;
        }
    }

    public void StopMovement()
    {
        destinationSetter.target = null;
        path.maxSpeed = 0f;
    }

    private IEnumerator PauseThenStart()
    {
        yield return new WaitForSeconds(pauseTime);
        startingMoving = true;
        wanderTarget.position = targetWanderDestination;
        MoveTo(wanderTarget, false);
    }

    public bool GetFinishedPath()
    {
        return path.reachedEndOfPath;
    }
}