using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSWave : MonoBehaviour
{

    public static int score_counter = 0;
    public GameObject robot;
    public GameObject water;

    float time;

    public static float impact_time = 0;
    public static float current_time = 0;

    public static Vector3 contact;
    public static Vector3 local_vector;

    // Amplitude
    static float Amplitude = 2;

    // Wavelength
    static float w = 0.5f;

    // Velocity/Speed
    static float V = 1;

    // Use this for initialization
    void Start()
    {
        score_counter = 0;
    }

    // Update is called once per frame
    //void Update()
    // {
    //   //time += Time.deltaTime;
    //   time = DateTime.Now.Millisecond;
    //}


    private void Update()
    {
        //current_time += Time.deltaTime;

        float t = current_time - impact_time;
        //float r = Mathf.Sqrt((contact.x) * (contact.x) + (contact.z) * (contact.z));
        float e = 2.71f;
        float a = 1.5f;
 

        Mesh mesh = this.GetComponent<MeshFilter>().mesh;
        Vector3[] verts = mesh.vertices;

        for (var v = 0; v < verts.Length; v++)
        {
            current_time = Time.time - impact_time;
            float r = Mathf.Sqrt(Mathf.Pow(verts[v].x - local_vector.x, 2) + Mathf.Pow(verts[v].z - local_vector.z, 2));
            verts[v].y = Amplitude * Mathf.Exp(-r - (a * current_time)) * Mathf.Cos((2 * Mathf.PI) * (r - (V * current_time))/w);
            //verts[v].y = Mathf.Sin(Time.deltaTime);

            //verts[v].y = UnityEngine.Random.Range(0, 50);

            mesh.vertices = verts;
        }


        mesh.vertices = verts;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
    }
    /*

    y(r, t) = A e-r-at cos(2π (r-Vt) /λ);
    r = sqrt((x-x0)*(x-x0)+ (z-z0)*(z-z0))
    P0(x0, y0, z0) : center of the wave
    A: amplitude of the wave
    V: velocity of the wave
    λ: wave length of the wave
    a: speed of decaying
    t = current time – time of impact(t0)

    */



    void OnTriggerEnter(Collider other)
    {
        //if (collider.gameObject.tag == "Player")
       // {
        //Physics.IgnoreCollision(robot.GetComponent<Collider>(), gameObject.GetComponent<Collider>(), true);

        impact_time = Time.time;

        //var milliseconds = DateTime.Now.Millisecond;

        // increment the score
        score_counter++;


        // get the point of impact
        contact = robot.transform.position;
        local_vector = transform.InverseTransformPoint(contact);

        //ContactPoint p = collider.contacts[0];
        //local_vector = transform.InverseTransformPoint(p.point);

        //Mesh mesh = this.GetComponent<MeshFilter>().mesh;
        //Vector3[] verts = mesh.vertices;

        //Vector3 plane_position = this.transform.position;
        //Vector3 plane_vel = this.GetComponent<Rigidbody>().velocity;

        Debug.Log(contact.x);
        Debug.Log(contact.y);
        Debug.Log(contact.z);

        Debug.Log(local_vector.x);

            
       // }
        /*
        //Mesh mesh = this.GetComponent<MeshFilter>().mesh;
        //Vector3[] verts = mesh.vertices;
        for (var v = 0; v < verts.Length; v++)
        {
            verts[v].y = UnityEngine.Random.Range(0, 50);
        }
        mesh.vertices = verts;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        */
        
        
    }

    public static void ResetCollision()
    {
        //Physics.IgnoreCollision(robot.GetComponent<Collider>(), gameObject.GetComponent<Collider>(), false);
    }

    public static void IncreaseAmplitude()
    {
        Amplitude += 1;
    }

    public static void DecreaseAmplitude()
    {
        Amplitude -= 1;
    }

    public static void IncreaseWavelength()
    {
        w += 1;
    }

    public static void DecreaseWavelength()
    {
        w -= 1;
    }

    public static void IncreaseSpeed()
    {
        V += 1;
    }

    public static void DecreaseSpeed()
    {
        V -= 1;
    }
}