using UnityEngine;
using UnityEngine.AI;

public class NPCMoveAround : MonoBehaviour
{
    private NavMeshAgent _agent;

    [SerializeField]
    private Transform _anchor;

    [SerializeField]
    private float _radius;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        UpdateDestination();
    }

    private void UpdateDestination()
    {
        Vector3 randomDir;

        NavMeshHit hit;
        do
        {
            randomDir = Random.insideUnitCircle * _radius;
            var randomPos = _anchor.position + new Vector3(randomDir.x, 0, randomDir.y);

            if (NavMesh.SamplePosition(randomPos, out hit, _radius, 1))
            {
                if (Vector3.Distance(transform.position, hit.position) > 0.5)
                {
                    _agent.destination = hit.position;
                    return;
                }
            }
        } while (true);
    }

    void Update()
    {
        if (_agent.remainingDistance <= 0.05)
        {
            UpdateDestination();
        }
    }
}
