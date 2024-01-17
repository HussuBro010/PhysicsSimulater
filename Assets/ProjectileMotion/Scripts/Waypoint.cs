using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    public Transform ballTransform;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(ballTransform.position);
        if (viewportPosition.x > 1 || viewportPosition.y > 1 || viewportPosition.x < 0 || viewportPosition.y < 0)
        {
            // The ball is offscreen, so move the text to the edge of the screen
            transform.position = mainCamera.ViewportToScreenPoint(new Vector3(Mathf.Clamp(viewportPosition.x, 0, 1), Mathf.Clamp(viewportPosition.y, 0, 1), 0));
        }
    }
}
