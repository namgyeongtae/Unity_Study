using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    private NavMeshAgent agent;

    public NavMeshSurface surface;

    public float bakeDistance = 10f;

    void Start()
    {
        RebuildNavMesh();
        agent = GetComponent<NavMeshAgent>();

    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        var dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        agent.SetDestination(transform.position + dir * 4f);

        float dist = Vector3.Distance(transform.position, surface.transform.position);
        if (dist > bakeDistance)
        {
            RebuildNavMesh();
        }
    }

    private void RebuildNavMesh()
    {
        surface.transform.position = transform.position;
        surface.BuildNavMesh();
    }
}
