using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Launcher : MonoBehaviour
{
    public Transform launchPoint;
    public GameObject projectile;
    public float launchSpeed = 15f;
    float speedStep = 1f;

    [Header("****Trajectory Display****")]
    public LineRenderer lineRenderer;
    public int linePoints = 500;
    public float timeIntervalInPoints = 0.01f;

    [Header("===UI===")]
    public TextMeshProUGUI forceCounter;
    public Toggle drawTrajectory;

    private void Start()
    {
        drawTrajectory.isOn = true;
        launchSpeed = 15f;
    }
    void Update()
    {
        forceCounter.text = launchSpeed.ToString();
        

        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel > 0)
        {
            launchSpeed += speedStep;
        }
        if (scrollWheel < 0)
        {
            launchSpeed -= speedStep;
        }


        if (lineRenderer != null)
        {
            if (drawTrajectory.isOn == true)
            {
                DrawTrajectory();
                lineRenderer.enabled = true;
            }
            else if (drawTrajectory.isOn == false)
            {
                lineRenderer.enabled = false;
            }
                
        }
        if (Input.GetMouseButtonDown(1))
        {
            var _projectile = Instantiate(projectile, launchPoint.position, launchPoint.rotation);
            _projectile.GetComponent<Rigidbody2D>().velocity = launchSpeed * launchPoint.up;
        }
    }

    void DrawTrajectory()
    {
        Vector3 origin = launchPoint.position;
        Vector3 startVelocity = launchSpeed * launchPoint.up;
        lineRenderer.positionCount = linePoints;
        float time = 0;
        for (int i = 0; i < linePoints; i++)
        {
            // s = u*t + 1/2*g*t*t
            var x = (startVelocity.x * time) + (Physics.gravity.x / 2 * time * time);
            var y = (startVelocity.y * time) + (Physics.gravity.y / 2 * time * time);
            Vector3 point = new Vector3(x, y, 0);
            lineRenderer.SetPosition(i, origin + point);
            time += timeIntervalInPoints;
        }
    }
}
