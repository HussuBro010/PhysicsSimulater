using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Launcher : MonoBehaviour
{
    [SerializeField] private Transform launchPoint;
    [SerializeField] private Ball projectile;
    [SerializeField] private float launchSpeed = 15f;
    [SerializeField] private float speedStep = 5f;

    [Header("****Trajectory Display****")]

    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private int linePoints = 500;
    [SerializeField] private float timeIntervalInPoints = 0.01f;

    [Header("===UI===")]
    public TextMeshProUGUI forceCounter;
    public Toggle drawTrajectory;
    public List<Ball> projectiles;

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
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    launchSpeed += 100f;
                }
                else
                {
                    launchSpeed += 10f;
                }
            }
            else if (Input.GetKey(KeyCode.LeftAlt))
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    launchSpeed += 0.1f;
                }
                else
                {
                    launchSpeed += 1f;
                }
            }
            else
            {
                launchSpeed += speedStep;
            }
        }
        if (scrollWheel < 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    launchSpeed -= 100f;
                }
                else
                {
                    launchSpeed -= 10f;
                }
            }
            else if (Input.GetKey(KeyCode.LeftAlt))
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    launchSpeed -= 0.1f;
                }
                else
                {
                    launchSpeed -= 1f;
                }
            }
            else
            {
                launchSpeed -= speedStep;
            }
        }
        if (!drawTrajectory.isOn)
        {
            lineRenderer.enabled = false;
        }
        else if(drawTrajectory.isOn)
        {
            lineRenderer.enabled = true;
            DrawTrajectory();
        }

        if (Input.GetMouseButtonDown(1))
        {
            shoot(projectile, launchPoint.up * launchSpeed);
        }

        if (launchSpeed < 0f)
        {
            launchSpeed = 0f;
        }
    }


    public void shoot(Ball projectile, Vector2 velocity)
    {
        projectile = projectile.GetComponent<Ball>();
        var _projectile = Instantiate(projectile, launchPoint.position, launchPoint.rotation);
        _projectile.GetComponent<Rigidbody2D>().velocity = velocity;
        projectiles.Add(_projectile);

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

    public void resetScreen()
    {
        foreach (Ball ball in projectiles)
        {
            Destroy(ball.gameObject);
        }
        projectiles.RemoveAll(x => x != null);
        launchSpeed = 15f;
        drawTrajectory.isOn = true;
    }
}
