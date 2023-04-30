using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 1f;

    private TurnInputManager turnInputManager;

    public static Action onLaunch;

    private void Start()
    {
        turnInputManager = GetComponent<TurnInputManager>();
    }

    private void Update()
    {
        HandleMovementInput();
    }

    private void HandleMovementInput()
    {
        // only allow rotation if we are in slow-mo
        if (turnInputManager.GetIsSlowed())
        {
            if (Input.GetKey(KeyCode.A))
            {
                // rotate left
                transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                // rotate right
                transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime);
            }
        }
    }

    // OBSOLETE
    public void SpeedUp(float amount)
    {

    }
}
