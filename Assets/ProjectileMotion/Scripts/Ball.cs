using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI vel;
    [SerializeField] private TextMeshProUGUI acc;
    [SerializeField] private TextMeshProUGUI velLabel;
    [SerializeField] private TextMeshProUGUI accLabel;

    GameObject toggle;
    Toggle values;
    Rigidbody2D rb;

    void Start()
    {
        toggle = GameObject.Find("Values");
        values = toggle.GetComponent<Toggle>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Init(Vector2 velocity)
    {
        rb.AddForce(velocity, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 acceleration = rb.velocity / rb.mass;
        vel.text = rb.velocity.ToString();
        acc.text = acceleration.ToString();

        if (values.isOn == true)
        {
            vel.enabled = true;
            acc.enabled = true;
            velLabel.enabled = true;
            accLabel.enabled = true;
        }
        else if (values.isOn == false)
        {
            vel.enabled = false;
            acc.enabled = false;
            velLabel.enabled = false;
            accLabel.enabled = false;
        }
    }
}
