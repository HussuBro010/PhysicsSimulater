using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class Vector : MonoBehaviour
{
    public float rotationSpeed = 5f; // Speed at which the GameObject rotates

    GameObject sim;
    Charges charges;

    private void Start()
    {
        sim = GameObject.Find("Simulator");
        charges = sim.GetComponent<Charges>();
    }
    void Update()
    {
        Vector2 resultantForce = CalculateResultantForce();
        RotateTowardsForce(resultantForce);
    }

    Vector2 CalculateResultantForce()
    {
        Vector2 force = Vector2.zero;
        foreach (ChargeObject charge in charges.charges)
        {
            Vector2 directionToCharge = (Vector2)charge.transform.position - (Vector2)transform.position;
            float distanceSquared = directionToCharge.sqrMagnitude;
            // Assuming that the force magnitude is inversely proportional to the square of the distance
            float forceMagnitude = charge.chargeMagnitude / distanceSquared;
            force += directionToCharge.normalized * forceMagnitude;
        }
        return force;
    }

    void RotateTowardsForce(Vector2 force)
    {
        if (force != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(force.y, force.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.AngleAxis(targetAngle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
