using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float maxForce = 10f;
    [SerializeField] private float dragForceCoefficient = 2f;

    private Rigidbody2D rb;
    private LineRenderer lineRenderer;
    private Vector3 startPos;
    private Vector3 endPos;
    private bool dragging = false;

    public static Action onLaunch;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
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
        endPos = transform.position;
        dragging = true;
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, new Vector3(startPos.x, startPos.y, -1));
        lineRenderer.SetPosition(1, new Vector3(startPos.x, startPos.y, -1));
    }

    private void OnMouseDrag()
    {
        if (!dragging)
        {
            return;
        }
        var cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        startPos = transform.position;
        endPos = new Vector3(cursorPos.x, cursorPos.y, startPos.z);
        // set line render's start and end positions
        lineRenderer.SetPosition(0, new Vector3(startPos.x, startPos.y, -1));
        lineRenderer.SetPosition(1, new Vector3(endPos.x, endPos.y, -1f));
    }

    private void OnMouseUp()
    {
        if (!dragging)
        {
            return;
        }
        dragging = false;
        lineRenderer.enabled = false;

        Vector2 dir = new Vector2(startPos.x, startPos.y)
            - new Vector2(endPos.x, endPos.y);
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
