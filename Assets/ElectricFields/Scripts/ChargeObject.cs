using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeObject : MonoBehaviour
{
    static double K = 9 * Mathf.Pow(10, 9);
    public Rigidbody2D rb;
    public int chargeMagnitude;

    public GameObject spawner;
    Charges charges;

    private void Start()
    {
        spawner = GameObject.Find("Simulator");
        charges = spawner.GetComponent<Charges>();
    }
    private void Update()
    {
        if (transform.position.x > 100 | transform.position.x < -100 | transform.position.y > 100 | transform.position.y < -100)
        {
            charges.charges.Remove(this);
            if (gameObject.tag == "pos")
            {
                charges.numberOfPositives--;
            }
            if (gameObject.tag == "neg")
            {
                charges.numberOfNegatives--;
            }
            Destroy(gameObject);
        }

    }
    void FixedUpdate()
    {
        foreach (ChargeObject charge in charges.charges)
        {
            if (charge != this)
                Force(charge);
        }
    }
    void Force(ChargeObject secondCharge)
    {
        Rigidbody2D secondChargeRb = secondCharge.rb;

        Vector3 direction = rb.position - secondChargeRb.position;
        float distance = direction.magnitude;

        if (distance == 0f)
            return;

        float forceMagnitude = (float)K * (this.chargeMagnitude * secondCharge.chargeMagnitude * Mathf.Pow(10, -10)) / Mathf.Pow(distance, 2);
        Vector3 force = -direction.normalized * forceMagnitude;

        secondChargeRb.AddForce(force);
    }

    /*IEnumerator Despawn()
    {
        yield return new WaitForSeconds(20);
        if (gameObject.tag == "pos")
        {
            charges.numberOfPositives--;
        }
        if (gameObject.tag == "neg")
        {
            charges.numberOfNegatives--;
        }
        Destroy(gameObject);
    }*/
}