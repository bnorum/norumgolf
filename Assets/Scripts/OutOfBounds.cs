using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{

    public GameObject Ball;  
    public GameObject Catcher; 
    private Transform ballTransform;

    // Start is called before the first frame update
    void Start()
    {
        Ball = GameObject.FindGameObjectWithTag("Ball");
        Catcher = GameObject.FindGameObjectWithTag("Catcher");
        ballTransform = Ball.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsObjectInside(Ball, Catcher)) {ballTransform.position = new Vector3(93.28f, -.51f, -1.56f); 
            Invoke("returner",3);
        }
    }

    private void returner(){
            if (GoalCollision.instance.holenum == 1) {ballTransform.position = new Vector3(0f, 1.3f, -1.5f); }
            else if (GoalCollision.instance.holenum == 2) {ballTransform.position = new Vector3(-13f, -1.2f, -1.5f);}
            else if (GoalCollision.instance.holenum == 3) {ballTransform.position = new Vector3(-12.65f, -1f, -6.42f);}
    }
    public bool IsObjectInside(GameObject obj1, GameObject obj2) {

        Bounds bounds1 = obj1.GetComponent<Renderer>().bounds;
        Bounds bounds2 = obj2.GetComponent<Renderer>().bounds;
        return bounds2.Contains(bounds1.min) && bounds2.Contains(bounds1.max);

    }
}
