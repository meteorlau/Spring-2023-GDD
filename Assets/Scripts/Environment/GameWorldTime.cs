using System.Collections;
using UnityEngine;

public class GameWorldTime : MonoBehaviour
{
    [SerializeField] private float timeSlowMultiplier = 0.5f;

    private void OnEnable()
    {
        TurnManager.onActionPrepare += Slow;
        TurnManager.RMBDown += Restore;
    }

    private void OnDisable()
    {
        TurnManager.onActionPrepare -= Slow;
        TurnManager.RMBDown -= Restore;
    }

    private void Slow()
    {
        Debug.Log("Time slows");
        Time.timeScale = timeSlowMultiplier;
    }

    private void Restore()
    {
        Debug.Log("Time restore");
        Time.timeScale = 1f;
    }
}