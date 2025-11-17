using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public double charge = 1;     // заряд частицы
    public double mass = 1;       // масса

    private Vector2 velocity = Vector2.zero;
    private Particle[] particles;

    private const float SPEED_OF_LIGHT = 299792458f;
    private const float SPEED_LIMIT = SPEED_OF_LIGHT;

    private const double EPSILON_0 = 8.85e-12;
    private const double MIN_R = 0.001;    // защита от NaN

    void Start()
    {
        particles = FindObjectsOfType<Particle>();
    }

    void FixedUpdate()
    {
        Vector2 totalForce = Vector2.zero;

        foreach (Particle p in particles)
        {
            if (p == this) continue;

            // направление силы: ОТ другой частицы → К текущей
            Vector2 r = (Vector2)transform.position - (Vector2)p.transform.position;
            double dist = r.magnitude;

            // защита от деления на 0
            if (dist < MIN_R)
                dist = MIN_R;

            // формула Кулона: F = k q1 q2 r / r^3
            double k = 1.0 / (4 * Mathf.PI * (float)EPSILON_0);
            double forceMagnitude = k * charge * p.charge / (dist * dist * dist);

            Vector2 force = r * (float)forceMagnitude;

            totalForce += force;
        }

        // ускорение
        Vector2 acceleration = totalForce / (float)mass;

        // изменение скорости (без 1e9!)
        velocity += acceleration * Time.fixedDeltaTime;

        // ограничение скорости
        if (velocity.magnitude > SPEED_LIMIT)
            velocity = velocity.normalized * SPEED_LIMIT;

        // перемещение
        transform.position += (Vector3)(velocity * Time.fixedDeltaTime);
    }
}
