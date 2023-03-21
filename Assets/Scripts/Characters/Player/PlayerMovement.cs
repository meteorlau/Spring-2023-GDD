using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float maxForce = 10f;
    [SerializeField] private float dragForceCoefficient = 2f;

    private Rigidbody2D rb;
    private Vector2 startPos;
    private bool dragging = false;

    public static Action onLaunch;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

    }

    private void OnEnable()
    {
        TurnManager.LMBDown += BeginDrag;
    }

    private void OnDisable()
    {
        TurnManager.LMBDown -= BeginDrag;
    }

    private void Launch(Vector2 direction)
    {
        float newX = Mathf.Min(direction.x * dragForceCoefficient, maxForce);
        float newY = Mathf.Min(direction.y * dragForceCoefficient, maxForce);
        rb.AddForce(new Vector2(newX, newY));
    }

    private void BeginDrag()
    {
        Debug.Log("Start Drag");
        startPos = transform.position;
        dragging = true;
    }

    private void OnMouseDrag()
    {
        if (!dragging)
        {
            return;
        }
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        if (!dragging)
        {
            return;
        }
        dragging = false;

        Vector2 dir = startPos - new Vector2(transform.position.x, transform.position.y);
        rb.velocity = Vector2.zero;
        Launch(dir);
        if (onLaunch != null)
        {
            onLaunch.Invoke();
        }
    }

    // OBSOLETE
    public void SpeedUp(float amount)
    {

    }
}
