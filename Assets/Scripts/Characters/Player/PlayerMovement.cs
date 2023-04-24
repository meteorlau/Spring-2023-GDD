using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
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
        Vector3 posNow = transform.position;
        Vector3 vec = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            vec.y += movementSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vec.y += -movementSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            vec.x += -movementSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            vec.x += movementSpeed;
        }
        //transform.position = posNow + vec;

        // only allow rotation if we are in slow-mo
        if (vec != Vector3.zero && turnInputManager.GetIsSlowed())
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, vec);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
        }
    }

    // OBSOLETE
    public void SpeedUp(float amount)
    {

    }
}
