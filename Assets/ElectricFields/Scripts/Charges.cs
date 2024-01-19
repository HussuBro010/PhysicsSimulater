using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Charges : MonoBehaviour
{
    public ChargeObject positive;
    public ChargeObject negative;
    public List<ChargeObject> charges;

    public TextMeshProUGUI positives;
    public TextMeshProUGUI negatives;

    public int numberOfPositives;
    public int numberOfNegatives;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            var _pos = Instantiate(positive, mousePos, Quaternion.identity);
            charges.Add(_pos);
            numberOfPositives++;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            var _neg = Instantiate(negative, mousePos, Quaternion.identity);
            charges.Add(_neg);
            numberOfNegatives++;
        }
        positives.text = numberOfPositives.ToString();
        negatives.text = numberOfNegatives.ToString();
    }
}
