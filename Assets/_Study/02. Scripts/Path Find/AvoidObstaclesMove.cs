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
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f))
            {
                targetPoint = hit.point;
            }
        }

        Vector3 dir = (targetPoint - transform.position).normalized;

        dir = GetAvoidanceDirection(dir);

        if (Vector3.Distance(targetPoint, transform.position) < 1f)
            return;
        
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

        Quaternion rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, steeringForce * Time.deltaTime);
    }

    private Vector3 GetAvoidanceDirection(Vector3 dir)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, minDistToAvoid, obstacleMask))
        {
            Vector3 hitNormal = hit.normal;
            hitNormal.y = 0f;

            dir = transform.forward + hitNormal * force; // 플레이어가 바라보는 방향 Vector + hit Normal Vector = 플레이어가 장애물을 피해 이동하는 방향 Vector
            dir.Normalize();
        }

        return dir;
    }
}
