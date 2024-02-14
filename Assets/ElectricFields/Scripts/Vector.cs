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
            if (Vector2.Distance(transform.position, charge.transform.position) < Mathf.Abs(charge.chargeMagnitude))
            {
                Vector2 directionToCharge = (Vector2)charge.transform.position - (Vector2)transform.position;
                float distanceSquared = directionToCharge.sqrMagnitude;
                // Use Gaussian function to calculate force magnitude
                float forceMagnitude = charge.chargeMagnitude * Mathf.Exp(-0.5f * distanceSquared / (charge.chargeMagnitude * charge.chargeMagnitude));
                force += directionToCharge.normalized * forceMagnitude;
            }
            else
            {
                transform.rotation = Quaternion.identity;
            }
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
