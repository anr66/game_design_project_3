using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ripples : MonoBehaviour
{

    Mesh mymesh;
    float speed = 8f;
    public GameObject cube;
    private GameObject[] objects = new GameObject[0];

    float yFactor = 1f;

    // Start is called before the first frame update 
    void Start()
    {
        objects = GameObject.FindGameObjectsWithTag("Respawn");
        Debug.Log(objects.Length); //mymesh = GetComponent().mesh;

        //CreateRipples();
    }

    // Update is called once per frame
    void Update()
    {
        //float size = transform.localScale.x/2;
        mymesh = GetComponent<MeshFilter>().mesh;
        var vertices = mymesh.vertices;
        float distanceX1 = (transform.position.x - objects[0].transform.position.x) / mymesh.bounds.size.x;
        float distanceZ1 = (transform.position.z - objects[0].transform.position.z) / mymesh.bounds.size.z;
        //  float distanceX2 = (transform.position.x - objects[1].transform.position.x)/mymesh.bounds.size.x;
        //  float distanceZ2 = (transform.position.z - objects[1].transform.position.z)/mymesh.bounds.size.z;

        //1, Find furthest vertex distance
        Vector2 otherObjPos = new Vector2(objects[0].transform.position.x, objects[0].transform.position.z);
        float furthestDistance = 0f;
        for (int i = 0; i < vertices.Length; i++)
        {
            float vertexDistance = Vector2.Distance(new Vector2(vertices[i].x, vertices[i].z), otherObjPos);
            if (vertexDistance > furthestDistance)
                furthestDistance = vertexDistance;
        }


        for (var i = 0; i < vertices.Length; i++)
        {
            float offset = (vertices[i].x * vertices[i].x) + (vertices[i].z * vertices[i].z);
            var ripples1 = Mathf.Sin(Time.time * -speed + (offset + (vertices[i].x * distanceX1) + (vertices[i].z * distanceZ1)) * 4) * yFactor;
            //  var ripples2 = Mathf.Sin(Time.time * -speed + (offset + (vertices[i].x * distanceX2) + (vertices[i].z * distanceZ2)) * 4) * .01f;
            vertices[i].y = ripples1;

            //2. Height should be a function of the relationship between vertex distance and furthest distance
            float vertexDistance = Vector2.Distance(new Vector2(vertices[i].x, vertices[i].z), otherObjPos);
            vertices[i].y *= (furthestDistance - vertexDistance) / furthestDistance;
        }

        mymesh.vertices = vertices;
        mymesh.RecalculateNormals();
    }
}