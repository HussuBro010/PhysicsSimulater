using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Simulation : MonoBehaviour
{
    CelestialBody[] bodies;
    public CelestialBody planet;
    Vector2 startPos;
    Vector2 endPos;
    void Awake()
    {
        bodies = FindObjectsOfType<CelestialBody>();
        Time.fixedDeltaTime = Universe.physicsTimeStep;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < bodies.Length; i++)
        {
            bodies[i].UpdateVelocity(bodies, Universe.physicsTimeStep);
        }
        for (int i = 0; i < bodies.Length; i++)
        {
            bodies[i].UpdatePosition(Universe.physicsTimeStep);

        }

        if (Input.GetKeyDown(KeyCode.Space))// Left mouse button down
        {
            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetKeyUp(KeyCode.Space)) // Left mouse button up
        {
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SpawnAndShoot(startPos, endPos);
        }

    }

    void SpawnAndShoot(Vector2 startPosition, Vector2 endPosition)
    {
        // Instantiate the prefab at the start position
        GameObject instance = Instantiate(planet.gameObject, startPosition, Quaternion.identity);

        // Calculate the direction of the drag
        Vector3 direction = endPosition - startPosition;

        // Normalize the direction vector to get a unit vector
        direction.Normalize();

        planet.initialVelocity = direction;
    }
}
