using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailCollision : MonoBehaviour
{
    private TrailRenderer trail;
    private EdgeCollider2D edgeCollider;

    private void Awake()
    {
        trail = GetComponent<TrailRenderer>();

        GameObject colliderObj = new GameObject("TrailCollider", typeof(EdgeCollider2D));
        edgeCollider = colliderObj.GetComponent<EdgeCollider2D>();
        edgeCollider.edgeRadius = 1f;
        edgeCollider.isTrigger = true;

        colliderObj.AddComponent<SmoothieSlow>();
        colliderObj.AddComponent<Rigidbody2D>();
        colliderObj.GetComponent<Rigidbody2D>().isKinematic = true;

        colliderObj.tag = "Trail";
    }

    private void Update()
    {
        SetColliderPointsFromTrail(trail, edgeCollider);
    }

    private void SetColliderPointsFromTrail(TrailRenderer t, EdgeCollider2D c) 
    {
        List<Vector2> points = new List<Vector2>();
        for (int position = 0; position < trail.positionCount; position++)
        {
            points.Add(trail.GetPosition(position));
        }
        edgeCollider.SetPoints(points);
    }
}
