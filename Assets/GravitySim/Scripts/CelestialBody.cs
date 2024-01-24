using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : MonoBehaviour
{
    Rigidbody2D rb;
    float mass;
    public Vector2 initialVelocity;
    public Vector2 currentVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mass = rb.mass;
        currentVelocity = initialVelocity;
    }


    public void UpdateVelocity(CelestialBody[] allBodies, float timeStep)
    {
        foreach (var otherBody in allBodies)
        {
            if (otherBody != this)
            {
                float sqrDst = (otherBody.rb.position - rb.position).sqrMagnitude;
                Vector2 forceDir = (otherBody.rb.position - rb.position).normalized;

                Vector2 acceleration = forceDir * Universe.gravitationalConstant * otherBody.mass / sqrDst;
                currentVelocity += acceleration * timeStep;
            }
        }
    }

    public void UpdatePosition(float timeStep)
    {
        rb.position += currentVelocity * timeStep;
    }
}
