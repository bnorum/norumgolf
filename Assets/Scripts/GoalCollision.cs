using UnityEngine;

public class GoalCollision : MonoBehaviour
{
    public static GoalCollision instance;
    public GameObject Ball;  
    public GameObject Goal; 
    public bool complete; 
    public bool printcongrats; 
    private Transform goalTransform;
    private Transform ballTransform;
    public int holenum;

    private void Start() {
        instance = this;
        Ball = GameObject.FindGameObjectWithTag("Ball");
        Goal = GameObject.FindGameObjectWithTag("Goal");
        goalTransform = GetComponent<Transform>();
        ballTransform = Ball.GetComponent<Transform>();
        complete = true;
        printcongrats = false;
        holenum = 1;
    }

    private void Update() {
        
        if (IsObjectInside(Ball, Goal) && complete)
        {
            complete = false;
            holenum++;
            if (holenum == 2) {
            Invoke("hole2",3);
            }
            if (holenum == 3) {
            Invoke("hole3",3);
            }
            if (holenum == 4) {
                printcongrats = true;
            }
        }
    }

    public void hole2() {
        goalTransform.position = new Vector3(-23.8f, -2f, -11.14f);
        ballTransform.position = new Vector3(-13f, -1.2f, -1.5f);
        complete = true;
        //ballmove.ballHole2();
    }

    public void hole3() {
        goalTransform.position = new Vector3(.77f, -2f, 8f);
        ballTransform.position = new Vector3(-12.65f, -1f, -6.42f);
        complete = true;
        //ballmove.ballHole2();
    }


    public bool IsObjectInside(GameObject obj1, GameObject obj2) {
        // Get the bounding volume of each
        Bounds bounds1 = obj1.GetComponent<Renderer>().bounds;
        Bounds bounds2 = obj2.GetComponent<Renderer>().bounds;

        // Check if bounds1 is inside bounds2

        return bounds2.Contains(bounds1.min) && bounds2.Contains(bounds1.max);

    }
}