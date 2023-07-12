
using UnityEngine;

public class LineForce : MonoBehaviour
{
    public static LineForce instance;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float stopVelocity = .05f; //serialize for live editing
    [SerializeField] private float shotPower; //serialize for live editing

    
    public bool isIdle;
    public bool isAiming;
    public int score;

    private Rigidbody rigidBody;


     private void Awake() {
        rigidBody = GetComponent<Rigidbody>();
        isAiming = false; //default
        lineRenderer.enabled = false; 
        instance = this;
        score = 0;
    }

    private void Update() {
        if(rigidBody.velocity.magnitude < stopVelocity) { Stop(); }
        Aim();
    }

    private void OnMouseDown() {
        if (isIdle) {
            isAiming = true;
        }

    }

    private void Aim(){
        if (!isAiming || !isIdle) {
            return;
        }

        Vector3? worldPoint = CastMouseClickRay();

        if (!worldPoint.HasValue) {
            return;
        }

        DrawLine(worldPoint.Value);

        if(Input.GetMouseButtonUp(0)) {
            Shoot(worldPoint.Value);
            
        } 
    }

    private void Shoot(Vector3 worldPoint) {
        score+=1;
        isAiming = false;
        lineRenderer.enabled = false;

        Vector3 hworldPoint = new Vector3(worldPoint.x, transform.position.y, worldPoint.z); //transform so no vert movement

        Vector3 direction = (hworldPoint - transform.position).normalized;
        float strength = Vector3.Distance(transform.position, hworldPoint);

        rigidBody.AddForce(direction*strength*shotPower);
        isIdle = true;
    }

    


    private void DrawLine(Vector3 worldPoint) {
        Vector3[] positions = { transform.position, worldPoint };
        lineRenderer.SetPositions(positions);
        lineRenderer.enabled = true;

    }//draw line

    private void Stop() {
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
        isIdle = true;
    }
    
    private Vector3? CastMouseClickRay() { //NOT MY METHOD: sourced from AIA on github
        Vector3 screenMousePosFar = new Vector3( //measure positions of mouse based on near/far camera clip planes
            Input.mousePosition.x,                 //checks for collider hit and if it hits return the point
            Input.mousePosition.y,               // added ? in method def which acts like optional class ie can return null for checks in other methods
            Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        if (Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit, float.PositiveInfinity)) {
            return hit.point;
        } else {
            return null;
        }
    }//castmouse
    
}//lineforce
