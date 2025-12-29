using UnityEngine;

public class AvoidObstaclesMove : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float mass = 5f;
    public float force = 50f;
    public float minDistToAvoid = 5f;

    private Vector3 targetPoint;
    public float steeringForce = 10f;

    public LayerMask obstacleMask;

    void Start()
    {
        targetPoint = Vector3.zero;
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 1000f))
            {
                targetPoint = hit.point;
            }
        }
    }
}
