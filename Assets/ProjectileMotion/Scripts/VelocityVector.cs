using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityVector : MonoBehaviour
{
    public LineRenderer velocityLineRenderer; // Drag your LineRenderer here in the Inspector
    public LineRenderer accelerationLineRenderer; // Drag your LineRenderer here in the Inspector
    private Vector3 lastPosition;
    private Vector3 lastVelocity;
    private Rigidbody2D rb;

    void Start()
    {
        lastPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 velocity = rb.velocity;
        Vector2 acceleration = rb.velocity / rb.mass;
        DrawVelocity(velocity);
        DrawAcceleration(acceleration);
        lastPosition = transform.position;
        lastVelocity = velocity;
    }

    void DrawVelocity(Vector3 velocity)
    {
        velocityLineRenderer.positionCount = 2;
        velocityLineRenderer.SetPosition(0, transform.position);
        velocityLineRenderer.SetPosition(1, lastPosition += velocity.normalized * 2f); // Adjust the scale factor as needed
    }

    void DrawAcceleration(Vector3 acceleration)
    {
        accelerationLineRenderer.positionCount = 2;
        accelerationLineRenderer.SetPosition(0, transform.position);
        accelerationLineRenderer.SetPosition(1, lastPosition += acceleration.normalized * 2f) ; // Adjust the scale factor as needed
    }
}