using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controller : MonoBehaviour
{

    public GameObject robot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // cause diver to climb the ladder
        if (Input.GetKeyDown("c"))
        {

        }

        // reset diver
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Debug.Log("R key pressed");
            var position = robot.transform.position;
            position.x = -2.6f;
            position.y = 9.65f;
            position.z = -5.1f;

            var velocity = robot.GetComponent<Rigidbody>().velocity;
            velocity.y = 0;
            robot.GetComponent<Rigidbody>().velocity = velocity;
            robot.transform.position = position;
            
        }

        // robot jump
        if (Input.GetKeyDown(KeyCode.J))
        {
            var position = robot.transform.position;
            position.x = -2.6f;
            position.y = 11.15f;
            position.z = -7.5f;

            var velocity = robot.GetComponent<Rigidbody>().velocity;
            velocity.y = 0;
            robot.GetComponent<Rigidbody>().velocity = velocity;
            robot.transform.position = position;

        }

        // increase amplitude of the wave
        if (Input.GetKeyDown(KeyCode.A))
        {
            CSWave.IncreaseAmplitude();
        }

        // decrease amplitude of the wave
        if (Input.GetKeyDown(KeyCode.Z))
        {
            CSWave.DecreaseAmplitude();
        }

        // increase wavelength
        if (Input.GetKeyDown(KeyCode.D))
        {
            CSWave.IncreaseWavelength();
        }

        // decrease wavelength
        if (Input.GetKeyDown(KeyCode.C))
        {
            CSWave.DecreaseWavelength();
        }

        // increase speed
        if (Input.GetKeyDown(KeyCode.S))
        {
            CSWave.IncreaseSpeed();
        }

        // decrease speed
        if (Input.GetKeyDown(KeyCode.X))
        {
            CSWave.DecreaseSpeed();
        }
    }
}
