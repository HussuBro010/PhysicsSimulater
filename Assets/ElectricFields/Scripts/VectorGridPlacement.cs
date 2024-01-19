using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VectorGridPlacement : MonoBehaviour
{
    public float x_Start, y_Start;
    public int ColumnLength;
    public int RowLength;
    public int x_Space, y_Space;
    public GameObject prefab;
    public GameObject parent;

    public Toggle showVector;

    void Start()
    {
        showVector.isOn = false;

        for (int i = 0; i < ColumnLength * RowLength; i++)
        {
            Vector3 position;
            position = new Vector3(x_Start + (x_Space * (i % ColumnLength)), y_Start + (-y_Space * (i / ColumnLength)));
            Instantiate(prefab, position, Quaternion.identity, parent.transform);
        }

    }

    private void FixedUpdate()
    {
        if (showVector.isOn)
        {
            parent.SetActive(true);
        }
        else
        {
            parent.SetActive(false);
        }
    }
}