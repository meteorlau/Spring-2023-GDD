using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class TurnManager : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private KeyCode preparationKey = KeyCode.Q;
    [SerializeField] private KeyCode actionKey = KeyCode.E;
    [SerializeField] private float actionInterval = 2.0f;
    [SerializeField] private GameObject elapsePanel = null;

    private float preparationTimer;
    private bool slowed = false;
    private bool skillExecuted = false;
    private bool aiming = false;

    public static Action LMBDown;
    public static Action RMBDown;
    public static Action onActionPrepare;
    public static Action onSkillExecute;

    private void Awake()
    {
        preparationTimer = actionInterval;
    }

    private void OnEnable()
    {
        RMBDown += ResetActionTimer;
        onActionPrepare += SetSlowState;
        onSkillExecute += SetSlowState;
        onSkillExecute += StartAiming;
        PlayerMovement.onLaunch += Launch;
    }

    private void OnDisable()
    {
        RMBDown -= ResetActionTimer;
        onActionPrepare -= SetSlowState;
        onSkillExecute -= SetSlowState;
        onSkillExecute -= StartAiming;
        PlayerMovement.onLaunch -= Launch;
    }

    private void Update()
    {
        if (!slowed)
        {
            preparationTimer -= Time.deltaTime;
        }

        if (aiming)
        {
            // rotate player according to cursor position

        }
        
        if (Input.GetKeyDown(preparationKey) && onActionPrepare != null && preparationTimer <= 0f)
        {
            // time slows
            onActionPrepare.Invoke();
        }

        if (Input.GetKeyDown(actionKey) && onSkillExecute != null && !skillExecuted)
        {
            skillExecuted = true;
            onSkillExecute.Invoke();
        }
    }

    private void SetSlowState()
    {
        slowed = true;
        preparationTimer = actionInterval;
        elapsePanel.SetActive(true);
    }

    private void StartAiming()
    {

    }

    private void Launch()
    {
        ResetActionTimer();
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
        preparationTimer = actionInterval;
        slowed = false;
        skillExecuted = true;
        elapsePanel.SetActive(false);
    }

    public bool GetIsSlowed()
    {
        return slowed;
    }
}