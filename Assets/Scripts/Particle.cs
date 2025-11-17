using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public double charge = 1;
    public double mass = 1;
    public Vector2 velocity = Vector2.zero;

    private Particle[] particles;

    private const float SPEED_OF_LIGHT = 299792458f;
    private const float SPEED_LIMIT = SPEED_OF_LIGHT;

    private const double EPSILON_0 = 8.85e-12;
    private const float MERGE_DISTANCE = 0.1f;

    // Флаг, слиплась ли частица
    private bool merged = false;

    void Start()
    {
        particles = FindObjectsOfType<Particle>();
    }

    private void FixedUpdate()
    {
        ApplyForces();
        Merge();
    }

    void ApplyForces()
    {
        Vector2 totalForce = Vector2.zero;

        foreach (Particle p in particles)
        {
            if (p == null || p == this || p.merged)
                continue;

            Vector2 r = (Vector2)transform.position - (Vector2)p.transform.position;
            float dist = r.magnitude;

            if (dist < MERGE_DISTANCE)
                continue;

            double dist3 = dist * dist * dist;
            double k = 1.0 / (4.0 * Mathf.PI * (float)EPSILON_0);
            double forceMagnitude = k * charge * p.charge / dist3;

            totalForce += r * (float)forceMagnitude;
        }

        Vector2 acceleration = totalForce / (float)mass;
        velocity += acceleration * Time.fixedDeltaTime;

        if (velocity.magnitude > SPEED_LIMIT)
            velocity = velocity.normalized * SPEED_LIMIT;

        transform.position += (Vector3)(velocity * Time.fixedDeltaTime);
    }

    void Merge()
    {
        foreach (Particle p in particles)
        {
            if (math.sqrt(math.pow((transform.position.x - p.transform.position.x), 2) + math.pow((transform.position.y - p.transform.position.y), 2)) < MERGE_DISTANCE)
            {
                if (charge + p.charge > 0)
                {
                    if (charge >= 0)
                    {
                        p.transform.parent = transform;
                        //velocity = Vector2.zero;
                        //p.velocity = Vector2.zero;
                    }
                    else
                    {
                        transform.parent = p.transform;
                        //velocity = Vector2.zero;
                        //p.velocity = Vector2.zero;
                    }
                }
                else if (charge + p.charge < 0)
                {
                    if (charge >= 0)
                    {
                        transform.parent = p.transform;
                        //velocity = Vector2.zero;
                        //p.velocity = Vector2.zero;
                    }
                    else
                    {
                        p.transform.parent = transform;
                        //velocity = Vector2.zero;
                        //p.velocity = Vector2.zero;
                    }
                }
                else
                {
                    transform.parent = p.transform;
                }

            }
        }
    }
}
