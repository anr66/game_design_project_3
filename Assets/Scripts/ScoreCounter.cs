using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    private static int score; 
    Text text_field;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        text_field = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // update the score counter
        score = CSWave.score_counter;
        text_field.text = "Score: " + score;
        
    }
}
 