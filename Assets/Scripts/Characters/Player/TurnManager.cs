using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class TurnManager : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private KeyCode actionKey = KeyCode.Q;
    [SerializeField] private float actionInterval = 2.0f;

    private float actionTimer;
    private bool slowed = false;

    public static Action LMBDown;
    public static Action RMBDown;
    public static Action onActionPrepare;

    private void Awake()
    {
        actionTimer = actionInterval;
    }

    private void OnEnable()
    {
        RMBDown += ResetActionTimer;
        onActionPrepare += SetSlowState;
        PlayerMovement.onLaunch += Launch;
    }

    private void OnDisable()
    {
        RMBDown -= ResetActionTimer;
        onActionPrepare -= SetSlowState;
        PlayerMovement.onLaunch -= Launch;
    }

    private void Update()
    {
        if (!slowed)
        {
            actionTimer -= Time.deltaTime;
        }
        
        if (Input.GetKeyDown(actionKey) && onActionPrepare != null && actionTimer <= 0f)
        {
            // time slows
            onActionPrepare.Invoke();
        }
    }

    private void SetSlowState()
    {
        slowed = true;
        actionTimer = actionInterval;
    }

    private void Launch()
    {
        if (RMBDown != null)
        {
            RMBDown.Invoke();
        }
    }

    private void OnMouseDown()
    {
        if (!slowed)
        {
            return;
        }

        // LMB pressed
        if (LMBDown != null)
        {
            LMBDown.Invoke();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!slowed)
        {
            return;
        }

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            // RMB pressed
            if (RMBDown != null)
            {
                RMBDown.Invoke();
            }
        }
    }

    public void ResetActionTimer()
    {
        Debug.Log("Action timer restored");
        actionTimer = actionInterval;
        slowed = false;
    }

    public bool GetIsSlowed()
    {
        return slowed;
    }
}