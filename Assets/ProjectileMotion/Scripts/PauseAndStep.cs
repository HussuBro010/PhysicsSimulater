using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseAndStep : MonoBehaviour
{
    private bool isPaused = false;
    public float stepForwardValue = 2f; // Change this to whatever value you want
    public TMP_InputField timeStep;

    private void Start()
    {
        timeStep.text = 2.ToString();
    }
    void Update()
    {
        stepForwardValue = GetDecimalValue(timeStep);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
        }

        if (isPaused)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                StartCoroutine(WaitAndResume(stepForwardValue));
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                StartCoroutine(WaitAndResume(-stepForwardValue));
            }
        }
    }

    public float GetDecimalValue(TMP_InputField inputField)
    {
        float decimalValue;
        if (float.TryParse(inputField.text, out decimalValue))
        {
            return decimalValue;
        }
        else
        {
            return 0;
        }
    }


    IEnumerator WaitAndResume(float waitTime)
    {
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(waitTime);
        Time.timeScale = 0;
    }
}
