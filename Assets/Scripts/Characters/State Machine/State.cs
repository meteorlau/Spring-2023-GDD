using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Patrol,
    Chase,
    Fire,
    BossProtect
}

[CreateAssetMenu(menuName = "StateMachine/State")]
public class State : ScriptableObject
{
    [SerializeField] private EnemyState state;
    [SerializeField] private Transition[] transitions;

    public virtual void ExecuteActions(GameObject entity)
    {
        switch (state)
        {
            case EnemyState.Patrol:
                Debug.Log("PATROL");
                entity.GetComponent<EnemyMovement>().ExecutePatrolState();
                break;
            case EnemyState.Fire:
                Debug.Log("FIRE");
                entity.GetComponentInChildren<EnemyBase>().ExecuteFireState();
                break;
            case EnemyState.Chase:
                Debug.Log("CHASE");
                entity.GetComponentInChildren<EnemyBase>().ExecuteChaseState();
                break;
            case EnemyState.BossProtect:
                Debug.Log("PROTECT");
                entity.GetComponent<EnemyMovement>().StopMovement();
                break;
            default:
                break;
        }
    }

    public virtual void ExecuteEntryActions(GameObject entity)
    {
        EnemyShooterBase shooter = entity.GetComponentInChildren<EnemyShooterBase>();
        EnemyBase enemy = entity.GetComponentInChildren<EnemyBase>();
        switch (state) 
        {
            case EnemyState.Fire:
                enemy.SetAttacking(true);
                if (shooter != null)
                {
                    shooter.SetStrafe(true);
                }
                break;
            default:
                break;
        }
    }

    public virtual void ExecuteExitActions(GameObject entity)
    {
        EnemyShooterBase shooter = entity.GetComponentInChildren<EnemyShooterBase>();
        EnemyRoller roller = entity.GetComponentInChildren<EnemyRoller>();
        EnemyBase enemy = entity.GetComponentInChildren<EnemyBase>();
        switch (state)
        {
            case EnemyState.Fire:
                enemy.SetAttacking(false);
                if (shooter != null)
                {
                    shooter.SetStrafe(false);
                }
                break;
            case EnemyState.Chase:
                // set enemy rotation upright
                if (roller != null)
                {
                    roller.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    roller.GetComponent<Animator>().SetBool("Roll", false);
                }
                break;
            default:
                break;
        }
    }

    public Transition[] GetTransitions()
    {
        return transitions;
    }
}
