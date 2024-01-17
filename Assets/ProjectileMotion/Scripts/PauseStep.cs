using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseStep : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Time.fixedDeltaTime += 1;
        }
    }
}
