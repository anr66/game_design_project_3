using UnityEngine;
using System.Collections;

public class BoidsController : MonoBehaviour
{
    public float minVelocity = 5;
    public float maxVelocity = 20;
    public float randomness = 1;
    public int flockSize = 20;
    public GameObject prefab;
    public GameObject chasee;
    public GameObject new_flock_location;

    public Vector3 flockCenter;
    public Vector3 flockVelocity;

    private GameObject[] boids;

    void Start()
    {
        boids = new GameObject[flockSize];
        for (var i = 0; i < flockSize; i++)
        {
            Vector3 position = new Vector3(
                Random.value * GetComponent<Collider>().bounds.size.x,
                Random.value * GetComponent<Collider>().bounds.size.y,
                Random.value * GetComponent<Collider>().bounds.size.z
            ) - GetComponent<Collider>().bounds.extents;

            GameObject boid = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
            boid.transform.parent = transform;
            boid.transform.localPosition = position;
            boid.GetComponent<BoidFlocking>().SetController(gameObject);
            boids[i] = boid;
        }
    }

    void Update()
    {
        Vector3 theCenter = Vector3.zero;
        Vector3 theVelocity = Vector3.zero;

        //Vector3 test = new Vector3

        foreach (GameObject boid in boids)
        {
            theCenter = theCenter + boid.transform.localPosition;
            theVelocity = theVelocity + boid.GetComponent<Rigidbody>().velocity;
        }

        //flockCenter = theCenter / (flockSize);

        if (CSWave.contact == Vector3.zero)
        {
            flockCenter = chasee.transform.position;
        }

        else
        {
            flockCenter = new_flock_location.transform.position;
            
        }
        
        flockVelocity = theVelocity / (flockSize);
        //flockVelocity = new Vector3(0, 0, 3);
    }
}