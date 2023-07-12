using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score.ToString() + " Putts";
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            score = LineForce.instance.score;
            scoreText.text = "Score: " + score.ToString() + " Putts";
        }
    }
}
