using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public double charge = 1;
    public double mass = 1;
    public double v0x = 0;
    public double v0y = 0;
    public double x0 = 0;
    public double y0 = 0;
    [SerializeField] Particle other;
    public Particle[] particles;
    // Start is called before the first frame update
    void Start()
    {
        x0 = transform.position.x;
        y0 = transform.position.y;

        particles = FindObjectsOfType<Particle>();

        InvokeRepeating("DetectParticles", 0, 1);
        //other = FindObjectOfType<Particle>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DetectParticles()
    {
        foreach (Particle particle in particles)
        {
            v0x += ForceElx(transform.position.x, transform.position.y, particle.transform.position.x, particle.transform.position.y, charge, particle.charge) / (1000000000 * mass);
            v0y += ForceEly(transform.position.x, transform.position.y, particle.transform.position.x, particle.transform.position.y, charge, particle.charge) / (1000000000 * mass);

            transform.Translate(new Vector2((float)v0x * Time.deltaTime, (float)v0y * Time.deltaTime));
        }
    }

    public double ForceElx(double x1, double y1, double x2, double y2, double charge1, double charge2)
    {
        double fx = charge1 * charge2 * (x1 - x2) / (4 * math.PI * 8.85e-12 * math.pow((math.pow((x1 - x2), 2) + math.pow((y1 - y2), 2)), 1.5));

        return fx;
    }
    public double ForceEly(double x1, double y1, double x2, double y2, double charge1, double charge2)
    {
        double fy = charge1 * charge2 * (y1 - y2) / (4 * math.PI * 8.85e-12 * math.pow((math.pow((x1 - x2), 2) + math.pow((y1 - y2), 2)), 1.5));

        return fy;
    }
}