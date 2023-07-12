using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Congrats : MonoBehaviour
{
    public Text cText;

    // Start is called before the first frame update
    void Start()
    {
        cText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (GoalCollision.instance.printcongrats)
        {
            cText.text = "Well Done!";
        }
    }
}